using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vibration
{
    public partial class Calstiffness : Form
    {
        structure structure;
        public Calstiffness(structure structure1)
        {
            this.structure=structure1;
            InitializeComponent();
        }

        private void Calstiffness_Load(object sender, EventArgs e)
        {
            label1.Text = "请输入第一层至第" + structure.rows + "层的层间侧移刚度，以空格隔开";
            label2.Text = "请输入第一层至第" + structure.rows + "层的层质量，以空格隔开";
            label2.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
        }
       

        

        private void button1_Click(object sender, EventArgs e)
        {
 
            double[] stiffness=new double[200];
            char[] delimStr = { ' ' };
            string[] str = textBox1.Text.ToString().Split(delimStr);

                for (int i = 0; i < str.Length; i++)
                {
                    stiffness[i] = double.Parse(str[i]);
                }

                structure.getStiffness(stiffness);
                MessageBox.Show("输入成功");
                label2.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] mass = new double[200];
            char[] delimStr = { ' ' };
            string[] str = textBox2.Text.ToString().Split(delimStr);

            for (int i = 0; i < str.Length; i++)
            {
                mass[i] = double.Parse(str[i]);
            }

            structure.getMass(mass);
            MessageBox.Show("输入成功");
            InputForce a = new InputForce(structure);
            a.ShowDialog();
            this.Close();
        }

        
        }
    }


