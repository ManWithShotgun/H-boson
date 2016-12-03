using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace H_boson
{
    class GraphACE: Graph
    {
        private Series series;
        private List<ZAce> listPoints;
        public GraphACE() { }
        public GraphACE(Series series, List<NCos> list) 
        {
            this.series = series;
            listPoints = new List<ZAce>();
            for (double i = 0.1; i < 0.9; i += 0.1)
            {
                listPoints.Add(new ZAce(i, this.ACE(i,list)));
            }
        }
        public GraphACE(Series series, List<ZAce> list)
        {
            this.series = series;
            this.listPoints = list;
        }
        private double ACE(double z, List<NCos> list)
        {
            double ce = 0, e = 0;
            foreach (NCos c in list)
            {
                if (c.Cos < z)
                    ce += c.N;
                else
                    e += c.N;

            }
            //double b = ce + e;
            //double g = 1 - b;
            return (ce - e) / (ce + e);
        }
        public void Draw()
        {
            if (listPoints != null)
            {
                foreach (ZAce c in listPoints)
                {
                    series.Points.AddXY(c.Z, c.Ace);
                }
            }
        }
    }
}
