using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace H_boson
{
    public partial class Form1 : Form
    {
        //spin20.List = this.loadFromFile(new StreamReader(@"spin-2-0new.txt"));//red: fqq=0.5
        //spin21.List = this.loadFromFile(new StreamReader(@"spin-2-1new.txt"));//green: fqq=0
        //spin22.List = this.loadFromFile(new StreamReader(@"spin-2-2new.txt"));//blue: fqq=0.75
        int number;
        double z;
        ObservedTheory spin0, spin2;
        List<ObservedTheory> listTheoris = new List<ObservedTheory>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ObservedTheory fqq0, fqq05, fqq075, fqq1;
            Director director = new Director();
            AbstractBuilder builder = new Spin0Builder();

            director.setTheoryBuilder(builder);
            director.constructTheory(chart1.Series[0], chart2.Series[0], chart4.Series[0]);
            spin0 = director.getTheory();
            listTheoris.Add(spin0);
            spin0.Show();

            builder = new Fqq0Builder();
            director.setTheoryBuilder(builder);
            director.constructTheory(chart1.Series[1], chart2.Series[1], chart4.Series[1]);
            fqq0 = director.getTheory();
            listTheoris.Add(fqq0);
            fqq0.Show();
            spin2 = fqq0;

            builder = new Fqq05Builder();
            director.setTheoryBuilder(builder);
            director.constructTheory(chart1.Series[2], chart2.Series[2], chart4.Series[0]);
            fqq05 = director.getTheory();
            listTheoris.Add(fqq05);
            fqq05.Show();


            builder = new Fqq075Builder();
            director.setTheoryBuilder(builder);
            director.constructTheory(chart1.Series[3], chart2.Series[3], chart4.Series[0]);
            fqq075 = director.getTheory();
            listTheoris.Add(fqq075);
            fqq075.Show();


            builder = new Fqq1Builder();
            director.setTheoryBuilder(builder);
            director.constructTheory(chart1.Series[3], chart2.Series[3], chart4.Series[2]);
            fqq1 = director.getTheory();
            listTheoris.Add(fqq1);
            fqq1.Show();

            drawM(new StreamReader(@"myy2.txt"));
            chart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart3.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart3.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart3.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            chart3.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart3.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.ClearGraphCos();
            this.ClearGraphAce();
            this.ClearGraphP();
            number = int.Parse(textBox1.Text);
            z=double.Parse(textBox2.Text);
            foreach(ObservedTheory ot in listTheoris)
            {
                ot.Multip(number);
                ot.UpdateZN(z, number);
                ot.Show();
            }
            if (this.Xsquad())
            {
                label4.Text = "Да";
                label4.ForeColor = Color.Green;
            }
            else
            {
                label4.Text = "Нет";
                label4.ForeColor = Color.Red;
            }
        }

        private void ClearGraphCos()
        {
            foreach (Series s in chart1.Series)
            {
                s.Points.Clear();
            }
        }
        private void ClearGraphAce()
        {
            foreach (Series s in chart2.Series)
            {
                s.Points.Clear();
            }
        }
        private void ClearGraphP()
        {
            foreach (Series s in chart4.Series)
            {
                s.Points.Clear();
            }
        }
        private void drawM(StreamReader file)
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] arr = line.Split(' ');
                chart3.Series[0].Points.AddXY(double.Parse(arr[0]), double.Parse(arr[1]));
            }
            file.Close();
        }

        private bool Xsquad()
        {
            double b=crossPoint(), s1, s2;
            s1 = intergralParabl(spin0.GetAce() - spin0.GetSigma(), b);
            s2 = intergralParabl(b, spin2.GetAce() + spin2.GetSigma());
            //s1 = intergralNormal(spin0.GetAce() - spin0.GetSigma()*3, b);
            //s2 = intergralNormal(b, spin2.GetAce() + spin2.GetSigma()*3);
            double sigmaZ =Math.Abs(((spin0.GetAce())-(spin2.GetAce())))/(spin0.GetSigma());//(12)
            //if (sigmaZ >= 1.96 || z <= -1.96)
            //    return true;
            //return false;
            if (s1+s2<=0.05)
                return true;
            return false;
        }

        private double crossPoint()//вычисление перескчения точек
        {
            GraphP one = spin0.GetGraphP(), two = spin2.GetGraphP();
            double a, b, c;
            a = one.a - two.a;
            b = one.b - two.b;
            c = one.c - two.c;
            double d = b * b - 4 * a * c;
            double x1, x2, y1, y2;
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            y1 = one.a * x1 * x1 + one.b * x1 + one.c;//нужная точка
            y2 = one.a * x2 * x2 + one.b * x2 + one.c;
            return x1;
        }
        private double intergralParabl(double a, double b)
        {
            double h, s, x;
            h = 0.00001;
            s = 0; x = a + h;
            double fa = spin2.GetGraphP().ParablFunc(a);
            double fb = spin2.GetGraphP().ParablFunc(b);
            while (x < b)
            {
                s = s + 4 * spin2.GetGraphP().ParablFunc(x);
                x = x + h;
                s = s + 2 * spin2.GetGraphP().ParablFunc(x);
                x = x + h;
            }
            s = h / 3 * (s + a - b);
            return s;
        }
        private double intergralNormal(double a, double b)
        {
            double h, s, x;
            h = 0.00001;
            s = 0; x = a + h;
            double fa = spin2.GetGraphP().NormalFunc(a);
            double fb = spin2.GetGraphP().NormalFunc(b);
            while (x < b)
            {
                s = s + 4 * spin2.GetGraphP().NormalFunc(x);
                x = x + h;
                s = s + 2 * spin2.GetGraphP().NormalFunc(x);
                x = x + h;
            }
            s = h / 3 * (s + a - b);
            return s;
        }
    }
}
