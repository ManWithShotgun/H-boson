using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace H_boson
{
    class Director
    {
        private AbstractBuilder builder;
        public void setTheoryBuilder(AbstractBuilder theotyBuilder)
        {
            this.builder = theotyBuilder;
        }

        public ObservedTheory getTheory()
        {
            return builder.getObservedTheory();
        }

        public void constructTheory(Series cos, Series ace, Series p)
        {
            builder.createObservedTheory();
            builder.buildGraphCos(cos);
            builder.buildGraphACE(ace);
            builder.buildGraphP(p);
        }
    }
}
