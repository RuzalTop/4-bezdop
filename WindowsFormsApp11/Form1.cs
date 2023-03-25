using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        static int t = 0;
        static bool tim = false;
        static double[] viv = new double[3];
        static double[] tek = new double[3];
        static int[] per = new int[3];
        public Form1()
        {
            InitializeComponent();
            
            timer1 = new Timer();
            timer1.Interval = 1000; // интервал срабатывания в миллисекундах
            timer1.Tick += timer1_Tick; // подписка на событие Tick
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    per[i] = rand.Next(5, 22);
                }
                else if (i == 1)
                {
                    per[i] = rand.Next(-2, 9);
                }
                if (i == 2)
                {
                    per[i] = (int)(rand.NextDouble() * (24.66) - 22.79);
                }
                tek[i] = rand.Next(100);
                viv[i] = tek[i];
                dataTable1.Columns[i + 1].Caption = "Датчик " + (i + 1).ToString() + " (" + per[i].ToString() + " сек)";
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderText = dataTable1.Columns[col.HeaderText].Caption;
            }
            /*Random rand = new Random();
            for (int i = 0; i <= 2; i++)
            {
                per[i] = rand.Next(9) + 1;
                tek[i] = rand.Next(100);
                viv[i] = tek[i];
                dataTable1.Columns[i + 1].Caption = "Датчик " + (i + 1).ToString() + " (" + per[i].ToString() + " сек)";
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderText = dataTable1.Columns[col.HeaderText].Caption;
            }
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataRow workrow = dataTable1.NewRow();
            for (int j = 1; j <= 3; j++)
            {
                int ost = 0;
                if (per[j - 1] != 0)
                {
                    ost = (t % per[j - 1]);
                }

                if (j == 2)
                {
                    tek[j - 1] = rand.Next(-2, 9);
                }
                else if (j == 3)
                {
                    if (ost == 0)
                    {
                        viv[j - 1] = rand.NextDouble() * (1.87 - (-22.79)) + (-22.79);
                        per[j - 1] = (int)(Math.Abs(viv[j - 1]) + 1);
                    }
                    tek[j - 1] = rand.Next(per[j - 1]);
                    if (tek[j - 1] == per[j - 1])
                    {
                        tek[j - 1] = viv[j - 1];
                    }
                }
                else
                {
                    tek[j - 1] = rand.Next(100);
                    if (ost == 0)
                       
                    {
                        viv[j - 1] = tek[j - 1];
                    }
                }
                workrow[j] = tek[j - 1].ToString();
            }
            workrow[0] = t.ToString();
            dataTable1.Rows.Add(workrow);
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            int i = dataGridView1.RowCount - 1;
            dataGridView1.Rows[i].Selected = true;
            t++;
            /* 
             Random rand = new Random();
            DataRow workrow;
            workrow = dataTable1.NewRow();
            for (int j = 1; j <= 3; j++)
            {
                int ost = (t % per[j - 1]);
                tek[j - 1] = rand.Next(100);
                if (ost == 0)
                {
                    viv[j - 1] = tek[j - 1];
                }
                workrow[j] = tek[j - 1].ToString();//исправление тут
            }
            workrow[0] = t.ToString();
            dataTable1.Rows.Add(workrow);
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            int i = dataGridView1.RowCount - 1;
            dataGridView1.Rows[i].Selected = true;
            t++;
            */

        }
        private void button4_Click(object sender, EventArgs e)
        {

            if (!tim)
            {
                tim = true;
                timer1.Enabled = tim;
                button4.Text = "Выключить";
                // при необходимости MessageBox.Show("Система включена");
            }
            else
            {
                tim = false;
                timer1.Enabled = tim;
                button4.Text = "Включить";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!tim)
            {
                MessageBox.Show("Система выключена");
            }
            else
            {
                MessageBox.Show("Датчик 3 значение " + tek[2].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tim)
            {
                MessageBox.Show("Система выключена");
            }
            else
            {
                MessageBox.Show("Датчик 2 значение " + tek[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!tim)
            {
                MessageBox.Show("Система выключена");
            }
            else
            {
                MessageBox.Show("Датчик 1 значение " + tek[0].ToString());
            }
        }
    }
}


