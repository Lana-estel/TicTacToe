using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using nolik8.Coord;

namespace nolik8
{
    
    public partial class Form2 : Form
    {
        string win = "";
        
        int hod = 0+Dop.Role;
        
        Form1 parent;
        int centr = 0;
        int razr = 0;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.SetDesktopLocation(200, 200);
        }
        public void Okno()
        {
            label1.Text = "Игра окончена!";
            parent.Show();
            parent.SetDesktopLocation(200, 200);
            parent.BringToFront();
            razr++;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AiHard();
        }
        public void Clicker(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            label1.Text = "";
            if (hod % 2 != 1)
            {
                if ((((Button)sender).Text != "X") && (((Button)sender).Text != "O"))
                {
                    ((Button)sender).Text = "X";
                    
                    Proverka(3);
                    hod++;
                    if (hod == 9+Dop.Role)
                    {
                        label2.Text = "Ничья!";
                        label1.Text = "Игра окончена!";
                        if (razr < 1)
                        {
                            Okno();
                        }
                    }
                    else if (razr < 1)
                    {
                        AiHard();
                    }

                }
                else
                {
                    label1.Text = "Эта клетка занята!";
                }
            }
        }
        public void Clicker5(object sender, EventArgs e)
        {
            centr++;
            Clicker(sender, e);
        }
        
        public void AiHard()
        {
            if (hod % 2 == 1)
            {
                Button[,] Butt = new Button[,] { { button1, button2, button3 }, { button4, button5, button6 }, { button7, button8, button9 } };
                label1.Text = "";
                if (centr == 0)
                {
                    button5.Text = "O";
                    hod++;
                    centr++;
                }
                else if (hod == 1)
                {
                    Button[] Corner = new Button[] { button1, button3, button7, button9 };
                    Random rnd = new Random();
                    int k = rnd.Next(0, 3);
                    Corner[k].Text = "O";
                    hod++;

                }
                else if ((hod % 2 == 1) && (Proverka(2) == 1))
                {
                    Proverka(3);
                    hod++;

                }
                else if (((button1.Text == "X") || (button3.Text == "X") || (button7.Text == "X") || (button9.Text == "X")) && (hod == 3) && (button5.Text == "X"))
                {
                    Button[] Corner = new Button[] { button1, button3, button7, button9 };
                    for (int i = 0; i < 4; i++)
                    {
                        if ((Corner[i].Text == "") && (hod == 3))
                        {
                            Corner[i].Text = "O";
                            Proverka(3);
                            hod++;
                        }
                    }
                }

                else if (hod % 2 == 1)
                {
                    Proverka(3);
                    hod += Near(0) * hod % 2;

                }

            }
        }

