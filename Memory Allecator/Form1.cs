using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Allecator
{
    public partial class form1 : Form
    {
        Graphics dArea;
        Rectangle bblock = new Rectangle(55,0,61,10);
        Rectangle wblock = new Rectangle(56, 11, 60, 25);
        Color clearcolor = form1.DefaultBackColor;
        List<int> holesize = new List<int>();
        List<int> holesizecopy = new List<int>();
        List<int> holeadress = new List<int>();
        List<int> processsize = new List<int>();
        List<bool> holeempty = new List<bool>();
        List<bool> processallocated = new List<bool>();

        int longside = 10, shortside = 2;
         
        

        struct processesallocatedcounter
        {
            public List<int>p;
        }

        processesallocatedcounter[] PAC = new processesallocatedcounter[10];
        int holescounter = 0;

        public form1()
        {
            InitializeComponent();
            dArea = drawingArea.CreateGraphics();
            
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            int a;
            if ((textBox1.Text != "" ) && (textBox2.Text != ""))
            {
                SolidBrush sb = new SolidBrush(Color.Green);
                dArea.FillRectangle(sb, bblock);
                bblock.Y += 36;
                dArea.FillRectangle(sb, bblock);

                a = Convert.ToInt32(textBox2.Text);
                holeadress.Add(a);
                drawnum(a, 0, (bblock.Y - 36));
                a = Convert.ToInt32(textBox1.Text);
                holesize.Add(a);
                holesizecopy.Add(a);
                textBox1.Clear();
                textBox2.Clear();               
                dArea.FillRectangle(sb, 55, 0, 1, 500);
                dArea.FillRectangle(sb, 116, 0, 1, 500);
                drawnum(a, 125, (bblock.Y - 20));
                holeempty.Add(true);

                PAC[holescounter].p = new List<int>();
                holescounter++;
            }
            

        }

        private void draw0(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            V.Y += (2 * longside);
            dArea.FillRectangle(sb, V);
            H.X += longside;
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
            H.X -= longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw1(int x, int y)
        {

            Rectangle H = new Rectangle(x + longside, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw2(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            H.X += longside;
            dArea.FillRectangle(sb, H);
            H.X -= longside;
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw3(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            H.X += longside;
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw4(int x, int y)
        {
            Rectangle V = new Rectangle(x, y + longside, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            H.X += longside;
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw5(int x, int y)
        {
            Rectangle V = new Rectangle(x + shortside, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            V.X -= shortside;
            dArea.FillRectangle(sb, V);
            H.X += longside;
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw6(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
            H.X += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw7(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x + longside, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw8(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
            H.X += longside;
            dArea.FillRectangle(sb, H);
            H.Y -= longside;
            dArea.FillRectangle(sb, H);
        }
        private void draw9(int x, int y)
        {
            Rectangle V = new Rectangle(x, y, longside, shortside);
            Rectangle H = new Rectangle(x, y, shortside, longside);
            SolidBrush sb = new SolidBrush(Color.Black);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            V.Y += (longside);
            dArea.FillRectangle(sb, V);
            dArea.FillRectangle(sb, H);
            H.X += longside;
            dArea.FillRectangle(sb, H);
            H.Y += longside;
            dArea.FillRectangle(sb, H);
        }
        private void drawdigit(int val, int x, int y)
        {
            switch (val)
            {
                case 0:
                    draw0(x, y); break;
                case 1:
                    draw1(x, y); break;
                case 2:
                    draw2(x, y); break;
                case 3:
                    draw3(x, y); break;
                case 4:
                    draw4(x, y); break;
                case 5:
                    draw5(x, y); break;
                case 6:
                    draw6(x, y); break;
                case 7:
                    draw7(x, y); break;
                case 8:
                    draw8(x, y); break;
                case 9:
                    draw9(x, y); break;

            }

        }

        private void Simulate_Click(object sender, EventArgs e)
        {
            string temp, s;
            s = textBox3.Text;
            int indf, indl, l;
            l = s.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s[i] == ' ')
                {
                    indl = i;
                    temp = s.Substring(indf, indl - indf);
                    indf = indl + 1;
                    processsize.Add(Convert.ToInt32(temp));
                    processallocated.Add(false);

                }
                else if (s[i] == ';')
                {
                    indl = i;
                    temp = s.Substring(indf, indl - indf);
                    processsize.Add(Convert.ToInt32(temp));
                    processallocated.Add(false);

                }
            }

            comboBox1.Enabled = false;
            Insert.Enabled = false;
            Simulate.Enabled = false;
            s = comboBox1.Text;
            switch (s)
            {
                case "FirstFit":
                    FirstFit(-1);
                    break;
                case "BestFit":
                    BestFit(-1);
                    break;
                case "WorstFit":
                    WorstFit(-1);
                    break;
            }

            string ss = "";
            int nprocess = processallocated.Count;
            for (int i = 0; i < nprocess; i++)
            {
                if (!processallocated[i])
                {
                    ss += ("p #" + i + " ,");
                }
            }
            labelOUT.Text += ss;

        }

        private void FirstFit(int DP)
        {
            int nholes, nprocess;
            nholes = holesize.Count;
            nprocess = processsize.Count;
            int tempcounter = 0; ;
            for (int i = 0; i < nprocess; i++)
            {
                if (i != DP)
                {
                    for (int j = 0; j < nholes; j++)
                    {
                        if ((processsize[i] <= holesize[j]))
                        {
                            // drawnum(processsize[i], 57, (11 + j * 36));
                            System.Threading.Thread.Sleep(400);
                            processallocated[i] = true;
                            PAC[j].p.Add(processsize[i]);
                            if (holeempty[j])
                            {
                                drawnum(processsize[i], 57, (11 + j * 36));
                            }
                            else
                            {
                                tempcounter = PAC[j].p.Count;
                                longside = 4;
                                shortside = 1;
                                SolidBrush sb1 = new SolidBrush(clearcolor);
                                SolidBrush sb2 = new SolidBrush(Color.Black);
                                wblock.Y += (36 * j);
                                dArea.FillRectangle(sb1, wblock);
                                for (int t = 0; t < tempcounter; t++)
                                {
                                    if (t <= 1)
                                    {
                                        drawnum(PAC[j].p[t], 57, (11 + j * 36 + 12 * t));
                                    }
                                    else if (t > 1)
                                    {
                                        drawnum(PAC[j].p[t], 57 + 25, (11 + j * 36 + 12 * (t - 2)));
                                        dArea.FillRectangle(sb2, 57 + 23, 9 + j * 36, 1, 36);
                                    }
                                }
                            }
                                holesize[j] -= processsize[i];
                                holeempty[j] = false;
                                longside = 10;
                                shortside = 2;
                                wblock.Y = 11;
                                break;

    
                            

                        }
                    }
                }

            }
        }

        private void BestFit (int DP)
        {
            int nholes, nprocess, tempcounter = 0;
            nholes = holesize.Count;
            nprocess = processsize.Count;

            int minsize = int.MaxValue, minindex = -1;

            for (int i = 0; i < nprocess; i++)
            {
                if (i != DP)
                {
                    for (int j = 0; j < nholes; j++)
                    {
                    if ( holesize[j]>= processsize[i] && holesize[j] <minsize )
                        {
                            minsize = holesize[j];
                            minindex = j;
                        }             

                    }
                    if (minsize != int.MaxValue)
                    {
                        //drawnum(processsize[i], 57, (12 + minindex * 36));
                        System.Threading.Thread.Sleep(400);
                        processallocated[i] = true;
                        PAC[minindex].p.Add(processsize[i]);
                        holesize[minindex] -= processsize[i];
                       

                        if (holeempty[minindex])
                        {
                            drawnum(processsize[i], 57, (12 + minindex * 36));
                        }
                        else
                        {
                            tempcounter = PAC[minindex].p.Count;
                            longside = 4;
                            shortside = 1;
                            SolidBrush sb1 = new SolidBrush(clearcolor);
                            SolidBrush sb2 = new SolidBrush(Color.Black);
                            wblock.Y += (36 * minindex);
                            dArea.FillRectangle(sb1, wblock);
                            wblock.Y = 11;

                            for (int t = 0; t < tempcounter; t++)
                            {
                                if (t <= 1)
                                {
                                    drawnum(PAC[minindex].p[t], 57, (11 + minindex * 36 + 12 * t));
                                }
                                else if (t > 1)
                                {
                                    drawnum(PAC[minindex].p[t], 57 + 25, (11 + minindex * 36 + 12 * (t - 2)));
                                    dArea.FillRectangle(sb2, 57 + 23, 9 + minindex * 36, 1, 36);
                                }
                            }

                        }


                        longside = 10;
                        shortside = 2;
                        holeempty[minindex] = false;
                    }
                    minsize = int.MaxValue;
                   
                }
            }
        }


        private void WorstFit(int DP)
        {
            int nholes, nprocess, tempcounter = 0;
            nholes = holesize.Count;
            nprocess = processsize.Count;

            int maxsize = int.MinValue, maxindex = -1;

            for (int i = 0; i < nprocess; i++)
            {
                if (i != DP)
                {
                    for (int j = 0; j < nholes; j++)
                    {
                        if (holesize[j] >= processsize[i] && holesize[j] > maxsize)
                        {
                            maxsize = holesize[j];
                            maxindex = j;
                        }

                    }
                    if( maxsize != int.MinValue)
                    {
                        //drawnum(processsize[i], 57, (12 + maxindex * 36));
                        System.Threading.Thread.Sleep(400);
                        processallocated[i] = true;
                        PAC[maxindex].p.Add(processsize[i]);
                        holesize[maxindex] -= processsize[i];


                        if (holeempty[maxindex])
                        {
                            drawnum(processsize[i], 57, (12 + maxindex * 36));
                        }
                        else
                        {
                            tempcounter = PAC[maxindex].p.Count;
                            longside = 4;
                            shortside = 1;
                            SolidBrush sb1 = new SolidBrush(clearcolor);
                            SolidBrush sb2 = new SolidBrush(Color.Black);
                            wblock.Y += (36 * maxindex);
                            dArea.FillRectangle(sb1, wblock);
                            wblock.Y = 11;

                            for (int t = 0; t < tempcounter; t++)
                            {
                                if (t <= 1)
                                {
                                    drawnum(PAC[maxindex].p[t], 57, (11 + maxindex * 36 + 12 * t));
                                }
                                else if (t > 1)
                                {
                                    drawnum(PAC[maxindex].p[t], 57 + 25, (11 + maxindex * 36 + 12 * (t - 2)));
                                    dArea.FillRectangle(sb2, 57 + 23, 9 + maxindex * 36, 1, 36);
                                }
                            }

                        }


                        longside = 10;
                        shortside = 2;
                        holeempty[maxindex] = false;
                    }
                    maxsize = int.MinValue;


                }
            }
        }


        private void DeAllocate_Click(object sender, EventArgs e)
        {
            DeAllocate.Enabled = false;
            int nholes;
            nholes = holesize.Count;
            
            SolidBrush sb1 = new SolidBrush(clearcolor);
            for (int i = 0; i < nholes; i++)
            {
                dArea.FillRectangle(sb1, wblock);
                wblock.Y += 36;
                holeempty[i] = true;
            }
            wblock.Y = 11;

            ////added to  suport multi process per hole

            // deleting processalocatedcounter lists for dealocation calling this method again and it's global

            int tempdealocSERVANT = 0;
            for (int z = 0; z < holescounter; z++)
            {
                holesize[z] = holesizecopy[z];
                tempdealocSERVANT = PAC[z].p.Count;
                while (tempdealocSERVANT > 0)
                {
                    PAC[z].p.RemoveAt(tempdealocSERVANT - 1);
                    tempdealocSERVANT--;
                }

            }
           // int nprocess = processallocated.Count;
           // for (int i=0;i<nholes;i++) { processallocated[i] = false; }



            int index;
            index = Convert.ToInt16(textBox4.Text);
            string s;
            s = comboBox1.Text;
            System.Threading.Thread.Sleep(400);
            switch (s)
            {
                case "FirstFit":
                    FirstFit(index);
                    break;
                case "BestFit":
                    BestFit(index);
                    break;
                case "WorstFit":
                    WorstFit(index);
                    break;
            }

            

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
        }

        private void drawnum(int val, int x, int y)
        {
            //digitizatio
            int t = 10, t1;
            Stack<int> d = new Stack<int>();
            while (val >= t)
            {
                t1 = val % t;
                t /= 10;
                t1 /= t;
                d.Push(t1);
                val -= t1;
                t *= 100;
            }
            t1 = val % t;
            t /= 10;
            t1 /= t;
            d.Push(t1);

            int c = d.Count;
            int temp = 0;
            for (int i = 0; i < c; i++)
            {
                temp = d.Pop();
                drawdigit(temp, x, y);
                x += (longside + shortside + shortside);
            }



        }



    }
}
