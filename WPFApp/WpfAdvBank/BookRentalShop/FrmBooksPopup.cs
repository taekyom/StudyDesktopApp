using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookRentalShop
{
    public partial class FrmBooksPopup : MetroForm
    {
        #region 전역변수 영역
        public int SelIdx { get; set; }
        public string SelName { get; set; }

        #endregion

        #region 이벤트 영역
        public FrmBooksPopup()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            RefreshData(); //테이블 조회
        }
         
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {

        }
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 선택된 값이 존재하면
            {
                var selData = DgvData.Rows[e.RowIndex];
            }
        }
        
        #endregion

        #region 커스텀 메서드 영역
        //데이터가 변경될 때마다 실행시켜서 새로운 데이터를 보여줌     
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT b.IDX
                                      ,b.AUTHOR
                                      ,b.DIVISION
	                                  ,d.names as DivName
                                      ,b.NAMES
                                      ,b.RELEASEDATE
                                      ,b.ISBN
                                      ,b.PRICE
                                      ,b.Descriptions
                                  FROM DBO.BOOKSTBL as b
                                  inner join dbo.divtbl as d
	                                on b.division = d.division"; //210318 descriptions 컬럼 추가
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "bookstbl";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // 데이터그리드뷰 컬럼 화면에서 안보이게
            var column = DgvData.Columns[2]; // Division 컬럼
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";

            column = DgvData.Columns[0]; // Idx
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if(DgvData.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요", "경고", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelIdx = (int)DgvData.SelectedRows[0].Cells[0].Value;
            SelName = DgvData.SelectedRows[0].Cells[4].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
