using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Farm_In_Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Optionally set initial target input object
            smartKeyboard1.TargetInputObject = txtUserID;

            // Adding GotFocus event handlers
            this.txtUserID.GotFocus += new EventHandler(TxtUserID_GotFocus);
            this.txtPassword.GotFocus += new EventHandler(TxtPassword_GotFocus);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserID.Text;
            string password = txtPassword.Text;

            // 서버와의 통신으로 사용자 인증을 처리합니다.
            bool isAuthenticated = AuthenticateUser(userId, password);

            if (isAuthenticated)
            {
                FarmSelectionForm farmSelectionForm = new FarmSelectionForm();
                farmSelectionForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인 실패. 사용자 ID 또는 비밀번호를 확인하세요.");
            }
        }

        private bool AuthenticateUser(string userId, string password)
        {
            try
            {
                // 사용자 자격 증명 생성
                Dictionary<string, string> credentials = new Dictionary<string, string>
                {
                    { "userId", userId },
                    { "password", password }
                };

                // 요청 메시지 생성
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://14.51.17.64:8081");
                request.Method = "POST";
                request.ContentType = "application/json";

                // JSON 문자열로 변환
                string json = SerializeDictionary(credentials);

                // 요청 본문에 JSON 문자열을 작성
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(json);
                }

                // 응답 받기
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string responseBody = reader.ReadToEnd();
                        Dictionary<string, object> authenticationResult = DeserializeDictionary(responseBody);

                        // 인증 성공 여부 확인
                        return authenticationResult.ContainsKey("isAuthenticated") && (bool)authenticationResult["isAuthenticated"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
                return false;
            }
        }

        // Dictionary를 JSON 문자열로 직렬화
        private string SerializeDictionary(Dictionary<string, string> dict)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (sb.Length > 1)
                    sb.Append(",");
                sb.AppendFormat("\"{0}\":\"{1}\"", kvp.Key, kvp.Value);
            }
            sb.Append("}");
            return sb.ToString();
        }

        // JSON 문자열을 Dictionary로 역직렬화
        private Dictionary<string, object> DeserializeDictionary(string json)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            json = json.Trim(new char[] { '{', '}' });
            string[] pairs = json.Split(new char[] { ',' });

            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split(new char[] { ':' });
                if (keyValue.Length == 2) // Ensure there are exactly two elements
                {
                    string key = keyValue[0].Trim(new char[] { '\"' });
                    string value = keyValue[1].Trim(new char[] { '\"' });
                    dict.Add(key, value);
                }
            }

            return dict;
        }

        private void TxtUserID_GotFocus(object sender, EventArgs e)
        {
            smartKeyboard1.TargetInputObject = txtUserID;
        }

        private void TxtPassword_GotFocus(object sender, EventArgs e)
        {
            smartKeyboard1.TargetInputObject = txtPassword;
        }
    }
}
