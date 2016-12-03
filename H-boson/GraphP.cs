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
        private double z;
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
                series.Points.AddXY(ace - sigma, 0.00000000000001);
                series.Points.AddXY(ace, 1);
                series.Points.AddXY(ace + sigma, 0.00000000000001);
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
    }
}
