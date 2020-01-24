using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vibration
{
    class memberbar
    {
        public double EI;
        public double L;

        public memberbar(double EI, double L)
        {
            this.EI = EI;
            this.L=L;
        }

        public double calK()
        {
            double k;
            return k = 12 * EI / (L * L * L);
        }
    }
}
