using MetroFramework;
using MetroFramework.Forms;
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

namespace BookRentalShop
{
    public partial class FrmMember : MetroForm
    {
        #region 전역변수 영역
        private bool isNew = false; //false : 수정, true : 신규
        #endregion

        #region 이벤트 영역
        public FrmMember()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            isNew = true; //신규
            RefreshData();
        }
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) //-1 : 선택된 값이 없다
            {
                var selData = DgvData.Rows[e.RowIndex];
                TxtIdx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                CboLevel.SelectedItem = selData.Cells[2].Value;

                TxtAddr.Text = selData.Cells[3].Value.ToString();
                TxtMobile.Text = selData.Cells[4].Value.ToString();
                TxtEmail.Text = selData.Cells[5].Value.ToString();
                TxtUserId.Text = selData.Cells[6].Value.ToString();

                TxtIdx.ReadOnly = true;

                isNew = false; //수정
            }

        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            //Validation
            if (CheckValidation() == false) return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }

      
        
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Validation 체크
            if (CheckValidation() == false) return;
            SaveData();
            RefreshData();
            ClearInputs();
        }
        #endregion

        #region 커스텀 메서드 영역
        //삭제처리 프로세스
        private void DeleteData()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    query = "DELETE FROM [dbo].[membertbl] " +
                              " WHERE [Idx] = @Idx ";
                    cmd.CommandText = query;

                    var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제 성공", "삭제",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "삭제 실패", "삭제",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT [Idx] 
                                        ,[Names]
                                        ,[Levels]
                                        ,[Addr]
                                        ,[Mobile]
                                        ,[Email]
                                        ,[userID]
                                        ,[lastLoginDt]
                                        ,[loginIpAddr]
                                    FROM [dbo].[membertbl]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "membertbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "membertbl";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //입력(수정)처리 프로세스
        private void SaveData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    if (isNew == true) //insert
                    {
                        query = @"INSERT INTO [dbo].[membertbl]
                                       ([Names]
                                       ,[Levels]
                                       ,[Addr]
                                       ,[Mobile]
                                       ,[Email]
                                       ,[userID]
                                       ,[passwords])
                                 VALUES
                                       (@Names
                                       ,@Levels
                                       ,@Addr
                                       ,@Mobile
                                       ,@Email
                                       ,@userID
                                       ,@passwords) ";
                    }
                    else //update
                    {
                        query = @"UPDATE [dbo].[membertbl]" +
                                 "   SET [Names] = @Names " +
                                 "      ,[Levels] = @Levels " +
                                 "      ,[Addr] = @Addr" +
                                 "      ,[Mobile] = @Mobile" +
                                 "      ,[Email] = @Email" +
                                 "      ,[userID] = @userID" +
                                 "      ,[passwords] = @passwords" +
                                 "WHERE Idx = @Idx ";
                    }
                    cmd.CommandText = query;

                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 50);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    var pLevels = new SqlParameter("@Levels", SqlDbType.VarChar, 8);
                    pLevels.Value = CboLevel.SelectedItem.ToString();
                    cmd.Parameters.Add(pLevels);

                    var pAddr = new SqlParameter("@Addr", SqlDbType.NVarChar, 100);
                    pAddr.Value = TxtAddr.Text;
                    cmd.Parameters.Add(pAddr);

                    var pMobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 13);
                    pMobile.Value = TxtMobile.Text;
                    cmd.Parameters.Add(pMobile);

                    var pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                    pEmail.Value = TxtEmail.Text;
                    cmd.Parameters.Add(pEmail);

                    var puserID = new SqlParameter("@userID", SqlDbType.VarChar, 20);
                    puserID.Value = TxtUserId.Text;
                    cmd.Parameters.Add(puserID);

                    var pPasswords = new SqlParameter("@passwords", SqlDbType.VarChar, 100);
                    pPasswords.Value = TxtPassword.Text;
                    cmd.Parameters.Add(pPasswords);

                    if (isNew == false) //update일 때만 처리;
                    {
                        var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //저장 성공
                        MetroMessageBox.Show(this, "저장 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //저장 실패
                        MetroMessageBox.Show(this, "저장 실패", "저장",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
        }
        //입력값 유효성 체크 메서드
        private bool CheckValidation()
        {
            if(string.IsNullOrEmpty(TxtNames.Text) ||
                string.IsNullOrEmpty(TxtAddr.Text) || string.IsNullOrEmpty(TxtMobile.Text) ||
                string.IsNullOrEmpty(TxtEmail.Text) || CboLevel.SelectedIndex == -1 ||
                string.IsNullOrEmpty(TxtUserId.Text))
            {
                MetroMessageBox.Show(this, "빈 값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ClearInputs()
        {
            TxtIdx.Text = TxtNames.Text = "";
            TxtMobile.Text = TxtAddr.Text = TxtEmail.Text = "";
            TxtUserId.Text = TxtPassword.Text = "";
            CboLevel.SelectedIndex = -1;
            TxtIdx.ReadOnly = true;
            isNew = true;
        }
        #endregion
    }
}
