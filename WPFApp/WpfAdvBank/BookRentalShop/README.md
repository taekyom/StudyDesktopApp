# ๐ซ BookRentalShop <br/>
- C# Winform์ ํ์ฉํด ๋์ ๋์ฌ ๊ด๋ฆฌ ํ๋ก๊ทธ๋จ ์์ฑ
- Winform Metro UI Framework ํ์ฉํ UI ๋์์ธ ๊ตฌํ
- ๋ก๊ทธ์ธ, ๋์ ๊ตฌ๋ถ์ฝ๋ ๊ด๋ฆฌ, ๋์๊ด๋ฆฌ, ๋์ฌ๊ด๋ฆฌ ๊ธฐ๋ฅ์ ๋ฃ์ ํผ ์์ฑ
- ๊ฐ ํผ๋ง๋ค CRUD(Create, Read, Update, Delete) ๋ฒํผ ์ด๋ฒคํธ ์์ฑ
- Winform๊ณผ DB ์ฐ๊ฒฐ์ ์ํด SQL Server์ฐ๋(SqlConnection ํด๋์ค ์ ์ธ, SqlCommand๋ก ์ฟผ๋ฆฌ๋ฌธ ์ฌ์ฉ)

-------------------------------------

## ์คํํ๋ฉด <br/>
1. ๋ก๊ทธ์ธ ํผ<br/><br/>
![image](https://user-images.githubusercontent.com/77951868/129994158-765c57f9-2d44-4468-8f6f-4ce2e426f669.png)<br/>
- ๋ก๊ทธ์ธ ํผ ์๋ ฅ๊ฐ์ null ์ฌ๋ถ ์ฒดํฌ
 ```c#
  if (string.IsNullOrEmpty(TxtUserID.Text) || string.IsNullOrEmpty(TxtPassword.Text))
              {
                  MetroMessageBox.Show(this,"์์ด๋/ํจ์ค์๋๋ฅผ ์๋ ฅํ์ธ์!","์ค๋ฅ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  return;
              }

  ```

- ํ์DB๋ฅผ ๋ถ๋ฌ์ ์๋ ฅํ ๊ฐ๊ณผ ๋น๊ต
```c#
// ์๋ ฅํ userID์ password๊ฐ ์ผ์นํ๋ UserID๋ฅผ ๋ฐ์์ ๋น๊ต
                  var query = "select userID from membertbl " +
                              " where userID = @userID " +
                              " and passwords = @passwords ";

    ......

    strUserId = reader["UserID"] != null ? reader["userID"].ToString() : "";

    if (string.IsNullOrEmpty(strUserId))
                        {
                            MetroMessageBox.Show(this, "์ ์์คํจ", "๋ก๊ทธ์ธ ์คํจ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }

```
<br/> 

2. ๋์ ๊ตฌ๋ถ์ฝ๋ ๊ด๋ฆฌ <br/>
![image](https://user-images.githubusercontent.com/77951868/129998775-4abf3430-40c3-4ef5-acbe-d12f88cf4cdf.png)<br/>
![image](https://user-images.githubusercontent.com/77951868/129994916-ed01a208-e337-4f4d-97c5-95d7cc13b2d1.png)<br/><br/>

3. ๋์๊ด๋ฆฌ <br/><br/>
![image](https://user-images.githubusercontent.com/77951868/129997112-01c8b110-40c4-4351-abf7-dce6a524e78b.png)<br/><br/>

4. ํ์๊ด๋ฆฌ <br/><br/>
![image](https://user-images.githubusercontent.com/77951868/129997910-e7ac5d25-4dd5-460e-8377-7360331b2fbf.png)<br/><br/>

5. ๋์ฌ๊ด๋ฆฌ <br/><br/>
- ๋์ฌํ  ํ์ ์ ํ(ํ์๋ฆฌ์คํธ ํ์)<br/><br/>
![image](https://user-images.githubusercontent.com/77951868/129998809-134b8408-f78c-4f4c-84c6-d9b8f3016fc3.png)<br/><br/>
- ๋์ฌํ  ๋์ ์ ํ(๋์๋ฆฌ์คํธ ํ์)<br/><br/>
![image](https://user-images.githubusercontent.com/77951868/129998823-5b6dcd8f-75cb-4d64-b15c-59aed6f27276.png)<br/><br/>

6. ์ข๋ฃํ๋ฉด<br/><br/>
![image](https://user-images.githubusercontent.com/77951868/129997162-1b87a006-6511-41eb-ba71-3b0382cda02b.png)




















