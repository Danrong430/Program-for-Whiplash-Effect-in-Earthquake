using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vibration
{
    class floor
    {
        public double c;
        public double m;
        public double k;
        public int fNumber;

        public floor(double c, double m)
        {
            this.m = m;       
            this.c = c;
        }

        public double calFloorK(memberbar[,]a,int c)
        {
            for(int i=0;i<a.GetLength(1);i++)
            {
                k+=a[c,i].calK();
            }
            this.fNumber=c;
            return k;
        }

    }

}
