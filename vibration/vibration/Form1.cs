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
    public partial class Form1 : Form
    {

        structure structure1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public structure getStruc()
        {
            return structure1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = int.Parse(textBox1.Text);
            int columns = int.Parse(textBox2.Text);
            structure structure1 = new structure(rows, columns);
            Calstiffness a = new Calstiffness(structure1);
            a.ShowDialog();
            this.Close();
            MLApp.MLApp matlab = null;
            Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
            string command;
            command = "t=2:0.2:4*pi;y=sin(t);h = plot(t,y)";

            matlab.Visible = 0;
            matlab.Execute(command);
            command = @"print(gcf,   '-djpeg',   '" + @"C:\Users\danrong\Desktop\大学\大二下\结构力学 程序\vibration\vibration" + "\\Test1');close all";//保存图片  
            matlab.Execute(command);  

        }
    }
}
