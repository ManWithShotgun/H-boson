using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_boson
{
    class NCos
    {
        private double n, cos;

        public NCos(double n, double cos)
        {
            this.n = n;
            this.cos = cos;
        }
        public double N
        {
            get { return n; }
            set { this.n = value; }
        }

        public double Cos
        {
            get { return cos; }
            set { this.cos = value; }
        }
    }
}
