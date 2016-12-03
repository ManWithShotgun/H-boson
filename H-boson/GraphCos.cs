using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace H_boson
{
    class GraphCos: Graph
    {
        private double n = 1;
        private Series series;
        private List<NCos> listPoints;

        public GraphCos() { }
        public GraphCos(Series series, List<NCos> listPoints)
        {
            this.series = series;
            this.listPoints = listPoints;
        }
        public void Multip(double n)
        {
            if (listPoints != null)
            {
                foreach (NCos c in listPoints)
                {
                    c.N /= this.n;
                    c.N *= n;
                }
            }
            this.n = n;
        }

        public void Draw()
        {
            if (listPoints != null)
            {
                foreach (NCos c in listPoints)
                {
                    series.Points.AddXY(c.Cos, c.N);
                }
            }
        }
    }
}
