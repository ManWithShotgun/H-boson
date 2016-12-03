using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_boson
{
    class ZAce
    {
        private double z, ace;

        public ZAce(double z, double ace)
        {
            this.z = z;
            this.ace = ace;
        }
        public double Z
        {
            get { return z; }
            set { this.z = value; }
        }

        public double Ace
        {
            get { return ace; }
            set { this.ace = value; }
        }
    }
}
