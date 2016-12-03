using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_boson
{
    class ObservedTheory
    {
        private List<Graph> graphs = new List<Graph>();
        private List<NCos> listCos;
        private List<ZAce> listAce;
        public ObservedTheory()
        {

        }

        public List<Graph> Graphs
        {
            get { return this.graphs; }
            set { this.graphs = value; }
        }
        public List<NCos> ListCos
        {
            get { return this.listCos; }
            set { this.listCos = value; }
        }
        public List<ZAce> ListAce
        {
            get { return this.listAce; }
            set { this.listAce = value; }
        }
        public void Multip(double n)
        {
            GraphCos graphCos = (GraphCos)graphs[0];
            graphCos.Multip(n);
        }
        public void UpdateZN(double z, int n)
        {
            GraphP graphP = (GraphP)graphs[2];
            graphP.UpdateZN(z, n);
        }
        public double GetAce()
        {
            GraphP graphP = (GraphP)graphs[2];
            return graphP.GetAce();
        }
        public double GetSigma()
        {
            GraphP graphP = (GraphP)graphs[2];
            return graphP.GetSigma();
        }
        public void Show()
        {
            foreach(Graph g in graphs)
            {
                g.Draw();
            }
        }
    }
}
