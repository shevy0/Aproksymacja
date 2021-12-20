﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Aproksymacja
{
    public partial class Form1 : Form
    {
        private List<double[]> chartPoints;
        private int lp;
        private int temp;
        public Form1()
        {
            InitializeComponent();
            textBox_X.Enabled = false;
            textBox_Y.Enabled = false;
            button_addpoint.Enabled = false;
            this.temp = 0;
            //MessageBox.Show("jeśli dis jest pierdolony w ręce klaszcz");
        }

        private void button_lp_accept_Click(object sender, EventArgs e)
        {
            numeric_lp.Enabled = false;
            this.lp = (int)numeric_lp.Value;
            textBox_X.Enabled = true;
            textBox_Y.Enabled = true;
            button_addpoint.Enabled = true;

            this.chartPoints = new List<double[]>();
        }

        private void button_lp_reset_Click(object sender, EventArgs e)
        {
            if (numeric_lp.Enabled == false)
            {
                numeric_lp.Enabled = true;
                numeric_lp.Value = 1;
                textBox_X.Enabled = false;
                textBox_Y.Enabled = false;
                button_addpoint.Enabled = false;
                this.temp = 0;
                richTextBox.Text = "";
                this.chartPoints.Clear();
            }
        }

        private void button_addpoint_Click(object sender, EventArgs e)
        {
            if (textBox_X.Text == "" || textBox_Y.Text == "")
            {
                MessageBox.Show("e dudus wprowadz X i Y");
            }
            else
            {
                if (this.temp < this.lp)
                {
                    this.chartPoints.Add(new double[2] { Double.Parse(textBox_X.Text.Replace(',', '.'), CultureInfo.InvariantCulture), Double.Parse(textBox_Y.Text.Replace(',', '.'), CultureInfo.InvariantCulture) });
                    richTextBox.AppendText("Punkt nr. " + (this.temp + 1) + " (" + this.chartPoints[this.temp][0] + " ; " + this.chartPoints[this.temp][1] + ")" + Environment.NewLine);
                    textBox_X.Text = "";
                    textBox_Y.Text = "";
                    this.temp++;
                    if (this.temp == this.lp)
                    {
                        textBox_X.Enabled = false;
                        textBox_Y.Enabled = false;
                        button_addpoint.Enabled = false;
                    }
                }
            }
        }

        private void textBox_X_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox_X.Text, @"^*[0-9\.]+$").Success)
            {
                MessageBox.Show("Nieprawidłowa wartość!");
                textBox_X.Focus();
                return;
            }
        }

        private void textBox_Y_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox_Y.Text, @"^*[0-9\.]+$").Success)
            {
                MessageBox.Show("Nieprawidłowa wartość!");
                textBox_Y.Focus();
                return;
            }
        }

        private void button_oblicz_Click(object sender, EventArgs e)
        {
            //Adam - obliczanie Sx i Txy
            int sw = Convert.ToInt32(numeric_sw.Value);
            double[,] tab = new double[sw+1, sw + 2];
            richTextBox1.AppendText("Stopień wielomianu: " + sw.ToString() + Environment.NewLine);
            int liczbaS = (sw * 2) + 1;
            int liczbaT = sw + 1;
            double[] sarr = new double[liczbaS];
            double[] tarr = new double[liczbaT];

            for (int i = 0; i < liczbaS; i++)
            {
                double Sx = 0;
                for (int j = 0; j < this.lp; j++)
                {
                    int kolumna = 0;
                    Sx += Math.Pow(this.chartPoints[j][kolumna], i);
                    if (j <= this.lp)
                    {
                        kolumna += 1;
                        sarr[i] = Sx;
                    }
                }
            }
            for (int i = 0; i < liczbaS; i++)
            {
                richTextBox1.AppendText("S" + i + " = " + sarr[i].ToString() + Environment.NewLine);
            }

            for (int i = 0; i < liczbaT; i++)
            {
                double Txy = 0;
                for (int j = 0; j < this.lp; j++)
                {
                    int kolumna = 0;
                    Txy += Math.Pow(this.chartPoints[j][kolumna], i) * this.chartPoints[j][1];
                    if (j <= this.lp)
                    {
                        kolumna += 1;
                        tarr[i] = Txy;
                    }
                }
            }

            for (int i = 0; i < liczbaT; i++)
            {
                richTextBox1.AppendText("t" + i + " = " + tarr[i].ToString() + Environment.NewLine);
            }
            // Kacper - tworzenie macierzy
            for (int i = 0; i <= sw; i++)
            {
                for (int k = 0; k <= sw; k++)
                {
                    tab[i, k] = sarr[k+i];
                }
                tab[i, sw+1] = tarr[i];
            }
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("Macierz:" + Environment.NewLine);
            for (int i = 0; i <= sw; i++)
            {
                for (int j = 0; j <= sw + 1; j++)
                {
                    richTextBox1.AppendText(tab[i, j].ToString()+ "\t");
                }
                richTextBox1.AppendText(Environment.NewLine);
            }
            // Kuba - rozwiązanie układu równań metodą Jordana - Gaussa

        }
    }
}

//            foreach (var a in this.chartPoints)
//{ 
//    MessageBox.Show(a[0].ToString() + " " + a[1].ToString());murzyn garnucvhyvvvvvvvvvvvvvvvvvvvvvvvvvvvv czarni do narni @marcin
// 
