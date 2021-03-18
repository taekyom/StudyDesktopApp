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
    public partial class FrmRental : MetroForm
    {
        #region 전역변수 영역
        private bool isNew = false; //false : 수정, true : 신규
        #endregion

        #region 이벤트 영역
        public FrmRental()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            isNew = true; //신규 초기화
            InitCboData(); //콤보박스 들어가는 데이터 초기화
            RefreshData(); //테이블 조회

            DtpRentaldate.CustomFormat = "yyyy-MM-dd";
            DtpRentaldate.Format = DateTimePickerFormat.Custom;
        }
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            groupBox1.Height = this.ClientRectangle.Height - 90;
        }
        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) //-1 : 선택된 값이 없다
            {
                var selData = DgvData.Rows[e.RowIndex];

                AsignControls(selData);
                
                isNew = false; //수정
            }

        }

        private void AsignControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString();
            TxtMemberName.Text = selData.Cells[1].Value.ToString();
            //CboDivision.SelectedValue = selData.Cells[2].Value; //B001=B001
            //seldata.cells[3] x

            TxtBookName.Text = selData.Cells[3].Value.ToString();
            //ReleaseDate
            //TxtMobile.Text = selData.Cells[4].Value.ToString();
            DtpRentaldate.Value = (DateTime)selData.Cells[5].Value;
            //TxtISBN.Text = selData.Cells[6].Value.ToString();
            //TxtPrice.Text = selData.Cells[7].Value.ToString();
            //TxtDescription.Text = selData.Cells[8].Value.ToString();

            TxtIdx.ReadOnly = true;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            //Validation
            if (CheckValidation() == false) return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    query = "DELETE [dbo].[divtbl] " +
                            " WHERE [Division] = @Division ";
                    cmd.CommandText = query;

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pDivision);

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        //저장 성공
                        MetroMessageBox.Show(this, "삭제 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //저장 실패
                        MetroMessageBox.Show(this, "삭제 실패", "저장",
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
        private void InitCboData()
        {
            try
            {
                var temp = new Dictionary<string, string>();
                temp.Add("R", "대여중");
                temp.Add("T", "반납");

                CboRentalState.DataSource = new BindingSource(temp, null);
                CboRentalState.DataSource = new BindingSource(temp, null);
                CboRentalState.DisplayMember = "Value";
                CboRentalState.ValueMember = "Key";
                CboRentalState.SelectedIndex = -1;
               
            }
            catch{ }
        }

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

                    query = @"DELETE FROM [dbo].[bookstbl] " +
                             " WHERE [Idx] = @Idx ";
                    cmd.CommandText = query;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT r.idx
                                          ,r.memberidx
	                                      ,m.names as memberName
                                          ,r.bookidx
	                                      ,b.names as bookName
                                          ,r.rentaldate
                                          ,r.returndate
	                                      ,r.rentalState
	                                      ,case r.rentalState 
		                                       when 'R' then '대여중'
		                                       when 'T' then '반납'
		                                       else '상태 없음' 
		                                       end as StateDesc
                                      FROM dbo.rentaltbl as r
                                      inner join dbo.membertbl as m
                                      on r.memberidx = m.idx
                                      inner join dbo.bookstbl as b
                                      on r.bookidx = b.idx"; //210318 descriptions 컬럼 추가
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "rentaltbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "rentaltbl";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            //데이터 그리드뷰 컬럼(Division) 화면에서 안 보이게
            var column = DgvData.Columns[1]; //memberidx 컬럼
            column.Visible = false;
            column = DgvData.Columns[3]; //bookidx
            column.Visible = false;
            column.Visible = false;
            column = DgvData.Columns[7]; //rentalState
            column.Visible = false;

            column = DgvData.Columns[0]; //Idx
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                        query = @"INSERT INTO [dbo].[bookstbl]
                                               ([author]
                                               ,[division]
                                               ,[names]
                                               ,[releasedate]
                                               ,[isbn]
                                               ,[price]
                                               ,[descriptions])
                                         VALUES
                                               (@author
                                               , @division
                                               , @names
                                               , @releasedate
                                               , @isbn
                                               , @price
                                               , @descriptions)" ;
                    }
                    else //update
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                       SET [author] = @author
                                          ,[division] = @division
                                          ,[names] = @names
                                          ,[releasedate] = @releasedate
                                          ,[isbn] = @isbn
                                          ,[price] = @price
                                          ,[descriptions] = @descriptions
                                     WHERE Idx = @Idx";
                    }
                    cmd.CommandText = query;

                    var pAuthor = new SqlParameter("@author", SqlDbType.NVarChar, 50);
                    pAuthor.Value = TxtMemberName.Text;
                    cmd.Parameters.Add(pAuthor);

                    var pDiv = new SqlParameter("@division", SqlDbType.VarChar, 8);
                    cmd.Parameters.Add(pDiv);
                   
                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtBookName.Text;
                    cmd.Parameters.Add(pNames);

                    var pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                    pReleaseDate.Value = TxtBookName.Text;
                    cmd.Parameters.Add(pReleaseDate);

                    var pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    cmd.Parameters.Add(pISBN);

                    var pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    cmd.Parameters.Add(pPrice);

                    var pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar);
                    cmd.Parameters.Add(pDescriptions);

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
            if (string.IsNullOrEmpty(TxtMemberName.Text) ||
                string.IsNullOrEmpty(TxtBookName.Text))
                //CboDivision.SelectedIndex == -1 ||)
            {
                MetroMessageBox.Show(this, "빈 값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void ClearInputs()
        {
            selMemberIdx = 0;
            selMemberName = "";
            TxtIdx.Text = "";
            TxtBookName.Text = "";
            DtpRentaldate.Value = DateTime.Now; //오늘 날짜로 초기화
            TxtIdx.ReadOnly = true;
            isNew = true;
        }
        #endregion

        private int selMemberIdx = 0; //선택된 회원번호
        private string selMemberName = ""; //선택된 회원이름
        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            FrmMemberPopup frm = new FrmMemberPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show($"{frm.selidx} / {frm.selname}")
            }
        }

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {

        }
    }
}
