using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TJU.AC.LinearAlgebra;
using MLApp;
 

namespace vibration
{
    public class structure
    {
        public int rows;
        public int columns;
        public double[] k=new double[200];
        public double[] m=new double[200];
        public double[] f = new double[200];

        public structure(int rows,int columns)
        {
            this.rows = rows;
            this.columns = columns;

        }

        public void getStiffness(double[] a)
        {
            for (int i = 0; i < this.rows; i++)
            {
                this.k[i] = a[i];
            }
        }

        public void getMass(double[] a)
        {
            for (int i = 0; i < this.rows; i++)
            {
                this.m[i] = a[i];
            }
        }

        public void getForce(double[] a)
        {
            for (int i = 0; i < this.rows; i++)
            {
                this.f[i] = a[i];
            }
        }

        public int max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        public double[,] getMatrixK(structure a)
        {
            
            double[,] b = new double[a.rows, a.rows];
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.rows; j++)
                {
                    if (i == j)
                    {
                        b[i, j] = k[i] + k[i + 1];
                 
                    }
                    else if (i == j + 1 || i == j - 1)
                    {
                        int c = max(i, j);
                        b[i, j] = -k[c];
           
                    }
                    else
                        b[i, j] = 0;
                }
            }
            
            return b;
        }

        public double[,] getMatrixM(structure a, double w)
        {
            double[,] M = new double[a.rows, a.rows];
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.rows ; j++)
                {
                    if (i == j)
                        M[i, j] = w * w * a.m[i];
                    else
                        M[i, j] = 0;
                }
            }
                
            return M;
        }
        public double[,] getMatrixF(structure a)
        {
            double[,] F = new double[a.rows, 1];
            for (int i = 0; i < a.rows; i++)
                F[i, 0] = a.f[i];
            return F;
        }

        public Matrix getA(structure a, double w)
        {
            double[,] b = a.getMatrixK(a);
            double[,] c = a.getMatrixM(a, w);

            Matrix K = b;
            Matrix M = c;
            Matrix F = a.getMatrixF(a);

            Matrix K1 = !(K - M);
            Matrix target = K1 * F;

             return target;
        }
        public Matrix getW(structure a)
        {
            double[,] b = a.getMatrixK(a);
            double[,] c = a.getMatrixM(a, 1);

            Matrix K = b;
            Matrix M = c;
            Matrix M1 = !M;
            Matrix target = K * M1;

            return target;

        }
           


        public void printA(Matrix target,RichTextBox a)
        {
            int i = 0;
            int c;
            for (; i < this.rows; i++)
            {
                c = i + 1;
                a.Text += "第" + c + "层振幅为" + target[i, 0] + '\r';
            }
        }

        public void printW(Matrix target, RichTextBox a)
        {
            int i = 0;
            int c;
            for (; i < this.rows; i++)
            {
                c = i + 1;
                a.Text += "第" + c + "个自振频率为" + Math.Sqrt(target[i, 0]) + '\r';
            }
        }




           



       


    }
}
