using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace H_boson
{
    class Fqq1Builder: AbstractBuilder
    {
        public override void buildGraphCos(Series series)
        {
            observedTheory.Graphs.Add(new GraphCos());
        }
        public override void buildGraphACE(Series series)
        {
            string filePathAce = @"aceFqq1.txt";
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
