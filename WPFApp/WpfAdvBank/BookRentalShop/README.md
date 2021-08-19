# 🏫 BookRentalShop <br/>
- C# Winform을 활용해 도서 대여 관리 프로그램 작성
- 로그인, 도서 구분코드 관리, 도서관리, 대여관리 기능을 넣은 폼 작성
- 각 폼마다 CRUD(Create, Read, Update, Delete) 버튼 이벤트 작성
- Winform과 DB 연결을 위해 SQL Server연동(SqlConnection 클래스 선언, SqlCommand로 쿼리문 사용)

-------------------------------------

## 실행화면 <br/>
1. 로그인 폼<br/>
![image](https://user-images.githubusercontent.com/77951868/129994158-765c57f9-2d44-4468-8f6f-4ce2e426f669.png)<br/>
  - 로그인 폼 입력값의 null 여부 체크
  ```c#
  if (string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))
              {
                  MetroMessageBox.Show(this,"아이디/패스워드를 입력하세요!","오류",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  return;
              }

  ```
  - 회원DB를 불러와 입력한 값과 비교
  ```c#
  // 입력한 userID와 password가 일치하는 UserID를 받아와 비교
                    var query = "select userID from membertbl " +
                                " where userID = @userID " +
                                " and passwords = @passwords ";
                                
      ......

      strUserId = reader["UserID"] != null ? reader["userID"].ToString() : "";

      if (string.IsNullOrEmpty(strUserId))
                          {
                              MetroMessageBox.Show(this, "접속실패", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                  return;
                          }

  ```
  

2. 도서 구분코드 관리<br/>
![image](https://user-images.githubusercontent.com/77951868/129997051-80acd951-8438-4de5-abe2-d6a5ccf84b0f.png)<br/>
![image](https://user-images.githubusercontent.com/77951868/129994916-ed01a208-e337-4f4d-97c5-95d7cc13b2d1.png)<br/>

3. 도서관리 <br/>
![image](https://user-images.githubusercontent.com/77951868/129997112-01c8b110-40c4-4351-abf7-dce6a524e78b.png)<br/>

4. 회원관리 <br/>
![image](https://user-images.githubusercontent.com/77951868/129997097-57459880-3adb-4dff-b161-1f361c878066.png)<br/>

5. 대여관리 <br/>
![image](https://user-images.githubusercontent.com/77951868/129997145-09d8f1f2-1a56-4d4c-bee3-aefe7c76f8e2.png)<br/>

6. 종료화면<br/>
![image](https://user-images.githubusercontent.com/77951868/129997162-1b87a006-6511-41eb-ba71-3b0382cda02b.png)




















