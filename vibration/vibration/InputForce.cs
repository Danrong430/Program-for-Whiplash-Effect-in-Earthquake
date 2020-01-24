using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TJU.AC.LinearAlgebra;

namespace vibration
{
    public partial class InputForce : Form
    {
        structure structure;
        public InputForce(structure structure)
        {
            this.structure=structure;
            InitializeComponent();
        }

        private void InputForce_Load(object sender, EventArgs e)
        {
            label1.Text = "请输入作用在第一层至第" + structure.rows + "层的简谐荷载";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] force = new double[200];
            char[] delimStr = { ' ' };
            string[] str = textBox1.Text.ToString().Split(delimStr);

            for (int i = 0; i < str.Length; i++)
            {
                force[i] = double.Parse(str[i]);
            }

            structure.getForce(force);
            MessageBox.Show("输入成功");
            double[,] a = new double[structure.rows, structure.rows];
            double[,] b = new double[structure.rows, structure.rows];
            a = structure.getMatrixK(structure);
            b = structure.getMatrixM(structure,double.Parse(textBox2.Text));
            Matrix c=structure.getA(structure, double.Parse(textBox2.Text));
            Matrix d = structure.getW(structure);
            structure.printA(c, richTextBox1);
            structure.printW(d, richTextBox2);

        }
    }
}