        public void AiLow()
        {
            label1.Text = "";
            if (centr == 0)
            {
                button5.Text = "O";
                hod++;
                centr++;
            }
            else
            {
                Button[] Buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

                Random rnd = new Random();
                int k = rnd.Next(0, 8);
                for (int i = 0; i <= 8; i++)
                {
                    if ((i == k) && (Buttons[i].Text != "O") && (Buttons[i].Text != "X"))
                    {
                        Buttons[i].Text = "O";
                        Proverka(3);
                        hod++;
                        
                    }
                    else if (i == k)
                    {
                        k = rnd.Next(1, 8);
                        i = 0;
                    }
                }
            }
        }
        public int Near(int hod)
        {
            Button[,] Butt = new Button[,] { { button1, button2, button3 }, { button4, button5, button6 }, { button7, button8, button9 } };
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {

                    if (Butt[i,j].Text=="O")
                    {
                        for (int n=0; n<3; n++)
                        {
                            for (int m=0; m<3; m++)
                            {
                                if (((Math.Abs(i - n) == 1) || ((Math.Abs(i - n) == 0))) && ((Math.Abs(j - m) == 1) || (Math.Abs(j - m) == 0)) && (Butt[n, m].Text == ""))
                                {
                                    Butt[n, m].Text = "O";
                                     return 1;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
        public int Proverka(int shag)
        {

            Form1 form1 = new Form1();
            int sum = 0, dia1 = 0, dia2 = 0;
            int[,] m = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            Button[,] Butt = new Button[,] { { button1, button2, button3 }, { button4, button5, button6 }, { button7, button8, button9 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) //цена клетки
                {
                    if (Butt[i, j].Text == "X")
                    {
                        m[i, j] = 1;
                    }
                    else if (Butt[i, j].Text == "O")
                    {
                        m[i, j] = -1;
                    }
                }
            }
            sum = 0;
            for (int i = 0; i < 3; i++) //горизонтали
            {

                for (int j = 0; j < 3; j++)
                {
                    sum = sum + m[i, j];


                    if ((Math.Abs(sum) == 3) && (shag == 3) && (j == 2))
                    {

                        for (int l = 0; l < 3; l++)
                        {
                            Butt[i, l].BackColor = Color.Red;
                            if(hod%2==0)
                            {
                                win = "Победа X!";
                            }
                            else
                            {
                                win = "Победа O!";
                            }
                        }
                        i = 3;

                        if (razr < 1)
                        {
                            label2.Text = win;
                            Okno();
                            
                        }
                        sum = 0;
                    }
                    else if ((Math.Abs(sum) == 2) && (shag == 2) && (j==2))
                    {
                        if ((sum==-2)&&(j==2))
                        {
                            for (int cikl = 0; cikl < 3; cikl++)
                            {
                                if (m[i, cikl] == 0)
                                {
                                    Butt[i, cikl].Text = "O";
                                    return 1;
                                }
                            }
                        }
                        else if (j==2)
                        {
                            for (int cikl = 0; cikl < 3; cikl++)
                            {
                                if (m[i, cikl] == 0)
                                {
                                    Butt[i, cikl].Text = "O";
                                    return 1;
                                }
                            }
                        }
                    }
                    
                }
                sum = 0;
            }
            
            for (int j = 0; j < 3; j++) //вертикали
            {
                for (int i = 0; i < 3; i++)
                {
                    sum = sum + m[i, j];

                    if ((Math.Abs(sum) == 3) && (shag == 3) && (i == 2) )
                    {

                        for (int l = 0; l < 3; l++)
                        {
                            Butt[l, j].BackColor = Color.Red;
                            if (hod % 2 == 0)
                            {
                                win = "Победа X!";
                            }
                            else
                            {
                                win = "Победа O!";
                            }
                        }
                        i = 3;

                        if (razr < 1)
                        {
                            label2.Text = win;
                            Okno();
                            
                        }
                        sum = 0;
                    }
                    else if ((Math.Abs(sum) == 2) && (shag == 2) && (i == 2) )
                    {
                        if (sum == -2)
                        {
                            for (int cikl = 0; cikl < 3; cikl++)
                            {
                                if (m[cikl, j] == 0)
                                {
                                    Butt[cikl, j].Text = "O";
                                    return 1;
                                }
                            }
                        }
                        else 
                        {
                            for (int cikl = 0; cikl < 3; cikl++)
                            {
                                if (m[cikl, j] == 0)
                                {
                                    Butt[cikl, j].Text = "O";
                                    return 1;
                                }
                            }
                        }
                    }
                     
                }
                sum = 0;
            }
            
            for (int i = 0; i < 3; i++)   //диагональ
            {
                dia1 += m[i, i];
                dia2 += m[i, 2 - i];
            }
            dia1 = Math.Abs(dia1);
            dia2 = Math.Abs(dia2);
            if (((dia1 == 3) || (dia2 == 3)) && (shag == 3))
            {
                for (int a = 0; a < 3; a++)
                {
                    if (dia1 == 3)
                    {
                        Butt[a, a].BackColor = Color.Red;
                        if (hod % 2 == 0)
                        {
                            win = "Победа X!";
                        }
                        else
                        {
                            win = "Победа O!";
                        }
                    }
                    else
                    {
                        Butt[a, 2 - a].BackColor = Color.Red;
                        if (hod % 2 == 0)
                        {
                            win = "Победа X!";
                        }
                        else
                        {
                            win = "Победа O!";
                        }
                    }
                }
                if (!parent.Visible)
                {
                    label2.Text = win;
                    Okno();
                }
                dia1 = 0;
                dia2 = 0;
            }
            else if (((dia1 == 2) || (dia2 == 2)) && (shag == 2))
            {
                if (dia1 == 2)
                {
                    for (int a = 0; a < 3; a++)
                    {
                        if (Butt[a, a].Text == "")
                        {
                            Butt[a, a].Text = "O";
                            return 1;
                        }
                    }
                }
                else if (dia2 == 2)
                {
                    for (int a = 0; a < 3; a++)
                    {
                        if (Butt[a, 2 - a].Text == "")
                        {
                            Butt[a, 2 - a].Text = "O";
                            return 1;
                        }
                    }
                }

                
            }
            

            return 0;
        }
    }
}
