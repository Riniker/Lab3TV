using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        int n = 0;
        double step = 0.5;
        double sig = 2;
        double m = -2;
        int a = -7;
        int b = 4;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }


        public double[] GetArray(int n)
        {
            double x;
            double[] rands = new double[n];
            for (int i = 0; i < n; i++)
            {
                x = 0;
                for (int j = 0; j < 12; j++)
                    x += rnd.NextDouble();
                x -= 6;
                rands[i] = x;
            }
            return rands;
        }

        public double ToY(double x)
        {
            return sig * x + m;
        }
 
        private void StartButton_Click(object sender, EventArgs e)
        {

            chart1.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            n = Convert.ToInt32(NNumericUpDown1.Value);
            double[] rands = new double[n];
            double[] yArray = new double[n];
            rands = GetArray(n);

            for (int i = 0; i < n; i++)
                yArray[i] = Math.Round(ToY(rands[i])/step)*step;
   

            SortedDictionary<double, int> map = new SortedDictionary<double, int>();
            for (double i = a; i <= b; i += step)
                map.Add(i, 0);

            for (int i = 0; i < n; i++)
            {
                if (yArray[i] >= a && yArray[i] <= b)
                    map[yArray[i]]++;
            }


            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = rands[i];
                dataGridView1.Rows[i].Cells[1].Value = yArray[i];
            }
            for (double i = a; i < b; i +=step)
            {
                chart1.Series[0].Points.AddXY(i, map[i]);
            }          
        }


    }
}
