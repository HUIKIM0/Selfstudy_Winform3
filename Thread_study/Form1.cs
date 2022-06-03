using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_study
{
    public partial class Form1 : Form
    {
        private enum enumPlayer
        {
            아이린,      //0
            조이,        
            예리,
            슬기,
            웬디,
        }

        //열었던 Play.cs Form들에 대해 다 가지고 있을 List
        List<Play> lPlay = new List<Play>();        

        int _locationX = 0;
        int _locationY = 0;

        public Form1()
        {
            InitializeComponent();

            _locationX = this.Location.X;  
            _locationY = this.Location.Y;
        }

        // Form1.Designer에서 생성해준 this.FormClosing
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)  //폼닫기(오른쪽상단X)
        {
            foreach (Play Litem in lPlay)   //Play.cs 폼 열어준거 하나씩 꺼내옴
            {
                Litem.ThreadAbort();  // 프로그램 종료직전인 Closing이라서 강제로 Thread해제
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            //Play Form의 X좌표를 현재 Form의 오른쪽 끝에 위치 시키기 위한 작업
            _locationX = this.Location.X + this.Size.Width;
            _locationY = this.Location.Y;

            //Y좌표는 플레이어가 추가 될 때 마다 이전 창과 겹치지 않게 좌표값이 증가되어야함
            for (int i = 0; i < numPlayerCount.Value; i++)       
            {
                Play py = new Play(((enumPlayer)i).ToString());
                py.Location = new Point(_locationX, _locationY + py.Height * i);   //play form의 x좌표, y좌표
                py.eventdelMessage += Py_eventdelMessage;

                py.Show();

                py.fThreadStart();

                lPlay.Add(py);  // 열어준 Form을 List에 넣음

            }
        }

        private int Py_deltestevent(string strResult)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    lboxResult.Items.Add(string.Format("Text : {0}",strResult));
                }));
            }
            return 0;
        }

       // Play.cs에 있는 delegate 메세지 뿌려주기 event받아왔음
        private int Py_eventdelMessage(object sender, string strResult)
        {
            // 요청 한 Thread가 현재 Main Thread 있는 Contorl을 엑세스 할 수 있는지 확인
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(delegate ()
                {
                    //여기서의 sender -> 이 form에 대한거. sender를 play form으로 바꿀 수 있음. 같은 form 형식 이니까
                    Play oPlayerForm = sender as Play;

                    lboxResult.Items.Add(string.Format("Player : {0}, Text : {1}", oPlayerForm.StrPlayerName, strResult));

                }));
            }

            return 0;
        }
    }
}
