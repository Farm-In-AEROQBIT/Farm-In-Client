using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Farm_In_Client
{
    public partial class MainForm : Form
    {
        private Timer _dataTimer;
        private Timer _uploadTimer;
        private Timer _statusTimer;
        private Timer _countdownTimer;

        private const int DataInterval = 600000; // 10 minutes
        private const int UploadInterval = 21600000; // 6 hours
        private const int CountdownInterval = 1000; // 1 second
        private const int StatusDisplayDuration = 30000; // 30 seconds
        private const int ErrorDisplayDuration = 120000; // 2 minutes
        private const string ServerUrl = "http://14.51.17.64:8081";
        private bool _showWarning = true;
        private string _farmName;
        private string _barnName = "Barn1"; // Temporary placeholder
        private int _countdownTime = 21600; // Countdown time in seconds (6 hours)
        private bool _dataSent = false; // Indicates if data was sent successfully

        public MainForm(string farmName)
        {
            _farmName = farmName;
            InitializeComponent();
            InitializeTimers();
            InitializeStatus(); // Set the initial status

            // Start the countdown timer immediately
            _countdownTimer.Enabled = true;
        }

        private void InitializeTimers()
        {
            // Initialize Data Timer
            _dataTimer = new Timer();
            _dataTimer.Interval = DataInterval;
            _dataTimer.Tick += new EventHandler(DataTimer_Tick);
            _dataTimer.Enabled = true;

            // Initialize Upload Timer
            _uploadTimer = new Timer();
            _uploadTimer.Interval = UploadInterval;
            _uploadTimer.Tick += new EventHandler(UploadTimer_Tick);
            _uploadTimer.Enabled = true;

            // Initialize Status Timer
            _statusTimer = new Timer();
            _statusTimer.Interval = StatusDisplayDuration;
            _statusTimer.Tick += new EventHandler(StatusTimer_Tick);

            // Initialize Countdown Timer
            _countdownTimer = new Timer();
            _countdownTimer.Interval = CountdownInterval;
            _countdownTimer.Tick += new EventHandler(CountdownTimer_Tick);
        }

        private void InitializeStatus()
        {
            lblStatus.Text = "데이터를 보내기 위한 준비 중입니다.";
            lblCountdown.Text = "다음 전송까지 06:00:00"; // Initialize countdown display
        }

        private void DataTimer_Tick(object sender, EventArgs e)
        {
            ReadAndSaveSensorData();
        }

        private void UploadTimer_Tick(object sender, EventArgs e)
        {
            UploadLogFiles();
        }

        private void ReadAndSaveSensorData()
        {
            try
            {
                string co2Data = ReadSensorData("CO2");
                string nh3Data = ReadSensorData("NH3");
                string tempData = ReadSensorData("Temp");
                string humidityData = ReadSensorData("Humidity");
                string pmData = ReadSensorData("PM");

                string logFileName = _farmName + "_" + _barnName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
                string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), logFileName); // Use 'Personal' for My Documents

                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine("CO2: " + co2Data + ", Time: " + DateTime.Now + ", Barn: " + _barnName + ", Unit: ppm");
                    sw.WriteLine("NH3: " + nh3Data + ", Time: " + DateTime.Now + ", Barn: " + _barnName + ", Unit: ppm");
                    sw.WriteLine("Temp: " + tempData + ", Location: sensorLocation, Time: " + DateTime.Now + ", Barn: " + _barnName + ", Unit: °C");
                    sw.WriteLine("Humidity: " + humidityData + ", Time: " + DateTime.Now + ", Barn: " + _barnName + ", Unit: %");
                    sw.WriteLine("PM: " + pmData + ", Time: " + DateTime.Now + ", Barn: " + _barnName + ", Unit: ppm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("센서 데이터 읽기 오류: " + ex.Message, "오류");
            }
        }

        private string ReadSensorData(string sensorType)
        {
            // 센서 데이터 읽기 로직
            // 센서 값을 읽어오지 못하면 null 반환
            return "sensorData";
        }

        private void UploadLogFiles()
        {
            try
            {
                string[] logFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "*.log"); // Use 'Personal' for My Documents
                bool dataUploaded = false;

                foreach (string file in logFiles)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ServerUrl);
                    request.Method = "POST";
                    request.ContentType = "application/json";

                    string data;
                    using (StreamReader reader = new StreamReader(file))
                    {
                        data = reader.ReadToEnd();
                    }

                    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                    {
                        writer.Write(data);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            File.Move(file, file + ".sent");
                            dataUploaded = true;
                        }
                    }
                }

                if (dataUploaded)
                {
                    _dataSent = true;
                    UpdateStatus("데이터를 보냈습니다.", StatusDisplayDuration);
                }
                else
                {
                    _dataSent = false;
                    UpdateStatus("데이터를 보내지 못했습니다.", ErrorDisplayDuration);
                }
            }
            catch (Exception ex)
            {
                _dataSent = false;
                UpdateStatus("데이터를 보내지 못했습니다.", ErrorDisplayDuration);
                MessageBox.Show("로그 파일 업로드 오류: " + ex.Message, "오류");
            }
        }

        private void UpdateStatus(string message, int duration)
        {
            lblStatus.Text = message;
            _statusTimer.Interval = duration;
            _statusTimer.Enabled = true; // Start the timer
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "데이터를 보내기 위한 준비 중입니다.";
            _statusTimer.Enabled = false; // Stop the timer
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (_countdownTime > 0)
            {
                _countdownTime--;
                int hours = _countdownTime / 3600;
                int minutes = (_countdownTime % 3600) / 60;
                int seconds = _countdownTime % 60;
                lblCountdown.Text = string.Format("다음 전송까지 {0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
            }
            else
            {
                lblCountdown.Text = "전송 준비 완료";
                _countdownTimer.Enabled = false; // Stop the timer
            }
        }

        private void btnForceUpload_Click(object sender, EventArgs e)
        {
            UploadLogFiles();
            _uploadTimer.Enabled = false;
            _uploadTimer.Enabled = true; // 6시간 간격 초기화
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            // 메시지 박스를 보여주고 사용자의 응답을 받음
            DialogResult result = MessageBox.Show(
                "파일과 데이터의 손상이 있을 수 있습니다. 그럼에도 재시작 하시겠습니까?", // 메시지
                "경고" // 제목
                //MessageBoxButtons.OKCancel, // 버튼 옵션
                //MessageBoxIcon.Exclamation // 아이콘 옵션
            );

            // 사용자가 'OK'를 클릭하면 재시작 명령 실행
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("shutdown", "/r /t 0"); //restart
            }
            // 취소 버튼 클릭 시 아무 작업도 하지 않음
        }
    }
}
