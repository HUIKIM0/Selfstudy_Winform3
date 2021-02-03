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

            if (rdoEdge1.Checked)
            {
                iEdgeOrder = 1;
            }
            else if (rdoEdge2.Checked)
            {
                iEdgeOrder = 2;
            }
            else
            {
                iEdgeOrder = 3;
            }

            // int타입, delegate
            // 도우 rdbtn 이랑 엣지 rdbtn
            fCallBackDelegate(iDowOrder, fDow);
            fCallBackDelegate(iEdgeOrder, fEdge);

            flboxOrderText("----------------------------------");
            flboxOrderText(string.Format("전체 주문가격은 {0}원 입니다", _iTotalPrice));

        }



        /* 도우
            비선택/오리지널 : 1번 (10000원)
            씬 :2번 (11000)원  */
        private int fDow(int iOrder)
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

            flboxOrderText(strOrder);   //주문한거 List에 찍혀야 하니까
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

        //ListBox에 보여주기
        private void flboxOrderText(string strOrderText)
        {
           lboxOrderList.Items.Add(strOrderText);
        }
    }
}
