using System;
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
using System.Windows.Forms.DataVisualization.Charting;
using org.mariuszgromada.math.mxparser;

namespace Aproksymacja
{
    public partial class Form1 : Form
    {
        private List<double[]> chartPoints;
        private int lp;
        private int temp;
        private int sw;
        private double[] wspl;
        public Form1()
        {
            InitializeComponent();
            textBox_X.Enabled = false;
            textBox_Y.Enabled = false;
            button_addpoint.Enabled = false;
            this.temp = 0;
            chart1.Series.Clear();
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
                richTextBox1.Text = "";
                numeric_sw.Value = 0;
            }
        }

        private void button_addpoint_Click(object sender, EventArgs e)
        {
            if (textBox_X.Text == "" || textBox_Y.Text == "")
            {
                MessageBox.Show("Nie wprowadziłeś wartości X i Y!");
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
                MessageBox.Show("Nieprawidłowa wartość! Podaj wartość X");
                textBox_X.Focus();
                return;
            }
        }

        private void textBox_Y_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox_Y.Text, @"^*[0-9\.]+$").Success)
            {
                MessageBox.Show("Nieprawidłowa wartość! Podaj wartość Y");
                textBox_Y.Focus();
                return;
            }
        }

        private void button_oblicz_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //Grzegorz - zabezpieczenia 
            if (this.chartPoints.Count() != this.lp)
            {
                MessageBox.Show("Wprowadziłeś za mało punktów.");
                return;
            }

            this.sw = Convert.ToInt32(numeric_sw.Value);
            if (this.sw > (this.lp - 1))
            {
                MessageBox.Show("Stopień wielomianu jest zbyt wysoki względem ilości podanych punktów.");
                return;
            }

            //Adam - obliczanie Sx i Txy
            double[,] tab = new double[this.sw + 1, this.sw + 2];
            richTextBox1.AppendText("Stopień wielomianu: " + sw.ToString() + Environment.NewLine);
            int liczbaS = (this.sw * 2) + 1;
            int liczbaT = this.sw + 1;
            double[] sarr = new double[liczbaS];
            double[] tarr = new double[liczbaT];
            string mathFormula = "";
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
            for (int i = 0; i <= this.sw; i++)
            {
                for (int k = 0; k <= this.sw; k++)
                {
                    tab[i, k] = sarr[k + i];
                }
                tab[i, this.sw + 1] = tarr[i];
            }
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("Macierz:" + Environment.NewLine);
            for (int i = 0; i <= this.sw; i++)
            {
                for (int j = 0; j <= this.sw + 1; j++)
                {
                    richTextBox1.AppendText(tab[i, j].ToString() + "\t");
                }
                richTextBox1.AppendText(Environment.NewLine);
            }
            // Kuba - rozwiązanie układu równań metodą Jordana - Gaussa

            for (int p = 0; p < this.sw + 1; p++)
            {
                for (int wier = p + 1; wier < this.sw + 1; wier++)
                {
                    double m = tab[wier, p] / tab[p, p];
                    for (int kolum = 0; kolum < this.sw + 1; kolum++)
                    {
                        //działanie na wszystkich komórkach z wiersza
                        tab[wier, kolum] = tab[wier, kolum] - (m * tab[p, kolum]);
                    }
                    tab[wier, this.sw + 1] = tab[wier, this.sw + 1] - (m * tab[p, this.sw + 1]);
                }
            }

            //eliminacja
            double tem = 0; //tymczasowe
            double u = 0; // nieznane
            this.wspl = new double[this.sw + 1]; //tablica z wynikami metody gauassa (czyli x1, x2, x3)

            for (int wier = this.sw; wier >= 0; wier--)
            {
                for (int kolum = this.sw; kolum >= 0; kolum--)
                {
                    if (wier == kolum)
                    {
                        u = tab[wier, kolum];
                        break;
                    }
                    else
                    {
                        tem += tab[wier, kolum] * tab[kolum, this.sw + 1];
                    }
                }

                tab[wier, this.sw + 1] = (tab[wier, this.sw + 1] - tem) / u;
                this.wspl[wier] = tab[wier, this.sw + 1];
                tem = 0;
            }
            //Wyswietlanie wyniku
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("Rozwiązanie macierzy metodą Gaussa-Jordana :" + Environment.NewLine);
            for (int i = 0; i < this.sw + 1; i++)
            {
                richTextBox1.AppendText("x" + i + 1);
                richTextBox1.AppendText(": " + this.wspl[i].ToString() + "\n");
            }

            //Marcin - rysowanie wykresu
            string formula = this._generateFormula();

            chart1.Series.Clear();
            Series ser1 = chart1.Series.Add("P(x, y)");
            Series ser2 = chart1.Series.Add("F(x)");

            ser1.ChartArea = chart1.ChartAreas[0].Name;
            ser1.Name = "P(x, y)";
            ser1.ChartType = SeriesChartType.Point;
            ser1.Color = Color.FromArgb(0, 102, 204);

            ser2.ChartArea = chart1.ChartAreas[0].Name;
            ser2.Name = "F(x)";
            ser2.ChartType = SeriesChartType.Line;
            ser2.Color = Color.Red;

            foreach (var point in this.chartPoints)
            {
                ser1.Points.AddXY(point[0], point[1]);
            }

            for (int i = 0; i < this.chartPoints.Count; i++)
            {
                mathFormula = formula.Replace("x", this.chartPoints[i][0].ToString());
                mathFormula.Replace(",", ".");
                Expression e1 = new Expression(mathFormula);
                ser2.Points.AddXY(Convert.ToDecimal(this.chartPoints[i][0]), e1.calculate());
                mathFormula = "";
            }
        }

        private string _generateFormula()
        {
            string formula = "";

            if (this.sw == 0)
            {
                return this.wspl[0].ToString();
            }
            for (int i = 0; i <= this.sw; i++)
            {
                formula += "(" + this.wspl[i] + "*x^" + i + ")+";
            }
            formula = formula.Remove(formula.Length - 1);
            return formula;
        }

        private void dane_button_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = dane_page;
        }

        private void wykresy_button_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = wykres_page;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void autorzy_button_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = autorzy_page;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shevy0/Aproksymacja");
        }
    }
}
