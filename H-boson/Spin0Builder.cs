using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace H_boson
{
    class Spin0Builder: AbstractBuilder
    {
        public override void buildGraphCos(Series series)
        {
            string filePathCos = @"spin-0new.txt";
            List<NCos> listCos = this.NCosFromFile(new StreamReader(filePathCos));
            observedTheory.ListCos = listCos;
            observedTheory.Graphs.Add(new GraphCos(series, listCos));
        }
        public override void buildGraphACE(Series series)
        {
            string filePathAce = @"ace0.txt";
            List<ZAce> listAce = this.ZAceFromFile(new StreamReader(filePathAce));
            observedTheory.ListAce = listAce;
            observedTheory.Graphs.Add(new GraphACE(series, listAce));
        }
        public override void buildGraphP(Series series)
        {
            List<ZAce> listAce = observedTheory.ListAce;
            GraphP graph = new GraphP(series, listAce);
            graph.UpdateZN(0.5, 367);
            observedTheory.Graphs.Add(graph);
        }
    }
}
