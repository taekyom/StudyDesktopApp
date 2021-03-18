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
    public partial class FrmMemberPopup : MetroForm
    {
        #region 전역변수 영역
        #endregion

        #region 이벤트 영역
        public FrmMemberPopup()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
        }
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        #endregion

        #region 커스텀 메서드 영역
        //삭제처리 프로세스
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
        #endregion

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
