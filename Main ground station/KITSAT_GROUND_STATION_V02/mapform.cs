using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//추가 라이브러리
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;

//v09
namespace KITSAT_GROUND_STATION_V02
{
    public partial class mapform : Form
    {
        /////////// 체크박스 선택용 쓰레드
        Thread select_thread;

        private delegate void ImuPrint(string imu_value);
        private delegate void GpsPrint(string gps_value);
        private delegate void sensorPrint(string sensor_value);
        private delegate void CameraSizePrint(string camera_size);
        private delegate void CameraImagePrint(Image img);
        private delegate void CameraImageSavePrint(Image img);

        Image img3 = null;
        public bool select_thread_toggle = false;

        int old_size=0;
        int new_size;

        int i = 0;

        /////////// 파일 쓰기용 클래스
        StreamWriter F_GPS;
        StreamWriter F_sensor;

        //사이즈 요청 조절    
        public string jpeg;//카메라 데이터 저장
        public string gps_value;//gps 데이터 저장
        public string imu_value;//Imu 데이터 저장
        public string sensor_value;///sendser 데이터 저장
        public string camera_size;

        public byte[] jpeg_byte;//바이트에서 바로 이미지 출력

        //각 체크박스의 토글을 뜻함
        public bool gps_on = false;
        public bool camera_on = false;
        public bool imu_on = false;
        public bool sensor_on = false;

        //데이터 순서 결정
        public bool gps_toggle = false;
        public bool camera_toggle = false;
        public bool imu_toggle = false;
        public bool sensor_toogle = false;

        public bool size_call = true;
        public bool image_call = false;
        public bool camera_start = false;

        string state = "";
        int imagesize = 0;

        //자식폼 선언
        SharpGLForm child = new SharpGLForm();

        ///////// form 선언 ////////////////////////////
        public mapform()
        {
            InitializeComponent();//WINAPI호출
            //시리얼 통신 핸들러
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Data_Received);
            Serial_Init();//시리얼 통신 초기화
         
            //초기 체크박스 값을 우측의 텍스트 박스에 표시
            cmbPort.Text = serialPort1.PortName;
            cmbBaud.Text = Convert.ToString(serialPort1.BaudRate);

