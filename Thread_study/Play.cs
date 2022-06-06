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


        string _strPlayerName = string.Empty;   
        public string StrPlayerName { get => _strPlayerName; set => _strPlayerName = value; }  //캡슐화(함부로 Name 못 건들이게)

        Thread _thread = null;

        bool _bthreadStop = false;   // Thread Stop을 위한 Flag 생성. while문 벗어나서 정상종료 시켜볼려고

        public Play()
        {
            InitializeComponent();
        }

        public Play(string strPlayerName)
        {
            InitializeComponent();
            lblPlayerName.Text = _strPlayerName = strPlayerName;  //가지고온 PlyerName 넣기
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

            try   //예외처리 try-catch
            {
                int ivar = 0;
                Random rd = new Random();

                
                //while 조건이 True일때 진행 (True && True)
                while (pbarPlayer.Value < 100  && !_bthreadStop)  
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

                if (_bthreadStop)   //true
                    
                {
                    eventdelMessage(this, "중도 포기.. (Thread Stop)");
                }
                else    //false
                {
                    eventdelMessage(this, "완주!! (Thread Complete)");  //Mian Form으로 끝났다고 form이랑 완주!! 넘겨줌 event
                }

            }

            // .Interrupt() 하면 이쪽으로. WaitSleepJoin 을 만나서 잠깐 멈춰진 상태일때 종료
            // .Interrup() 타면 여기로 옴 -> 아직 WaitSleepJoin아니니까 Run()으로 -> 함수에 Thread.Sleep(300); 만남 -> 종료
            catch (ThreadInterruptedException exInterrupt)
            {
                exInterrupt.ToString();
            }
            // .Abort() 하면 이쪽으로
            catch(Exception ex)
            {
                ex.ToString();
            }

        }


        //Thread가 멈추는 타이밍을 찾지 않고 무조건 빠져나간다
       
        public void ThreadAbort()
        {
            if (_thread.IsAlive)   //Thread가 동작 중인지 검사
            {
                _thread.Abort();   // 강제 종료.   // catch(Exception ex)으로 이동해서 강종
            }

        }

        //Thread가 돌다가 멈추는 타이밍을 찾아서 빠져나간다. 
       
        public void ThreadInterrupt()
        {
            if (_thread.IsAlive)
            {                            
                _thread.Interrupt();     // catch(ThreadInterruptedException exInterrupt)
            }
        }

        
        //중단시키고 3초간 대기 <-Thread가 종료 될 때 까지!
        public void ThreadJoin()
        {
            if (_thread.IsAlive)
            {
                _thread.Join(3000);
            }

        }


        // Thread 작동? _thread.IsAlive 확인하러 while로 간다 
        // true로 변경했기 때문에 !_bthreadStop 하면 false가 됨. true && false -> while문 탈출. 
        // !Flag를 이용한 Run() 함수 종료!
        private void btnStop_Click(object sender, EventArgs e)
        {
            //ThreadInterrupt();   

            if (_thread.IsAlive)  
            {
                _bthreadStop = true;
            }

        }
    }
}
