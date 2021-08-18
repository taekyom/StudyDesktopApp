using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookRentalShop
{
    public partial class FrmBooks : MetroForm
    {
        #region 전역변수 영역
        private bool isNew = false; //false : 수정, true : 신규
        #endregion

        #region 이벤트 영역
        public FrmBooks()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            isNew = true;  //신규 초기화
            InitCboData(); //콤보박스 들어가는 데이터 초기화
            RefreshData(); //테이블 조회

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
        }
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) //선택된 값이 존재하면~(-1 : 선택된 값이 없다)
            {
                var selData = DgvData.Rows[e.RowIndex];
                AsignToControls(selData); 
                
                isNew = false; //수정
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Validation
            if (CheckValidation() == false) return;
            // 삭제질문
            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

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
            // Validation 체크
            if (CheckValidation() == false) return;

            SaveData();
            RefreshData();
            ClearInputs();
        }
        #endregion

        #region 커스텀 메서드 영역
        //Delete 프로세스
        private void DeleteData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";
                    query = @"DELETE FROM [dbo].[bookstbl] 
                                   WHERE [Idx] = @Idx ";
                    cmd.CommandText = query;

                    var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);

                    var result = cmd.ExecuteNonQuery(); // 잘 실행되면 1반환, 안되면 0 반환
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "삭제 실패", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 버튼이벤트 끝났을 때 데이터그리드뷰를 다시 출력(바로 업데이트해주는 것)
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT b.IDX
                                      ,b.AUTHOR
                                      ,b.division
	                                  ,d.names as DivName
                                      ,b.NAMES
                                      ,b.RELEASEDATE
                                      ,b.ISBN
                                      ,b.PRICE
                                      ,b.Descriptions
                                  FROM dbo.bookstbl as b
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
                MessageBox.Show(this, $"예외발생 : {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //데이터 그리드뷰 컬럼(Division) 화면에서 안 보이게
            var column = DgvData.Columns[2]; //division 컬럼
            column.Visible = false;

            column = DgvData.Columns[8]; //descriptions
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";

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
                                               , @descriptions)";
                    }
                    else //update
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                       SET [author]       = @author
                                          ,[division]     = @division
                                          ,[names]        = @names
                                          ,[releasedate]  = @releasedate
                                          ,[isbn]         = @isbn
                                          ,[price]        = @price
                                          ,[descriptions] = @descriptions
                                     WHERE Idx = @Idx";
                    }
                    cmd.CommandText = query;

                    var pAuthor = new SqlParameter("@author", SqlDbType.NVarChar, 50);
                    pAuthor.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);

                    var pDiv = new SqlParameter("@division", SqlDbType.VarChar, 8);
                    pDiv.Value = CboDivision.SelectedValue; // B001
                    cmd.Parameters.Add(pDiv);

                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtBooks.Text;
                    cmd.Parameters.Add(pNames);

                    var pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                    pReleaseDate.Value = DtpReleaseDate.Value;
                    cmd.Parameters.Add(pReleaseDate);

                    var pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pISBN);

                    var pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    pPrice.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pPrice);

                    var pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar);
                    pDescriptions.Value = BookRentalShopApp.Helper.Common.ReplaceCmdText(TxtPrice.Text);
                    cmd.Parameters.Add(pDescriptions);

                    // INSERT에는 파라미터가 7개, UPDATE에는 파라미터가 8개(Idx)이기 때문에
                    // 파라미터 개수에 오류가 생길 수 있으므로 Idx에 Flag 처리를 해주어야 함
                    if (isNew == false) //update일 때만 처리
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
            RefreshData();
            ClearInputs();
        }

        
        private void ClearInputs()
        {
            TxtIdx.Text = TxtAuthor.Text = "";
            TxtBooks.Text = TxtISBN.Text = "";
            TxtPrice.Text = TxtDescription.Text = "";
            TxtDescription.Text = "";
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now; // 오늘 날짜로 초기화

            TxtIdx.ReadOnly = true;
            isNew = true;
        }

        //입력값 유효성 체크 메서드
        private bool CheckValidation()
        {
            if (string.IsNullOrEmpty(TxtAuthor.Text) ||CboDivision.SelectedIndex == -1 ||
                string.IsNullOrEmpty(TxtBooks.Text) ||DtpReleaseDate.Value == null)
            {
                MetroMessageBox.Show(this, "빈 값은 처리할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //콤보박스에 들어가는 데이터 초기화
        private void InitCboData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(BookRentalShopApp.Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = @"SELECT division, names FROM dbo.divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read()) // Read 메서드를 통해 reader 레코드를 계속 읽음(데이터 없을 때까지 읽음, 없으면 false 반환)
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString()); //(key)B001 ,(value)공포/스릴러
                    }
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //선택된 데이터 정보를 텍스트박스에 출력
        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString();
            TxtAuthor.Text = selData.Cells[1].Value.ToString();
            CboDivision.SelectedValue = selData.Cells[2].Value; // B001 = B001
            TxtBooks.Text = selData.Cells[4].Value.ToString();
            DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
            TxtISBN.Text = selData.Cells[6].Value.ToString();
            TxtPrice.Text = selData.Cells[7].Value.ToString();
            TxtDescription.Text = selData.Cells[8].Value.ToString();

            TxtIdx.ReadOnly = true;
        }

        #endregion
    }
}