            string imagepath = getCurrentDir() + "\\logo.jpg";
        }
        private void mapform_Load(object sender, EventArgs e)
        {
            //통신포트의 자동검색후 체크박스에 출력
            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)cmbPort).Items.Add(str);
            }

            //현재위치의 c.html 로드
            webBrowser1.Navigate(getCurrentDir() + "\\c.html");
            
            //자식폼 초기화, 이벤트 선언, 폼 호출
            child.Show();
            
            //시작시 체크박스 모두 해제
            CameraCheck.Checked = false;
            ImuCheck.Checked = false;
            GpsCheck.Checked = false;
            SensorCheck.Checked = false;
        }
   
        ///////// 데이터 처리 //////////////////////////
        private void Gps_process(string state)
        {
            if (state == "gps")
            {
                serialPort1.WriteLine("g");
                Thread.Sleep(20);
            }
            if (gps_value != null)
                Gps_Outcome(gps_value);
        }
        private void Gps_Outcome(string gps_value)
        {
            char[] Separators = new char[] { ',' };
            object[] arg = new object[2];
            string[] strGPS;
            float weidu, jingdu;

            if (this.gps_original.InvokeRequired)
            {
                GpsPrint d = new GpsPrint(Gps_Outcome);
                this.Invoke(d, new object[] { gps_value });
            }
            else
            {
                try
                {
                    

                    strGPS = gps_value.Split(Separators);
                    //Console.WriteLine(strGPS.Length);

                    if (strGPS.Length > 7)
                    {
                        /*
                        //Debug
                        Console.WriteLine(" 0 : " + strGPS[0]);
                        Console.WriteLine(" 1 : " + strGPS[1]);
                        Console.WriteLine(" 2 : " + strGPS[2]);
                        Console.WriteLine(" 3 : " + strGPS[3]);
                        Console.WriteLine(" 4 : " + strGPS[4]);
                        Console.WriteLine(" 5 : " + strGPS[5]);
                        Console.WriteLine(" 6 : " + strGPS[6]);
                        Console.WriteLine(" 7 : " + strGPS[7]);
                        */

                        //경도와 위도의 값이 있을때 구글맵에 집어넣음
                        if (strGPS[2] != "" && strGPS[4] != "")
                        {
                            char[] Separators2 = new char[] { '.' };
                            string[] web_object = new string[2];

                            float latitude;
                            float longitude;
                            float lati_fi;
                            float longi_fi;
                            float lati_se;
                            float longi_se;

                            //GPS 위도 경도 값 변환
                            latitude = Convert.ToSingle(strGPS[2]);
                            longitude = Convert.ToSingle(strGPS[4]);

                            gps_original.Text = strGPS[9];

                            lati_fi = (int)(latitude / 100);
                            lati_se = latitude % 100;
                            latitude = lati_fi + (lati_se / 60);

                            longi_fi = (int)(longitude / 100);
                            longi_se = longitude % 100;
                            longitude = longi_fi + (longi_se / 60);

                            //필요가 없지 싶은데?
                            weidu = latitude;
                            jingdu = longitude;

                            web_object[0] = Convert.ToString(latitude);
                            gps_latitude.Text = web_object[0];

                            web_object[1] = Convert.ToString(longitude);
                            gps_longitude.Text = web_object[1];

                            //웹 스크팁트 호출
                            arg[0] = (object)web_object[0];
                            arg[1] = (object)web_object[1];
                            webBrowser1.Document.InvokeScript("movemarker", arg);

                            arg[0] = (object)web_object[0];
                            arg[1] = (object)web_object[1];
                            webBrowser1.Document.InvokeScript("flyto", arg);

                            //파일 출력 - 고도가 뭐더라?
                            F_GPS = new StreamWriter("C:\\KITSAT\\GPS.txt");
                            F_GPS.WriteLine(web_object[0] + "," + web_object[1]
                                + "," + strGPS[9]);
                            F_GPS.Close();

                            gps_toggle = true;
                            //Thread.Sleep(50);
                        }
                        else
                        {
                            //Console.WriteLine("GPS value empty");
                            gps_toggle = true;
                            //Thread.Sleep(50);
                        }
                    }
                }//try end
                catch
                {
                    //Debug
                    Console.WriteLine("Fatal Error : gps outcome");
                    //MessageBox.Show("catch in gps outcome");
                }
            }//else end
        }//method end
        private void Imu_process(string state)
        {
            if (state == "imu")
            {
                serialPort1.WriteLine("i");
                Thread.Sleep(20);
            }
                if (imu_value != null)
                this.Imu_Outcome(imu_value);
        }
        private void Imu_Outcome(string imu_value)
        {
            char[] Separators = new char[] { '*', ',' };

            if (this.ImuValue_all.InvokeRequired)
            {
                ImuPrint d = new ImuPrint(Imu_Outcome);
                this.Invoke(d, new object[] { imu_value });
            }
            else
            {
                try
                {
                    this.ImuValue_all.Text = imu_value;
                    string[] imu_array = imu_value.Split(Separators);

                    //Console.WriteLine(imu_array.Length);
                    if (imu_array.Length == 4)
                    {
                        //프로그레스바는 실수와 음수를 미지원
                        if (imu_array[1] != "" && imu_array[2] != "" &&
                            imu_array[3] != "" && imu_array[3] != "-")
                        {
                            ImuValue_x.Text = imu_array[1];
                            progress_x.Value = (int.Parse(imu_array[1].Split('.')[0])) + 200;
                            child.imu_x_gl.Text = Convert.ToString((int)Convert.ToSingle(imu_array[1]));

                            ImuValue_y.Text = imu_array[2];
                            progress_y.Value = (int.Parse(imu_array[2].Split('.')[0])) + 200;
                            child.imu_y_gl.Text = Convert.ToString((int)Convert.ToSingle(imu_array[2]));

                            ImuValue_z.Text = imu_array[3];
                            progress_z.Value = (int.Parse(imu_array[3].Split('.')[0])) + 200;
                            child.imu_z_gl.Text = Convert.ToString((int)Convert.ToSingle(imu_array[3]));
                        }

                        imu_toggle = true;
                        //Thread.Sleep(50);
                    }
                }

                catch
                {
                    //Debug
                    Console.WriteLine("Fatal Error : imu size outcome");
                    //MessageBox.Show("catch in imu outcome");
                }
            }//else end
        }//method end
        private void Sensor_process(string state)
        {
            if (state == "sensor")
            {
                serialPort1.WriteLine("r");
                Thread.Sleep(20);
            }
                if (sensor_value != null)
                Sensor_Outcome(sensor_value);
        }
        private void Sensor_Outcome(string sensor_value)
        {
            char[] Separators = new char[] { '@', ',', ' ' };

            if (this.Humidity_txt.InvokeRequired)
            {
                sensorPrint d = new sensorPrint(Sensor_Outcome);
                this.Invoke(d, new object[] { sensor_value });
            }
            else
            {
                try
                {
                    string[] sensor_array = sensor_value.Split(Separators);

                    //Console.WriteLine(sensor_array.Length);
                    //값 짤림 방지
                    if (sensor_array.Length == 4)
                    {
                        if (Convert.ToInt32(sensor_array[3]) > 100)
                        {
                            Humidity_txt.Text = sensor_array[1];
                            Vocs_txt.Text = sensor_array[3];

                            //파일 출력

                            F_sensor = new StreamWriter("C:\\KITSAT\\sensor.txt");
                            F_sensor.WriteLine(sensor_array[1] + "," +
                                sensor_array[3] + "\r\n");
                            F_sensor.Close();
                            sensor_toogle = true;
                            //Thread.Sleep(50);
                        }
                        else
                        {
                            //Debug
                            //Console.WriteLine("sencond sensor error");
                        }
                    }
                }//try end
                catch
                {
                    //Debug
                    Console.WriteLine("Fatal Error : sensor outcome");
                    //MessageBox.Show("catch in sensor outcome");
                }

            }//else end
        }//method end
        private void Camera_process(string state)
        {
            Thread.Sleep(200);
            if (state == "camera")
            {
                if (size_call == true)
                    SizeCallfunction();

                if (camera_size != null && image_call == true)
                    CameraSize_Outcome(camera_size);

                if (jpeg != null && camera_start == true)
                    CameraImage_Outcome(img3);
            }
        }
        private void SizeCallfunction()
        {
            size_call = false;
            image_call = true;
            camera_start = false;

            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            jpeg = null;

            Console.WriteLine("size call load");
            serialPort1.WriteLine("c");
            Thread.Sleep(300);
        }
        private void CameraSize_Outcome(string camera_size)
        {
            char[] Separators = new char[] { '#' };

            if (call_sizetxt.InvokeRequired)
            {
                CameraSizePrint d = new CameraSizePrint(CameraSize_Outcome);
                this.Invoke(d, new object[] { camera_size });
            }//invoke end
            else
            {
                try
                {
                    string[] size_array = camera_size.Split(Separators);

                    //Console.WriteLine(size_array.Length);
                    if (size_array.Length == 3)
                    {
                        int upper = Int32.Parse(size_array[1], System.Globalization.NumberStyles.HexNumber);
                        int low = Int32.Parse(size_array[2], System.Globalization.NumberStyles.HexNumber);

                        imagesize = (upper * 16 * 16) + low;
                        //call_sizetxt.Text = Convert.ToString(imagesize);

                        jpeg = null;
                        serialPort1.WriteLine("s");
                        size_call = false;
                        image_call = false;
                        camera_start = true;
                        //Thread.Sleep(1000);

                    }
                    else
                    {
                        size_call = true;
                        image_call = false;
                        camera_start = false;
                    }
                }

                catch
                {
                    Console.WriteLine("Fatal Error : camera size outcome");
                   // MessageBox.Show("catch in size outcome");
                }
            }//else end
        }//method end
        private void CameraImage_Outcome(Image img)
        {
            string jpeg_end = "FFD90D0D0A";
            string new_jpeg_end = "";
            string jpeg_start = "FFD8";
            string new_jpeg_start = "";

            if (this.pictureBox1.InvokeRequired)
            {
                CameraImagePrint d = new CameraImagePrint(CameraImage_Outcome);
                this.Invoke(d, new object[] { img });
            }//invoke end
            else
            {
                try
                {
                    Console.WriteLine("imagesize :" + imagesize * 2);
                    Console.WriteLine("jpeg :" + jpeg.Length);

                    new_size = jpeg.Length;

                    if (old_size == new_size)
                    {
                        size_call = true;
                        image_call = false;
                        camera_start = false;
                        serialPort1.DiscardInBuffer();
                        serialPort1.DiscardOutBuffer();
                        Console.WriteLine("jpeg size not changing");
                        //MessageBox.Show("jpeg size not changing");
                    }
                    else
                        old_size = new_size;

                    if (jpeg.Length > 10)
                    {
                        new_jpeg_end = jpeg.Substring((jpeg.Length - 10), 10);
                        new_jpeg_start = jpeg.Substring(0, 4);
                    }

                    if (jpeg_end == new_jpeg_end && jpeg_start == new_jpeg_start
                        && camera_start == true)
                    {
                        //textBox2.Text = Convert.ToString(jpeg.Length);
                        Console.WriteLine("image call\n");

                        Image img3 = StringToImage(jpeg);
                        pictureBox1.Image = img3;
                        jpeg = null;

                        size_call = true;
                        image_call = false;
                        camera_start = false;
                        camera_toggle = true;

                        img3.Save(@"C:\\KITSAT\\1.jpg", ImageFormat.Bmp);
                        Console.WriteLine("\r\n\r\ndata received\r\n\r\n");
                        //Thread.Sleep(400);
                    }
                }//try end
                catch
                {
                    Console.WriteLine("Fatal Error : camera image outcome");
                    //MessageBox.Show("catch in image outcome");
                }
            }//else end
        }//method end      
        ///////// 데이터 처리 //////////////////////////

        ////////// 데이터 수신과 쓰레드에 관한 함수
        private void Data_Received(object sender, SerialDataReceivedEventArgs e)
        {
            //시리얼 포트에서 받아온 바이트크기
            int bytes = serialPort1.BytesToRead;
            //바이트 크기만큼 버퍼사이즈 생성
            byte[] buffer = new byte[bytes];

            try
            {
                serialPort1.Read(buffer, 0, bytes);

                //바이트를 문자로 변환
                string str1 = Encoding.Default.GetString(buffer);

                //Console.WriteLine(str1);
                char value_select = Convert.ToChar(str1.Substring(0,1));

                if (value_select == '*' )//imu
                    imu_value = str1;
                else if (value_select == '$' )//gps
                    gps_value = str1;
                else if (value_select == '#')//camera size
                    camera_size = str1;
                else if (value_select == '@')//sensor
                    sensor_value = str1;
                if(camera_start == true)
                    jpeg += ByteArrayToHexString(buffer);
            }
            catch
            {
                //Console.WriteLine("Error 발생 in Data received");
            }
        }

        //////////// 시리얼 포트 설정에 관련됨 함수 //////////
        //포트설정 체크박스 변경시
        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = cmbPort.Text;//포트네임 변경
         }
        //보우레이트 체크박스 변경시
        private void cmbBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(cmbBaud.Text);//보우레이트변경
        }
        //시리얼 개방
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.Open();
                    btnOpen.Text = "Connected";
                    btnClose.Text = "Close";
                    cmbPort.Enabled = false;
                    cmbBaud.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Can Not Open Port");
                }
            }
            else
            {
                MessageBox.Show("Port Already Opened");
            }
        }
        //시리얼 폐쇄
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
                btnOpen.Text = "Open";
                btnClose.Text = "Exit";
                cmbPort.Enabled = true;
                cmbBaud.Enabled = true;
            }
            else
            {
                this.Close();
            }
        }
        //시리얼 초기설정
        public bool Serial_Init()
        {
            try
            {
                serialPort1.PortName = "COM6";
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;

                serialPort1.ReadTimeout = 200;
                serialPort1.RtsEnable = true;
                return true;
            }
            catch
            {
                MessageBox.Show("Serial init Fail!!");
            }
            return false;
        }
      
        ///////////// 체크박스들 선택되고 비선택 되었을때 ////////////
        private void CameraCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CameraCheck.Checked == true)
            {
                camera_on = true;
            }
            else
            {
                camera_on = false;
            }
        }
        private void ImuCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ImuCheck.Checked == true)
            {
                imu_on = true;
            }
            else
            {
                imu_on = false;
            }
        }
        private void GpsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (GpsCheck.Checked == true)
            {
                gps_on = true;
            }
            else
            {
                gps_on = false;
            }
        }
        private void SensorCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SensorCheck.Checked == true)
            {
                sensor_on = true;
            }
            else
            {
                sensor_on = false;
            }
        }
 
        ///////// 쓰레드 조절 /////////////////////////////////////
        //타이머 시작버튼 타이머가 시작되면 체크박스에 해당하는 값받음
        private void Timer_start_Click_1(object sender, EventArgs e)
        {
            Select_thread_start();
        }
        //정지버튼 누르면 안받음
        private void Timer_Stop_Click(object sender, EventArgs e)
        {
                Select_thread_stop();
        }
        private void Select_thread_start()
        {
            Console.WriteLine("Select_thread start");
            select_thread = new Thread(StartThread);
            select_thread.Start();
            select_thread_toggle = true;
            Console.WriteLine("시작후 스레드상태: {0}", select_thread.ThreadState);
            Console.WriteLine("현재 스레드IsAlive? : {0}", select_thread.IsAlive);
        }
        private void Select_thread_stop()
        {
            size_call = true;
            image_call = false;
            camera_start = false;
            camera_toggle = false;
            Console.WriteLine("정지전 스레드상태: {0}", select_thread.ThreadState);
            select_thread_toggle = false;
            select_thread.Abort();
            Console.WriteLine("정지후 스레드상태: {0}", select_thread.ThreadState);
            Console.WriteLine("현재 스레드IsAlive? : {0}", select_thread.IsAlive);
        }

        ///////// 영상 처리 ////////////////////////////
        public Image StringToImage(string _Image)
        {
            byte[] bitmapData = HexStringToByteArray(_Image);
            MemoryStream ms = new MemoryStream(bitmapData);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder();
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }

            return Result.ToString();
        }
        public static byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 
                                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x0B, 0x0C, 0x0D, 
                                 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }
            return Bytes;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private string getCurrentDir()//현재 폴더 좌표 받아오는 함수
        {
            string curURL = System.IO.Path.GetDirectoryName
                (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            return curURL.Substring(6); //file:\\생략
        }

        private void StartThread()
        {
            while (select_thread_toggle)
            {
                //Thread.Sleep(10);
                int data_flag = 0;

                //모두 off
                if (camera_on == false && gps_on == false
                    && imu_on == false && sensor_on == false)
                    data_flag = 0;

                //한개씩만 on
                else if (camera_on == true && gps_on == false
                    && imu_on == false && sensor_on == false)
                    data_flag = 1;

                else if (camera_on == false && gps_on == true
                    && imu_on == false && sensor_on == false)
                    data_flag = 2;

                else if (camera_on == false && gps_on == false
                    && imu_on == true && sensor_on == false)
                    data_flag = 3;

                else if (camera_on == false && gps_on == false
                    && imu_on == false && sensor_on == true)
                    data_flag = 4;

                //두개씩 on
                else if (camera_on == true && gps_on == true
                && imu_on == false && sensor_on == false)
                    data_flag = 5;

                else if (camera_on == true && gps_on == false
                && imu_on == true && sensor_on == false)
                    data_flag = 6;

                else if (camera_on == true && gps_on == false
                && imu_on == false && sensor_on == true)
                    data_flag = 7;

                else if (camera_on == false && gps_on == true
                && imu_on == true && sensor_on == false)
                    data_flag = 8;

                else if (camera_on == false && gps_on == true
                && imu_on == false && sensor_on == true)
                    data_flag = 9;

                else if (camera_on == false && gps_on == false
                && imu_on == true && sensor_on == true)
                    data_flag = 10;

                //세개씩 on
                else if (camera_on == true && gps_on == true
                && imu_on == true && sensor_on == false)
                    data_flag = 11;

                else if (camera_on == true && gps_on == true
                && imu_on == false && sensor_on == true)
                    data_flag = 12;

                else if (camera_on == true && gps_on == false
                && imu_on == true && sensor_on == true)
                    data_flag = 13;

                else if (camera_on == false && gps_on == true
                && imu_on == true && sensor_on == true)
                    data_flag = 14;

                //4개씩
                else if (camera_on == true && gps_on == true
                && imu_on == true && sensor_on == true)
                    data_flag = 15;

                else
                    Console.WriteLine("Fatal Error : out of case in select thread");

                //한개씩
                if (data_flag == 0) { }

                else if (data_flag == 1)
                {
                    state = "camera";
                    Camera_process(state);
                }
                else if (data_flag == 2)
                {
                    state = "gps";
                    Gps_process(state);
                }
                else if (data_flag == 3)
                {
                    state = "imu";
                    Imu_process(state);
                }
                else if (data_flag == 4)
                {
                    state = "sensor";
                    Sensor_process(state);
                }

                //두개씩
                else if (data_flag == 5)//camera, gps
                {
                    if (state == "" || state == "imu" || state == "sensor")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "gps";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "gps";
                            i++;
                        }
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "camera";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag5");
                }//flag 5 end

                else if (data_flag == 6)//camera, imu
                {
                    if (state == "" || state == "sensor" || state == "gps")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "imu";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "imu";
                            i++;
                        }
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "camera";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag6");
                }//flag 6 end

                else if (data_flag == 7)//camera, sensor
                {
                    if (state == "" || state == "imu" || state == "gps")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "sensor";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "sensor";
                            i++;
                        }
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "camera";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag12");
                }//flag 7 end

                else if (data_flag == 8)//gps, imu
                {
                    if (state == "" || state == "camera" || state == "sensor")
                    {
                        state = "gps";
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "imu";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "gps";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag8");
                }//flag 8 end

                else if (data_flag == 9)//gps, sensor
                {
                    if (state == "" || state == "camera" || state == "imu")
                    {
                        state = "gps";
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "sensor";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "gps";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag9");
                }//flag 9 end

                else if (data_flag == 10)//imu, sensor
                {
                    if (state == "" || state == "camera" || state == "gps")
                    {
                        state = "imu";
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "sensor";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "imu";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag10");
                }//flag 10 end

                //세개씩
                else if (data_flag == 11)//camera, gps, imu
                {
                    if (state == "" || state == "sensor")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "gps";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "gps";
                            i++;
                        }
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "imu";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "camera";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag11");
                }//flag 11 end

                else if (data_flag == 12)//camera, gps, sensor
                {
                    if (state == "" || state == "imu")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "gps";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "gps";
                            i++;
                        }
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "sensor";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "camera";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag12");
                }//flag 12 end

                else if (data_flag == 13)//camera, imu, sensor
                {
                    if (state == "" || state == "gps")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "imu";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "imu";
                            i++;
                        }
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "sensor";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "camera";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag13");
                }//flag 13 end

                else if (data_flag == 14)//gps, imu, sensor
                {
                    if (state == "" || state == "camera")
                    {
                        state = "gps";
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "imu";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "sensor";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "gps";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag14");
                }//flag 14 end

                else if (data_flag == 15)//all device
                {
                    if (state == "")
                    {
                        state = "camera";
                    }

                    else if (state == "camera")
                    {
                        if (i > 100)
                        {

                            Camera_process(state);

                            if (camera_toggle == true)
                            {
                                state = "gps";
                                camera_toggle = false;
                                i = 0;
                            }
                            else
                                state = "camera";
                        }
                        else
                        {
                            state = "gps";
                            i++;
                        }
                    }

                    else if (state == "gps")
                    {
                        Gps_process(state);

                        if (gps_toggle == true)
                        {
                            state = "imu";
                            gps_toggle = false;
                        }
                        else
                            state = "gps";
                    }

                    else if (state == "imu")
                    {
                        Imu_process(state);

                        if (imu_toggle == true)
                        {
                            state = "sensor";
                            imu_toggle = false;
                        }
                        else
                            state = "imu";
                    }

                    else if (state == "sensor")
                    {
                        Sensor_process(state);

                        if (sensor_toogle == true)
                        {
                            state = "camera";
                            sensor_toogle = false;
                        }
                        else
                            state = "sensor";
                    }

                    else
                        Console.WriteLine("Fatal Error : out of case in flag15");

                }//flag 15 end

                else
                    Console.WriteLine("Fatal Error : out of flag in select thread");
            }//while end
        }//method end


    }//From end
}//name space end
