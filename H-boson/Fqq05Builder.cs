using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace H_boson
{
    class Fqq05Builder: AbstractBuilder
    {
        public override void buildGraphCos(Series series)
        {
            string filePathCos = @"spin-2-0new.txt";
            List<NCos> listCos = this.NCosFromFile(new StreamReader(filePathCos));
            observedTheory.ListCos = listCos;
            observedTheory.Graphs.Add(new GraphCos(series, listCos));
        }
        public override void buildGraphACE(Series series)
        {
            List<NCos> listCos = observedTheory.ListCos;
            observedTheory.Graphs.Add(new GraphACE(series, listCos));
        }
        public override void buildGraphP(Series series)
        {
            observedTheory.Graphs.Add(new GraphP());
        }
    }
}
