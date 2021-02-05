using System;
using System.Windows.Forms;

namespace Selfstudy_Winform3
{
    public partial class Form1 : Form
    {
        public delegate int delFuncDow_Edge(int i);   //int 도우 or int 엣지
        public delegate int delFuncTopping(string strOrder, int Ea);  //string 토핑종류, int 토핑추가횟수
        public delegate object delFuncOrder(object i);  //var, object

        int _iTotalPrice = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /* 주문하기 버튼 */
        private void btnOrder_Click(object sender, EventArgs e)
        {
            delFuncDow_Edge delDow = new delFuncDow_Edge(fDow);   //도우
            delFuncDow_Edge delEdge = new delFuncDow_Edge(fEdge);  //엣지

            delFuncTopping delTopping = null;

            int iDowOrder = 0;
            int iEdgeOrder = 0;

            if (rdoDow1.Checked)
            {
                iDowOrder = 1;
            }
            else if (rdoDow2.Checked)
            {
                iDowOrder = 2;
            }
            //delDow(iDowOrder);

            if (rdoEdge1.Checked)
            {
                iEdgeOrder = 1;
            }
            else if (rdoEdge2.Checked)
            {
                iEdgeOrder = 2;
            }
            else if (!rdoEdge1.Checked && !rdoEdge2.Checked)
            {
                iEdgeOrder = 3;
            }

            //delEdge(iEdgeOrder);

            // fCallBackDelegate 함수에다가 int타입, delegate호출(함수호출이 아님)
            // 도우랑 엣지.
            fCallBackDelegate(iDowOrder, fDow); 
            fCallBackDelegate(iEdgeOrder, fEdge);


            /* 토핑 선택 확인 */
            if (cboxTopping1.Checked)
            {
                delTopping += fTopping1;   //delegate인 delTopping과 함수인 fTopping1 연결.  
            }
            if (cboxTopping2.Checked) delTopping += fTopping2;
            if (cboxTopping3.Checked) delTopping += fTopping3;
            if (!cboxTopping1.Checked && !cboxTopping2.Checked && !cboxTopping3.Checked)
            {
                delTopping = delTopping + fTopping4;
            }


            delTopping("토핑", (int)numEa.Value);


            flboxOrderText("----------------------------------");
            flboxOrderText(string.Format("전체 주문가격은 {0}원 입니다.", _iTotalPrice));
            flboxOrderText("\r\n");

        }



        /* 도우
            비선택/오리지널 : 1번 (10000원)
            씬 :2번 (11000)원  */
        private int fDow(int iOrder)    //iOrder에 iDowOrder 1,2 해준거 들어감
        {
            string strOrder = string.Empty;
            int iPrice = 0; //도우 가격

            if (iOrder == 1)
            {
                iPrice = 10000;
                strOrder = string.Format("도우는 오리지널을 선택 하셨습니다. ({0}원)", iPrice);
            }
            else if (iOrder == 2)
            {
                iPrice = 11000;
                strOrder = string.Format("도우는 씬을 선택 하셨습니다. ({0}원)", iPrice);
            }

            flboxOrderText(strOrder);   //ListBox.Items.Add
            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        /* 엣지
            리치골드 : 1번 (2000원)
            치즈크러스트 : 2번 (3000원)
            엣지변경X 비선택 : 3번 (0원) */
        private int fEdge(int iOrder)
        {
            string strOrder = string.Empty;
            int iPrice = 0; //도우 가격

            if (iOrder == 1)
            {
                iPrice = 2000;
                strOrder = string.Format("엣지는 리치골드를 선택 하셨습니다. ({0}원)", iPrice);
            }
            else if (iOrder == 2)
            {
                iPrice = 3000;
                strOrder = string.Format("엣지는 치즈 크러스트를 선택 하셨습니다. ({0}원)", iPrice);
            }

            else if (iOrder == 3)
            {
                iPrice = 0;
                strOrder = string.Format("엣지는 변경하지 않으셨습니다. ({0}원)", iPrice);
            }

            flboxOrderText(strOrder);
            return _iTotalPrice = _iTotalPrice + iPrice;
        }


        public int fCallBackDelegate(int i, delFuncDow_Edge dFunction)
        {
            return dFunction(i);
        }


        /* 토핑 
           소시지 500원
           치즈 400원 
           감자 300원
           몇개 추가하는지 (EA)도 봐야함 */
        // 소세지
        private int fTopping1(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = 500 * iEa;    // 소세지 가격 * 개수

            strOrder = string.Format("소세지 {0}개를 선택 하셨습니다. ({1}원 (1ea 500원)",iEa,iPrice);
            flboxOrderText(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //치즈
        private int fTopping2(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = 400 * iEa;    // 치즈 가격 * 개수

            strOrder = string.Format("치즈 {0}개를 선택 하셨습니다. ({1}원 (1ea 500원)", iEa, iPrice);
            flboxOrderText(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //감자
        private int fTopping3(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = 500 * iEa;    // 소세지 가격 * 개수

            strOrder = string.Format("소세지 {0}개를 선택 하셨습니다. ({1}원 (1ea 500원)", iEa, iPrice);
            flboxOrderText(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        private int fTopping4(string Order, int Ea)
        {
            string strOrder = string.Empty;
            int iPrice = 0;
            strOrder = string.Format("토핑을 선택하지 않으셨습니다. ({0}원)", iPrice);
            lboxOrderList.Items.Add(strOrder);

            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //ListBox에 보여주기
        private void flboxOrderText(string strOrderText)
        {
           lboxOrderList.Items.Add(strOrderText);
        }
    }
}
