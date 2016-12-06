using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace H_boson
{
    class GraphP: Graph
    {
        private Series series;
        public double z, a, b, c;
        private int n;
        private List<ZAce> listAce;

        public GraphP() { }
        public GraphP(Series series, List<ZAce> listAce)
        {
            this.series = series;
            this.listAce = listAce;
        }
        public void UpdateZN(double z, int n)
        {
            this.z = z;
            this.n = n;
        }
        public void Draw()
        {
            if (listAce != null)
            {
                double ace = SearchAce(this.z);
                double sigma = Sigma(ace);
                //series.Points.AddXY(ace - sigma, 0.00000000000001);
                //series.Points.AddXY(ace, 1);
                //series.Points.AddXY(ace + sigma, 0.00000000000001);
                CalcKoef(ace - sigma, 0.00000000000001, ace, 1, ace + sigma, 0.00000000000001);
                for (double i = -0.9; i < 1.5; i += 0.1)
                {
                    series.Points.AddXY(i, ParablFunc(i));
                }
                //for (double i = ace - sigma * 3; i < ace + sigma * 3; i += 0.1)
                //{
                //    series.Points.AddXY(i, NormalFunc(i));
                //}
            }
        }
        private double Sigma(double ace)
        {
            return Math.Sqrt((1 - Math.Pow(ace, 2.0f)) / n) * 10;
        }
        private double SearchAce(double z)
        {
            foreach (ZAce zace in listAce)
            {
                if (z == zace.Z) return zace.Ace;
            }
            return -100;//exception
        }

        public double GetAce()
        {
            return SearchAce(this.z);
        }

        public double GetSigma()
        {
            return Sigma(SearchAce(this.z));
        }
        public double ParablFunc(double x)
        {
            return (a * x * x + b * x + c);
        }
        public double NormalFunc(double x)
        {
            double step=-((Math.Pow(x-GetAce(),2.0f))/(2*GetSigma()*GetSigma()));
            double a = (1 / (GetSigma() * Math.Sqrt(2 * Math.PI)));
            return a * Math.Exp(step);
        }
        private void CalcKoef(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double preA = y3 - (x3 * (y2 - y1) + x2 * y1 - x1 * y2) / (x2 - x1);
            a = preA / (x3 * (x3 - x1 - x2) + x1 * x2);
            b = (y2 - y1) / (x2 - x1) - a * (x1 + x2);
            c = (x2 * y1 - x1 * y2) / (x2 - x1) + a * x1 * x2;
        }
    }
}
