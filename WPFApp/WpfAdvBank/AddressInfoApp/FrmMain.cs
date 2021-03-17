using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressInfoApp
{
    public partial class FrmMain : Form
    {
        string connString = "Data Source=127.0.0.1;Initial Catalog=PMS;Persist Security Info=True;" +
                            "User ID=sa;Password=mssql_p@ssw0rd!";
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int.TryParse(TxtIdx.Text, out int result);
            if(result > 0)
            {
                MessageBox.Show("초기화를 하십시오.");
                return;
            }
            if (string.IsNullOrEmpty(TxtFullName.Text) || string.IsNullOrEmpty(TxtContact.Text))
            {
                MessageBox.Show("값을 입력하세요.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = $"INSERT INTO dbo.Address " +
                               $"( FullName, " +
                               $"  Contact, " +
                               $"  Addr, " +
                               $"  RegId, " +
                               $"  RegDate) " +
                               $"VALUES " +
                               $"( '{TxtFullName.Text}', " +
                               $"  '{TxtContact.Text.Replace("-", "")}', " +
                               $"  '{TxtAddr.Text}'," +
                               $"  'admin'," +
                               $"   GETDATE() ); ";
                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("입력성공!");
                }
                else
                {
                    MessageBox.Show("입력실패!");
                }
            }
            ClearInput();
            RefreshData();
        }
        
        private void BtnRevise_Click(object sender, EventArgs e)
        {
            int.TryParse(TxtIdx.Text, out int result);
            if (result == 0)
            {
                MessageBox.Show("데이터를 선택하십시오.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = $"UPDATE Address " +
                               $" SET " +
                               $" FullName = '{TxtFullName.Text}', " +
                               $" Contact = '{TxtContact.Text.Replace("-", "")}'," +
                               $" Addr = '{TxtAddr.Text}'," +
                               $" ModId = 'admin'," +
                               $" ModDate = GETDATE() " +
                               $" WHERE Idx = {result} ";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("수정 성공!");
                }
                else
                {
                    MessageBox.Show("수정 실패!");
                }
            }
            ClearInput();
            RefreshData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //데이터를 선택하지 않고 삭제버튼을 누를 때
            int.TryParse(TxtIdx.Text, out int result);
            if(result == 0)
            {
                MessageBox.Show("데이터를 선택하십시오.");
                return;
            }

            if(MessageBox.Show("삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //원하는 데이터 선택 후 삭제버튼 누를 때
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = $"DELETE FROM Address WHERE idx = {result}";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("삭제 성공!");
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패!");
                    }
                }
                ClearInput();
                RefreshData();
            }
        }

        private void TxtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13) //엔터
            {
                TxtContact.Focus();
            }
        }

        private void TxtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                TxtAddr.Focus();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RefreshData();
            ClearInput();
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                //SSMS 테이블 스크립팅 메뉴 활용
                string query = "SELECT Idx " +
                               "     , FullName " +
                               "     , Contact " +
                               "     , Addr " +
                               "  FROM dbo.Address ";
                //SqlCommand, SqlDataReader or Object 사용방법1
                //SqlDataAdapter, DataSet
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DgvAddress.DataSource = ds.Tables[0];
            }
        }

        private void ClearInput()
        {
            TxtIdx.Text = TxtFullName.Text = TxtContact.Text = TxtAddr.Text = "";
        }

        //cell 클릭했을 때 각 textbox에 원래 정보가 바로 입력되도록 하는 부분
        private void DgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectData = DgvAddress.Rows[e.RowIndex].Cells;

            TxtIdx.Text = selectData[0].Value.ToString();
            TxtFullName.Text = selectData[1].Value.ToString();
            TxtContact.Text = selectData[2].Value.ToString();
            TxtAddr.Text = selectData[3].Value.ToString();
        }
    }
}
