using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_study
{
    public partial class Play : Form
    {
        public delegate int delMessage(object sender, string strResult);  //delegate 선언
        public event delMessage eventdelMessage;


        string _strPlayerName = string.Empty;   //유저이름
        public string StrPlayerName { get => _strPlayerName; set => _strPlayerName = value; }  //캡슐화

        Thread _thread = null;

        public Play()
        {
            InitializeComponent();
        }

        public Play(string strPlayerName)
        {
            InitializeComponent();
            lblPlayerName.Text = _strPlayerName = strPlayerName;  //가지고온 PlyerName을 전역에다가도 넣어줌
        }

        public void fThreadStart()
        {
            // _thread = new Thread(new ThreadStart(Run)); ThreadStart 델리게이트 타입 객체를 생성 후 함수를 넘김
            _thread = new Thread(Run);   // 컴파일러에서 델리게이트 객체를 추론해서 생성 후 생성 후 함수를 넘김 (new ThreadStart 생략)
            // _thread = new Thread(delegate () { Run(); });  // 익명메소드를 사용하여 생성 후 함수를 넘김
            _thread.Start();
        }

        private void Run()
        {
            // ★ UI Control이 자신이 만들어진 Thread가 아닌 다른 Thread에서 접근할 경우 Cross Thread가 발생

            int ivar = 0;
            Random rd = new Random(); 

            while(pbarPlayer.Value < 100)
            {
               

                // ★ 요청한 Thread가 현재 Main Thread에 있는 Control을 엑세스 할 수 있는지 확인
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(delegate ()     //진행상황 그려줄때만 잠시 넘겨줄거임
                    {
                        

                        ivar = rd.Next(1, 11);

                        // progressbar.Value + 랜덤값 => 랜덤으로 값이 증가하게
                        if (pbarPlayer.Value + ivar > 100)
                        {
                            pbarPlayer.Value = 100;
                        }
                        else
                        {
                            pbarPlayer.Value = pbarPlayer.Value + ivar;
                        }
                        lblProcess.Text = string.Format("진행 상황 표시 : {0}%", pbarPlayer.Value);
                        this.Refresh();


                    }));

                    Thread.Sleep(300);  //Thread쪽으로 넘겨주고 얘를 멈춰줌. 
                }
            }
            eventdelMessage(this,"완주!! (Thread Complete)");  //Mian Form으로 끝났다고 form이랑 완주!! 넘겨줌 event
        }
    }
}
