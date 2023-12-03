using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChebyshovApproximation
{
    public partial class Form : System.Windows.Forms.Form
    {
        //////////////////////////////////////////////////////////generic variables///////////////////////////////////////////////////////////
        private int func1selector = 0;
        private int func2selector = 0;
        private int func3selector = 0;
        private int func4selector = 0;
        private int eps1selector = 0;
        private int eps2selector = 0;
        private int eps3selector = 0;
        private int acc3selector = 0;
        private int eps4selector = 0;
        private int acc4selector = 0;
        private int acc1 = 4;
        private int acc2 = 0;
        private int acc3 = 0;
        private int acc4 = 0;
        private int accerr = 0;
        private int accerr2 = 0;
        private double[,] funcRecAB1 = { { 1, 4 }, { 0.5, 4.5 }, { 0.01, 1.5 }, { 0.01, 1 }, { -1, 1 }, { 0.0001, 1 }, { -3, 4 }, { 2, 8 } };
        private double[,] funcRecAB2 = { { 1, 4 }, { 0.5, 4.5 }, { 0.01, 1.5 }, { 0.01, 1 }, { 1, 3 }, { 0.01, 2 }, { 0.01, 3 }, { 2, 8 } };
        private double[,] funcRecAB3 = { { 1, 3 }, { 1, 4 }, { 0.5, 4.5 }, { 0.01, 1.5 }, { 0.01, 1 }, { -1, 1 }, { 0.0001, 1 }, { -3, 4 }, { 2, 8 } };
        private double[,] funcRecAB4 = { { 1, 4 }, { 0.5, 4.5 }, { 0.01, 1.5 }, { 0.01, 1 }, { 1, 3 }, { 0.01, 2 }, { 0.01, 3 }, { 2, 8 } };
        List<double> x1Values = new List<double>();
        List<double> func1Values = new List<double>();
        List<double> inter1Values = new List<double>();
        List<double> error1Values = new List<double>();
        List<double> x2Values = new List<double>();
        List<double> func2Values = new List<double>();
        List<double> inter2Values = new List<double>();
        List<double> error2Values = new List<double>();
        List<double> x3Values = new List<double>();
        List<double> func3Values = new List<double>();
        List<double> inter3Values = new List<double>();
        List<double> error3Values = new List<double>();
        List<double> x4Values = new List<double>();
        List<double> func4Values = new List<double>();
        List<double> inter4Values = new List<double>();
        List<double> error4Values = new List<double>();
        //////////////////////////////////////////////////////////generic functions///////////////////////////////////////////////////////////
        private bool NumberDetectTextbox(char c)
        {
            if (c <= '9' && c >= '0' || c == '\b' || c == '.' || c == '-') return true;
            return false;
        }

        ///////////////////////////////////////////////////////////load functions/////////////////////////////////////////////////////////////
        public Form()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            comboBoxEps1.SelectedIndex = 1;
            comboBoxEps2.SelectedIndex = 2;
            comboBoxEps3.SelectedIndex = 1;
            comboBoxAcc3.SelectedIndex = 1;
            comboBoxEps4.SelectedIndex = 1;
            comboBoxAcc4.SelectedIndex = 1;
            comboBoxFunc1.SelectedIndex = 0;
            comboBoxFunc2.SelectedIndex = 0;
            comboBoxFunc3.SelectedIndex = 0;
            comboBoxFunc4.SelectedIndex = 0;
            comboBoxType1.SelectedIndex = 0;
            comboBoxType2.SelectedIndex = 0;
        }
        /////////////////////////////////////////////////////////////tab 1////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////textboxes and buttons formatting//////////////////////////////////////////////////////
        //textBoxa1
        private void textBoxa1_Enter(object sender, EventArgs e)
        {
            if (textBoxa1.Text == "Введіть a")
            {
                textBoxa1.ForeColor = Color.Black;
                textBoxa1.Text = "";
            }
        }
        private void textBoxa1_Leave(object sender, EventArgs e)
        {
            if (textBoxa1.Text == "")
            {
                textBoxa1.ForeColor = Color.LightGray;
                textBoxa1.Text = "Введіть a";
            }
        }
        private void textBoxa1_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec1.Checked) e.Handled = true;
        }
        private void textBoxa1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa1.Text != "" && textBoxa1.Text != "Введіть a" && textBoxb1.Text != "" && textBoxb1.Text != "Введіть b" && textBoxa1.Text != "-" && textBoxb1.Text != "-")
            {
                if (Convert.ToDouble(textBoxa1.Text) < Convert.ToDouble(textBoxb1.Text))
                {
                    buttonEval1.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval1.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval1.BackColor = Color.FromArgb(255, 192, 192);
        }
        //textBoxb1
        private void textBoxb1_Enter(object sender, EventArgs e)
        {
            if (textBoxb1.Text == "Введіть b")
            {
                textBoxb1.ForeColor = Color.Black;
                textBoxb1.Text = "";
            }
        }
        private void textBoxb1_Leave(object sender, EventArgs e)
        {
            if (textBoxb1.Text == "")
            {
                textBoxb1.ForeColor = Color.LightGray;
                textBoxb1.Text = "Введіть b";
            }
        }
        private void textBoxb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec1.Checked) e.Handled = true;
        }
        private void textBoxb1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa1.Text != "" && textBoxa1.Text != "Введіть a" && textBoxb1.Text != "" && textBoxb1.Text != "Введіть b" && textBoxa1.Text != "-" && textBoxb1.Text != "-")
            {
                if (Convert.ToDouble(textBoxa1.Text) < Convert.ToDouble(textBoxb1.Text))
                {
                    buttonEval1.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval1.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval1.BackColor = Color.FromArgb(255, 192, 192);
        }
        //comboBoxFunc1
        private void comboBoxFunc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            func1selector = comboBoxFunc1.SelectedIndex;
            if (checkBoxRec1.Checked)
            {
                textBoxa1.Text = Convert.ToString(funcRecAB1[func1selector, 0]);
                textBoxb1.Text = Convert.ToString(funcRecAB1[func1selector, 1]);
                textBoxa1.ForeColor = Color.Black;
                textBoxb1.ForeColor = Color.Black;
            }
        }
        //checkBoxRec1
        private void checkBoxRec1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRec1.Checked)
            {
                textBoxa1.Text = Convert.ToString(funcRecAB1[func1selector, 0]);
                textBoxb1.Text = Convert.ToString(funcRecAB1[func1selector, 1]);
                textBoxa1.ForeColor = Color.Black;
                textBoxb1.ForeColor = Color.Black;
            }
        }
        //richTextBoxOutput1
        private void richTextBoxOutput1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        ///////////////////////////////////////////////////////////eval///////////////////////////////////////////////////////////////////////
        //eval functions
        private double epsilon1setter()
        {
            switch (eps1selector)
            {
                case 0:
                    acc1 = 4;
                    return 1E-3;
                case 1:
                    acc1 = 6;
                    return 1E-5;
                case 2:
                    acc1 = 9;
                    return 1E-8;
                case 3:
                    acc1 = 12;
                    return 1E-11;
                default:
                    return 1E-5;
            }
        }
        private double function1(double x)
        {
            switch (func1selector)
            {
                case 0:
                    return Math.Exp(0.6 * x) - 1;
                case 1:
                    return Math.Log10(2 * x) - 2;
                case 2:
                    return 3 * Math.Sin(x) + 0.5;
                case 3:
                    return Math.Tan(x) - Math.Sin(x) + 0.3;
                case 4:
                    return Math.Tan(x) / (x + 2);
                case 5:
                    return Math.Log(1 / x) * Math.Sqrt(x);
                case 6:
                    return Math.Sqrt(x * x * x + 2 * x * x - 3 * x + 4);
                case 7:
                    return Math.Log(Math.Cosh(x)) - Math.Tanh(x) + 0.9 * Math.Sin(x);
                default:
                    return -1;
            }
        }
        double power(double x, int y)
        {
            double res = 1;
            for (int i = 0; i < y; i++)
            {
                res *= x;
            }
            return res;
        }
        double[] max_err(double[] arr, int tab1, int m1, double a1, double b1)
        {
            x1Values.Clear();
            func1Values.Clear();
            inter1Values.Clear();
            error1Values.Clear();
            double[] res = { 0, 0 };
            double[] tabs = new double[tab1 + 1];
            for (int k = 0; k < tab1 + 1; k++)
            {
                tabs[k] = a1 + (b1 - a1) * k / (tab1);
                if (Math.Abs(function1(tabs[k]) - Pm(arr, tabs[k], m1)) > Math.Abs(res[0]))
                {
                    res[0] = function1(tabs[k]) - Pm(arr, tabs[k], m1);
                    res[1] = tabs[k];
                }
                x1Values.Add(tabs[k]);
                func1Values.Add(function1(tabs[k]));
                inter1Values.Add(Pm(arr, tabs[k], m1));
                error1Values.Add(function1(tabs[k]) - Pm(arr, tabs[k], m1));
            }
            return res;
        }
        double Pm(double[] coef, double x, int m1)
        {
            double res = coef[0];
            for (int i = 1; i < m1 + 1; i++)
            {
                res += power(x, i) * coef[i];
            }
            return res;
        }
        double rho(double z, double[] arr, int m1)
        {
            return function1(z) - Pm(arr, z, m1);
        }
        void slar_out(double[,] arr, int m1)
        {
            for (int i = 0; i < m1 + 1; i++)
            {
                richTextBoxOutput1.Text += String.Format("     a[{0}]{1," + (acc1 - 2) + "}", i, " ");
            }
            richTextBoxOutput1.Text += String.Format("{0,10:S}", "mu[z]");
            richTextBoxOutput1.Text += String.Format("{0," + (acc1 + 6) + ":S}\n", "f[z]");

            for (int i = 0; i < m1 + 2; i++)
            {
                for (int k = 0; k < m1 + 3; k++)
                {
                    richTextBoxOutput1.Text += String.Format("{0," + (acc1 + 7) + ":F" + (acc1) + "}", arr[i, k]);
                }
                richTextBoxOutput1.Text += ('\n');
            }
        }
        double[,] gauss(double[,] arr, int m1)
        {
            double divider;
            //slar_out(arr, m1);
            //richTextBoxOutput1.Text += String.Format("Прямий хiд:\n");
            for (int iter = 0; iter < m1 + 1; iter++)
            {

                //richTextBoxOutput1.Text += String.Format("iтерацiя {0}", iter + 1);
                for (int i = iter + 1; i < m1 + 2; i++)
                {
                    divider = -arr[i, iter] / arr[iter, iter];
                    for (int k = iter; k < m1 + 3; k++)
                    {
                        arr[i, k] = arr[i, k] + arr[iter, k] * divider;
                    }
                }
                //slar_out(arr, m1);
            }
            //Console.WriteLine("Зворотнiй хiд:");
            for (int i = m1 + 1; i > 0; i--)
            {
                //richTextBoxOutput1.Text += String.Format("iтерацiя {0}\n", m1 + 2 - i);
                arr[i, m1 + 2] = arr[i, m1 + 2] / arr[i, i];
                arr[i, i] = 1;
                for (int k = i - 1; k >= 0; k--)
                {
                    arr[k, m1 + 2] = arr[k, m1 + 2] - arr[k, i] * arr[i, m1 + 2];
                    arr[k, i] = 0;
                }
                //slar_out(arr, m1);
            }
            //slar_out(arr, m1);
            return arr;
        }
        //buttonEval1
        private void buttonEval1_Click(object sender, EventArgs e)
        {
            dataGridViewZ1.DataSource = null;
            dataGridViewF1.DataSource = null;
            dataGridViewMu1.DataSource = null;
            richTextBoxOutput1.Text = "";
            if (buttonEval1.BackColor != Color.FromArgb(192, 255, 192))
            {
                if (textBoxa1.Text == "" || textBoxa1.Text == "Введіть a" || textBoxb1.Text == "" || textBoxb1.Text == "Введіть b") richTextBoxOutput1.Text = "Заповніть поля a та b";
                else richTextBoxOutput1.Text = "Введіть коректні дані в поля a та b:\na i b повиннi бути числами, а < b";
            }
            else
            {

                eps1selector = comboBoxEps1.SelectedIndex;
                double eps1 = epsilon1setter();
                double a1 = Convert.ToDouble(textBoxa1.Text);
                double b1 = Convert.ToDouble(textBoxb1.Text);
                int m1 = Convert.ToInt32(numericUpDownm1.Value);
                int tab1 = 50 * m1;
                int w1 = 1;
                int iter1 = 1;
                bool cont1 = true;
                dataGridViewZ1.ColumnCount = 1;
                dataGridViewZ1.RowCount = m1 + 2;
                dataGridViewZ1.Columns[0].Name = "z[i]";
                dataGridViewF1.ColumnCount = 1;
                dataGridViewF1.RowCount = m1 + 2;
                dataGridViewF1.Columns[0].Name = "f(z[i])";
                dataGridViewMu1.ColumnCount = 1;
                dataGridViewMu1.RowCount = m1 + 3;
                dataGridViewMu1.Columns[0].Name = "mu[i]";
                for (int i = 0; i < m1 + 2; i++)
                {
                    dataGridViewZ1.Rows[i].Cells[0].Value = ("z[" + i + "]");
                    dataGridViewF1.Rows[i].Cells[0].Value = ("f(z[" + i + "])");
                    dataGridViewMu1.Rows[i].Cells[0].Value = ("mu[" + i + "]");
                }
                dataGridViewMu1.Rows[m1 + 2].Cells[0].Value = ("rho[j]");
                double[] z_old1 = new double[m1 + 2];
                for (int k = 0; k < m1 + 2; k++)
                {
                    z_old1[k] = a1 + (b1 - a1) * k / (m1 + 1);
                }
                richTextBoxOutput1.Text += comboBoxFunc1.Text;
                richTextBoxOutput1.Text += ("\nх є [" + Math.Round(a1, acc1) + ", " + Math.Round(b1, acc1) + "]\n");
                richTextBoxOutput1.Text += ("m = " + m1 + "\n");
                richTextBoxOutput1.Text += String.Format("eps = {0}\n", eps1);
                while (cont1)
                {
                    cont1 = false;
                    double[] func_z1 = new double[m1 + 2];
                    double[,] slar_res1 = new double[m1 + 2, m1 + 3];
                    for (int i = 0; i < m1 + 2; i++)
                    {
                        for (int k = 0; k < m1 + 1; k++)
                        {
                            slar_res1[i, k] = power(z_old1[i], k);
                        }
                        slar_res1[i, m1 + 1] = w1 * Math.Pow(-1, i);
                        slar_res1[i, m1 + 2] = function1(z_old1[i]);
                        func_z1[i] = slar_res1[i, m1 + 2];
                    }
                    richTextBoxOutput1.Text += ("\nітерація " + iter1 + ":\n");
                    richTextBoxOutput1.Text += ("точки альтернансу:\n");
                    for (int i = 0; i < m1 + 2; i++)
                    {
                        richTextBoxOutput1.Text += String.Format("z[{0}] = {1}\n", i, Math.Round(z_old1[i], acc1));
                    }
                    richTextBoxOutput1.Text += ("значення функції в точках альтернансу:\n");
                    for (int i = 0; i < m1 + 2; i++)
                    {
                        richTextBoxOutput1.Text += String.Format("f(z[{0}]) = {1}\n", i, Math.Round(function1(z_old1[i]), acc1));
                    }
                    //richTextBoxOutput1.Text += ("СЛАР:\n");
                    //slar_out(slar_res1, m1);
                    gauss(slar_res1, m1);
                    //richTextBoxOutput1.Text += ("розв'язок СЛАР методом Гауса:\n");
                    //slar_out(slar_res1, m1);
                    double[] coef1 = new double[m1 + 1];
                    double mu_old = slar_res1[m1 + 1, m1 + 2];
                    for (int i = 0; i < m1 + 1; i++)
                    {
                        coef1[i] = slar_res1[i, m1 + 2];
                        richTextBoxOutput1.Text += String.Format("a[{0}] = {1}\n", i, Math.Round(coef1[i], acc1));
                    }
                    double rho_j1;
                    double x_err1;
                    {
                        double[] result1 = max_err(coef1, tab1, m1, a1, b1);
                        rho_j1 = result1[0];
                        richTextBoxOutput1.Text += String.Format("rho[j] = {0}\n", Math.Round(result1[0], acc1 + 2));
                        x_err1 = result1[1];
                    }
                    richTextBoxOutput1.Text += String.Format("Pm(x) = {0}", Math.Round(coef1[0], acc1));
                    for (int i = 1; i < m1 + 1; i++)
                    {
                        richTextBoxOutput1.Text += String.Format("+ {0}*x^{1}", Math.Round(coef1[i], acc1), i);
                    }
                    if (Math.Abs((Math.Abs(rho_j1) - Math.Abs(mu_old)) / Math.Abs((mu_old))) > eps1)
                    {
                        dataGridViewZ1.Columns.Add(Convert.ToString(iter1), String.Format("ітерація " + iter1));
                        dataGridViewF1.Columns.Add(Convert.ToString(iter1), String.Format("ітерація " + iter1));
                        dataGridViewMu1.Columns.Add(Convert.ToString(iter1), String.Format("ітерація " + iter1));
                        for (int i = 0; i < m1 + 2; i++)
                        {
                            dataGridViewZ1.Rows[i].Cells[iter1].Value = Math.Round(z_old1[i], acc1);
                            dataGridViewF1.Rows[i].Cells[iter1].Value = Math.Round(function1(z_old1[i]), acc1);
                            dataGridViewMu1.Rows[i].Cells[iter1].Value = Math.Round(rho(z_old1[i], coef1, m1), acc1 + 2);
                        }
                        dataGridViewMu1.Rows[m1 + 2].Cells[iter1].Value = Math.Round(Math.Abs(rho_j1), acc1 + 2);
                        richTextBoxOutput1.Text += ("\nзаміна точок альтернансу:\n");
                        cont1 = true;
                        if (x_err1 < z_old1[0])
                        {
                            if (Math.Sign(rho_j1) == Math.Sign(rho(z_old1[0], coef1, m1)))
                            {
                                richTextBoxOutput1.Text += ("z[0]: " + Math.Round(z_old1[0], acc1) + " --> " + Math.Round(x_err1, acc1) + '\n');
                                dataGridViewZ1.Rows[0].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                dataGridViewF1.Rows[0].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                z_old1[0] = x_err1;
                            }
                            else
                            {
                                for (int i = m1 + 1; i > 0; i--)
                                {
                                    richTextBoxOutput1.Text += ("z[" + i + "]: " + Math.Round(z_old1[i], acc1) + " --> " + Math.Round(z_old1[i - 1], acc1) + '\n');
                                    z_old1[i] = z_old1[i - 1];
                                }
                                richTextBoxOutput1.Text += ("z[0]: " + Math.Round(z_old1[0], acc1) + " --> " + Math.Round(x_err1, acc1) + '\n');
                                dataGridViewF1.Rows[0].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                dataGridViewZ1.Rows[0].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                z_old1[0] = x_err1;
                            }
                            iter1++;
                        }
                        else if (x_err1 > z_old1[m1 + 1])
                        {
                            if (Math.Sign(rho_j1) == Math.Sign(rho(z_old1[m1 + 1], coef1, m1)))
                            {
                                richTextBoxOutput1.Text += ("z[" + (m1 + 1) + "]: " + Math.Round(z_old1[m1 + 1], acc1) + " --> " + Math.Round(x_err1, acc1) + '\n');
                                dataGridViewZ1.Rows[m1 + 1].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                dataGridViewF1.Rows[m1 + 1].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                z_old1[m1 + 1] = x_err1;
                            }
                            else
                            {
                                for (int i = 0; i < m1; i++)
                                {
                                    richTextBoxOutput1.Text += ("z[" + i + "]: " + Math.Round(z_old1[i], acc1) + " --> " + Math.Round(z_old1[i + 1], acc1) + '\n');
                                    z_old1[i] = z_old1[i + 1];
                                }
                                richTextBoxOutput1.Text += ("z[" + (m1 + 1) + "]: " + Math.Round(z_old1[m1 + 1], acc1) + " --> " + Math.Round(x_err1, acc1) + '\n');
                                dataGridViewZ1.Rows[m1 + 1].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                dataGridViewF1.Rows[m1 + 1].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                z_old1[m1 + 1] = x_err1;
                            }
                            iter1++;
                        }
                        else if (x_err1 > z_old1[0] && x_err1 < z_old1[m1 + 1])
                        {
                            for (int i = 0; i < m1 + 1; i++)
                            {
                                if (x_err1 > z_old1[i] && x_err1 < z_old1[i + 1])
                                {
                                    if (Math.Sign(rho_j1) == Math.Sign(rho(z_old1[i], coef1, m1)))
                                    {
                                        richTextBoxOutput1.Text += ("z[" + i + "]: " + Math.Round(z_old1[i], acc1) + " --> " + Math.Round(x_err1, acc1) + '\n');
                                        dataGridViewZ1.Rows[i].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                        dataGridViewF1.Rows[i].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                        z_old1[i] = x_err1;
                                    }
                                    else
                                    {
                                        richTextBoxOutput1.Text += ("z[" + (i + 1) + "]: " + Math.Round(z_old1[i], acc1) + " --> " + Math.Round(x_err1, acc1) + '\n');
                                        dataGridViewZ1.Rows[i + 1].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                        dataGridViewF1.Rows[i + 1].Cells[iter1].Style.BackColor = Color.FromArgb(255, 192, 192);
                                        z_old1[i + 1] = x_err1;
                                    }
                                }
                            }
                            iter1++;
                        }
                    }
                    else
                    {
                        dataGridViewZ1.Columns.Add(Convert.ToString(iter1), String.Format("ітерація " + iter1));
                        dataGridViewF1.Columns.Add(Convert.ToString(iter1), String.Format("ітерація " + iter1));
                        dataGridViewMu1.Columns.Add(Convert.ToString(iter1), String.Format("ітерація " + iter1));
                        for (int i = 0; i < m1 + 2; i++)
                        {
                            dataGridViewZ1.Rows[i].Cells[iter1].Value = Math.Round(z_old1[i], acc1);
                            dataGridViewF1.Rows[i].Cells[iter1].Value = Math.Round(function1(z_old1[i]), acc1);
                            dataGridViewMu1.Rows[i].Cells[iter1].Value = Math.Round(rho(z_old1[i], coef1, m1), acc1 + 2);
                        }
                        dataGridViewMu1.Rows[m1 + 2].Cells[iter1].Value = Math.Round(Math.Abs(rho_j1), acc1 + 2);
                        richTextBoxOutput1.Text += ("\n\nОстаточні результати:\n");
                        richTextBoxOutput1.Text += comboBoxFunc1.Text;
                        richTextBoxOutput1.Text += ("\nх є [" + Math.Round(a1, acc1) + ", " + Math.Round(b1, acc1) + "]\n");
                        richTextBoxOutput1.Text += ("m = " + m1 + "\n");
                        richTextBoxOutput1.Text += String.Format("eps = {0}\n", eps1);
                        richTextBoxOutput1.Text += ("кількість ітерацій: " + iter1 + "\n");
                        richTextBoxOutput1.Text += ("точки альтернансу:\n");
                        for (int i = 0; i < m1 + 2; i++)
                        {
                            richTextBoxOutput1.Text += String.Format("z[{0}] = {1:N6}\n", i, z_old1[i]);
                        }
                        for (int i = 0; i < m1 + 2; i++)
                        {
                            richTextBoxOutput1.Text += String.Format("mu[{1}] = {0}\n", Math.Round(rho(z_old1[i], coef1, m1), acc1 + 2), i);
                        }
                        for (int i = 0; i < m1 + 1; i++)
                        {
                            coef1[i] = slar_res1[i, m1 + 2];
                            richTextBoxOutput1.Text += String.Format("a[{0}] = {1}\n", i, Math.Round(coef1[i], acc1));
                        }
                        richTextBoxOutput1.Text += String.Format("Pm(x) = {0}", Math.Round(coef1[0], acc1));
                        for (int i = 1; i < m1 + 1; i++)
                        {
                            richTextBoxOutput1.Text += String.Format("+ {0}*x^{1}", Math.Round(coef1[i], acc1), i);
                        }
                        richTextBoxOutput1.Text += String.Format("\nНайбільша похибка = {0:N6}\n", Math.Round(rho_j1, acc1 + 2));
                        PaintP1(a1, b1, acc1);
                    }
                }
            }
        }
        //////////////////////////////////////////////////////////graphs//////////////////////////////////////////////////////////////////////
        private void buttonZoomReset1_Click(object sender, EventArgs e)
        {
            chartApprox1.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartApprox1.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
            chartError1.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartError1.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
        }
        private void PaintP1(double min, double max, int acc)
        {
            chartApprox1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartApprox1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartApprox1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartApprox1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartApprox1.Invalidate();
            chartError1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartError1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartError1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartError1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartError1.Invalidate();
            chartApprox1.Series["F(x)"].Points.Clear();
            chartApprox1.Series["Pm(x)"].Points.Clear();
            chartError1.Series["F(x) - Pm(x)"].Points.Clear();
            chartApprox1.Series["F(x)"].Points.DataBindXY(x1Values, func1Values);
            chartApprox1.Series["Pm(x)"].Points.DataBindXY(x1Values, inter1Values);
            chartError1.Series["F(x) - Pm(x)"].Points.DataBindXY(x1Values, error1Values);
            ChartArea CAI1 = chartApprox1.ChartAreas[0];
            CAI1.AxisX.ScaleView.Zoomable = true;
            CAI1.AxisY.ScaleView.Zoomable = true;
            CAI1.CursorY.AutoScroll = true;
            CAI1.CursorY.IsUserSelectionEnabled = true;
            CAI1.CursorX.AutoScroll = true;
            CAI1.CursorX.IsUserSelectionEnabled = true;
            ChartArea CAE1 = chartError1.ChartAreas[0];
            CAE1.AxisX.ScaleView.Zoomable = true;
            CAE1.AxisY.ScaleView.Zoomable = true;
            CAE1.CursorY.AutoScroll = true;
            CAE1.CursorY.IsUserSelectionEnabled = true;
            CAE1.CursorX.AutoScroll = true;
            CAE1.CursorX.IsUserSelectionEnabled = true;
            chartApprox1.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartApprox1.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError1.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError1.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));

        }
        /////////////////////////////////////////////////////////////tab 2////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////textboxes and buttons formatting//////////////////////////////////////////////////////
        //textBoxa2
        private void textBoxa2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa2.Text != "" && textBoxa2.Text != "Введіть a" && textBoxb2.Text != "" && textBoxb2.Text != "Введіть b" && textBoxa2.Text != "-" && textBoxb2.Text != "-")
            {
                if (Convert.ToDouble(textBoxa2.Text) < Convert.ToDouble(textBoxb2.Text))
                {
                    buttonEval2.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval2.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval2.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void textBoxa2_Enter(object sender, EventArgs e)
        {
            if (textBoxa2.Text == "Введіть a")
            {
                textBoxa2.ForeColor = Color.Black;
                textBoxa2.Text = "";
            }
        }
        private void textBoxa2_Leave(object sender, EventArgs e)
        {
            if (textBoxa2.Text == "")
            {
                textBoxa2.ForeColor = Color.LightGray;
                textBoxa2.Text = "Введіть a";
            }
        }
        private void textBoxa2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec2.Checked) e.Handled = true;
        }
        //textboxb2
        private void textBoxb2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa2.Text != "" && textBoxa2.Text != "Введіть a" && textBoxb2.Text != "" && textBoxb2.Text != "Введіть b" && textBoxa2.Text != "-" && textBoxb2.Text != "-")
            {
                if (Convert.ToDouble(textBoxa2.Text) < Convert.ToDouble(textBoxb2.Text))
                {
                    buttonEval2.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval2.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval2.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void textBoxb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec2.Checked) e.Handled = true;
        }
        private void textBoxb2_Enter(object sender, EventArgs e)
        {
            if (textBoxb2.Text == "Введіть b")
            {
                textBoxb2.ForeColor = Color.Black;
                textBoxb2.Text = "";
            }
        }
        private void textBoxb2_Leave(object sender, EventArgs e)
        {
            if (textBoxb2.Text == "")
            {
                textBoxb2.ForeColor = Color.LightGray;
                textBoxb2.Text = "Введіть b";
            }
        }
        //comboBoxFunc2
        private void comboBoxFunc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            func2selector = comboBoxFunc2.SelectedIndex;
            if (checkBoxRec2.Checked)
            {
                textBoxa2.Text = Convert.ToString(funcRecAB2[func2selector, 0]);
                textBoxb2.Text = Convert.ToString(funcRecAB2[func2selector, 1]);
                textBoxa2.ForeColor = Color.Black;
                textBoxb2.ForeColor = Color.Black;
            }
        }
        //checkBoxRec2
        private void checkBoxRec2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRec2.Checked)
            {
                textBoxa2.Text = Convert.ToString(funcRecAB2[func2selector, 0]);
                textBoxb2.Text = Convert.ToString(funcRecAB2[func2selector, 1]);
                textBoxa2.ForeColor = Color.Black;
                textBoxb2.ForeColor = Color.Black;
            }
        }
        ///////////////////////////////////////////////////////////eval///////////////////////////////////////////////////////////////////////
        //eval functions
        private double epsilon2setter()
        {
            switch (eps2selector)
            {
                case 0:
                    acc2 = 4;
                    return 1E-3;
                case 1:
                    acc2 = 6;
                    return 1E-5;
                case 2:
                    acc2 = 9;
                    return 1E-8;
                case 3:
                    acc2 = 12;
                    return 1E-11;
                default:
                    return 1E-5;
            }
        }
        private double function2(double x)
        {
            switch (func2selector)
            {
                case 0:
                    return Math.Exp(0.6 * x) - 1;
                case 1:
                    return Math.Log10(2 * x) - 2;
                case 2:
                    return 3 * Math.Sin(x) + 0.5;
                case 3:
                    return Math.Tan(x) - Math.Sin(x) + 0.3;
                case 4:
                    return Math.Cosh(x) - 1.5 * Math.Sin(x);
                case 5:
                    return Math.Exp(Math.Sin(x)) + x;
                case 6:
                    return Math.Log(Math.Abs(Math.Cos(0.5 * x)) + 0.6);
                case 7:
                    return Math.Log(Math.Cosh(x)) - Math.Tanh(x) + 0.9 * Math.Sin(x);
                default:
                    return -1;
            }
        }
        double functionmC(double x, double w, double z0, double z1, double z2)
        {
            return (Math.Pow(z1, x) + Math.Pow(z2, x)) / (Math.Pow(z1, x) + Math.Pow(z0, x)) - w;
        }
        double functionmC(double x, double w, double z0, double z1, double z2, double z3)
        {
            return (Math.Pow(z3, x) - Math.Pow(z1, x)) / (Math.Pow(z2, x) - Math.Pow(z0, x)) - w;
        }
        double functionmC(double x, double w, double z0, double z1, double z2, double z3, double z4)
        {
            return (((Math.Pow(z4, x) - Math.Pow(z2, x)) * (z3 - z1) - (Math.Pow(z3, x) - Math.Pow(z1, x)) * (z4 - z2))) / (((Math.Pow(z3, x) - Math.Pow(z1, x)) * (z2 - z0) - (Math.Pow(z2, x) - Math.Pow(z0, x)) * (z3 - z1))) - w;
        }
        double functionmC(double x, double w, double z0, double z1, double z2, double z3, double z4, double z5)
        {
            return (((Etha4(3, z3, z5, x) - Etha4(2, z2, z4, x)) / (z5 + z3 - z4 - z2) - (Etha4(2, z2, z4, x) - Etha4(1, z1, z3, x)) / (z4 + z2 - z3 - z1)) / ((Etha4(2, z2, z4, x) - Etha4(1, z1, z3, x)) / (z4 + z2 - z3 - z1) - (Etha4(1, z1, z3, x) - Etha4(0, z0, z2, x)) / (z3 + z1 - z2 - z0))) - w;
        }
        double approx(double a, double v, double x)
        {
            return a * Math.Pow(x, v);
        }
        double approx(double a, double a2, double v, double x)
        {
            return a2 + a * Math.Pow(x, v);
        }
        double approx(double a, double a2, double a3, double v, double x)
        {
            return a2 + a3 * x + a * Math.Pow(x, v);
        }
        double approx(double a, double a2, double a3, double a4, double v, double x)
        {
            return a2 + a3 * x + a4 * x * x + a * Math.Pow(x, v);
        }
        double SecantC(double l, double r, double w, double z0, double z1, double z2, double e)
        {
            while (Math.Abs(l - r) > e)
            {
                l = r - (r - l) * functionmC(r, w, z0, z1, z2) / (functionmC(r, w, z0, z1, z2) - functionmC(l, w, z0, z1, z2));
                r = l - (l - r) * functionmC(l, w, z0, z1, z2) / (functionmC(l, w, z0, z1, z2) - functionmC(r, w, z0, z1, z2));
            }
            return r;
        }
        double SecantC(double l, double r, double w, double z0, double z1, double z2, double z3, double e)
        {
            while (Math.Abs(l - r) > e)
            {
                l = r - (r - l) * functionmC(r, w, z0, z1, z2, z3) / (functionmC(r, w, z0, z1, z2, z3) - functionmC(l, w, z0, z1, z2, z3));
                r = l - (l - r) * functionmC(l, w, z0, z1, z2, z3) / (functionmC(l, w, z0, z1, z2, z3) - functionmC(r, w, z0, z1, z2, z3));
            }
            return r;
        }
        double SecantC(double l, double r, double w, double z0, double z1, double z2, double z3, double z4, double e)
        {
            while (Math.Abs(l - r) > e)
            {
                double fr = functionmC(r, w, z0, z1, z2, z3, z4);
                double fl = functionmC(l, w, z0, z1, z2, z3, z4);
                l = r - (r - l) * fr / (fr - fl);
                r = l - (l - r) * fl / (fl - fr);
            }
            return r;
        }
        double SecantC(double l, double r, double w, double z0, double z1, double z2, double z3, double z4, double z5, double e)
        {
            while (Math.Abs(l - r) > e)
            {
                l = r - (r - l) * functionmC(r, w, z0, z1, z2, z3, z4, z5) / (functionmC(r, w, z0, z1, z2, z3, z4, z5) - functionmC(l, w, z0, z1, z2, z3, z4, z5));
                r = l - (l - r) * functionmC(l, w, z0, z1, z2, z3, z4, z5) / (functionmC(l, w, z0, z1, z2, z3, z4, z5) - functionmC(r, w, z0, z1, z2, z3, z4, z5));
            }
            return r;
        }
        double Searchmaxdev(double a, double b, double v, double A, double tab)
        {
            x2Values.Clear();
            func2Values.Clear();
            inter2Values.Clear();
            error2Values.Clear();
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function2(x) - approx(A, v, x)) > Math.Abs(max))
                {
                    max = function2(x) - approx(A, v, x);
                    x_max = x;
                }
                x2Values.Add(x);
                func2Values.Add(function2(x));
                inter2Values.Add(approx(A, v, x));
                error2Values.Add(function2(x) - approx(A, v, x));
            }
            return x_max;
        }
        double Searchmaxdev(double a, double b, double v, double A, double a2, double tab)
        {
            x2Values.Clear();
            func2Values.Clear();
            inter2Values.Clear();
            error2Values.Clear();
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function2(x) - approx(A, a2, v, x)) > Math.Abs(max))
                {
                    max = function2(x) - approx(A, a2, v, x);
                    x_max = x;
                }
                x2Values.Add(x);
                func2Values.Add(function2(x));
                inter2Values.Add(approx(A, a2, v, x));
                error2Values.Add(function2(x) - approx(A, a2, v, x));
            }
            return x_max;
        }
        double Searchmaxdev(double a, double b, double v, double A, double a2, double a3, double tab)
        {
            x2Values.Clear();
            func2Values.Clear();
            inter2Values.Clear();
            error2Values.Clear();
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function2(x) - approx(A, a2, a3, v, x)) > Math.Abs(max))
                {
                    max = function2(x) - approx(A, a2, a3, v, x);
                    x_max = x;
                }
                x2Values.Add(x);
                func2Values.Add(function2(x));
                inter2Values.Add(approx(A, a2, a3, v, x));
                error2Values.Add(function2(x) - approx(A, a2, a3, v, x));
            }
            return x_max;
        }
        double Searchmaxdev(double a, double b, double v, double A, double a2, double a3, double a4, double tab)
        {
            x2Values.Clear();
            func2Values.Clear();
            inter2Values.Clear();
            error2Values.Clear();
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function2(x) - approx(A, a2, a3, a4, v, x)) > Math.Abs(max))
                {
                    max = function2(x) - approx(A, a2, a3, a4, v, x);
                    x_max = x;
                }
                x2Values.Add(x);
                func2Values.Add(function2(x));
                inter2Values.Add(approx(A, a2, a3, a4, v, x));
                error2Values.Add(function2(x) - approx(A, a2, a3, a4, v, x));
            }
            return x_max;
        }
        double Etha4(int i, double z0, double z2, double v)
        {
            return (Math.Pow(z2, v) - Math.Pow(z0, v)) / (z2 - z0);
        }
        //buttonEval2
        private void buttonEval2_Click(object sender, EventArgs e)
        {
            dataGridViewZ2.DataSource = null;
            dataGridViewF2.DataSource = null;
            dataGridViewMu2.DataSource = null;
            richTextBoxOutput2.Text = "";
            if (buttonEval2.BackColor != Color.FromArgb(192, 255, 192))
            {
                if (textBoxa2.Text == "" || textBoxa2.Text == "Введіть a" || textBoxb2.Text == "" || textBoxb2.Text == "Введіть b") richTextBoxOutput2.Text = "Заповніть поля a та b";
                else richTextBoxOutput2.Text = "Введіть коректні дані в поля a та b:\na i b повиннi бути числами, а < b";
            }
            else
            {
                eps2selector = comboBoxEps2.SelectedIndex;
                double eps2 = epsilon2setter();
                double a2 = Convert.ToDouble(textBoxa2.Text);
                double b2 = Convert.ToDouble(textBoxb2.Text);
                int m2 = Convert.ToInt32(numericUpDownm2.Value);
                int tab2 = 300 * m2;
                richTextBoxOutput2.Text += String.Format("x є (" + a2 + "; " + b2 + ")\n");
                richTextBoxOutput2.Text += String.Format("m = " + m2 + '\n');
                double[] point = new double[m2 + 2];
                double[] func_p = new double[m2 + 2];
                for (int i = 0; i < m2 + 2; i++)
                {
                    point[i] = a2 + (i * (b2 - a2) / (m2 + 1));
                }
                dataGridViewZ2.ColumnCount = 1;
                dataGridViewZ2.RowCount = m2 + 2;
                dataGridViewZ2.Columns[0].Name = "z[i]";
                dataGridViewF2.ColumnCount = 1;
                dataGridViewF2.RowCount = m2 + 2;
                dataGridViewF2.Columns[0].Name = "f(z[i])";
                dataGridViewMu2.ColumnCount = 1;
                dataGridViewMu2.RowCount = m2 + 3;
                dataGridViewMu2.Columns[0].Name = "mu[i]";
                for (int i = 0; i < m2 + 2; i++)
                {
                    dataGridViewZ2.Rows[i].Cells[0].Value = ("z[" + i + "]");
                    dataGridViewF2.Rows[i].Cells[0].Value = ("f(z[" + i + "])");
                    dataGridViewMu2.Rows[i].Cells[0].Value = ("mu[" + i + "]");
                }
                dataGridViewMu2.Rows[m2 + 2].Cells[0].Value = ("rho[j]");
                richTextBoxOutput2.Text += String.Format("eps = {0}\n", eps2);
                if (m2 == 1)
                {
                    double maxerr = 1;
                    int iter2 = 1;
                    do
                    {
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            func_p[i] = function2(point[i]);
                        }
                        double w = (func_p[2] + func_p[1]) / (func_p[0] + func_p[1]);
                        double v = SecantC(point[0], point[m2 + 1], w, point[0], point[1], point[2], eps2);
                        double A = (func_p[0] + func_p[1]) / (Math.Pow(point[1], v) + Math.Pow(point[0], v));
                        double[] mu2 = new double[m2 + 2];
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            mu2[i] = func_p[i] - A * Math.Pow(point[i], v);
                        }
                        double maxdevx = Searchmaxdev(a2, b2, v, A, tab2);
                        maxerr = Math.Abs(Math.Abs(function2(maxdevx) - approx(A, v, maxdevx)) - Math.Abs(mu2[0]));
                        if (maxerr < eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\n\nОстаточнi результати:");
                            richTextBoxOutput2.Text += String.Format("\nx є (" + a2 + "; " + b2 + ")");
                            richTextBoxOutput2.Text += String.Format("\nКiлькiсть iтерацiй: " + (iter2));
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2 + 2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC1(x) = A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC1(x) = " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");
                            richTextBoxOutput2.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, v, maxdevx))), acc2 + 2)));
                        }

                        if (maxerr > eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            richTextBoxOutput2.Text += String.Format("\niтерацiя: " + iter2);
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\nЗначення функцiї в точках z:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nf(" + Math.Round(point[i], acc2) + ") = " + Math.Round(function2(point[i]), acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nrho = " + Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, v, maxdevx))), acc2 + 2));
                            //Console.WriteLine("W = " + w);
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC1(x) = A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC1(x) = " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")");
                            richTextBoxOutput2.Text += String.Format("\nЗмiна точок альтернансу:\n");
                            if (maxdevx < point[0])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, v, maxdevx)) == Math.Sign(function2(point[0]) - approx(A, v, point[0])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                                else
                                {
                                    for (int i = m2 + 1; i > 0; i--)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i - 1], acc2) + '\n');
                                        point[i] = point[i - 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[m2 + 1])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, v, maxdevx)) == Math.Sign(function2(point[m2 + 1]) - approx(A, v, point[m2 + 1])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                                else
                                {
                                    for (int i = 0; i < m2; i++)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i + 1], acc2) + '\n');
                                        point[i] = point[i + 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[0] && maxdevx < point[m2 + 1])
                            {
                                for (int i = 0; i < m2 + 1; i++)
                                {
                                    if (maxdevx > point[i] && maxdevx < point[i + 1])
                                    {
                                        if (Math.Sign(function2(maxdevx) - approx(A, v, maxdevx)) == Math.Sign(function2(point[i]) - approx(A, v, point[i])))
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i] = maxdevx;
                                        }
                                        else
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i + 1] = maxdevx;
                                        }
                                    }
                                }
                            }
                        }
                        iter2++;
                    } while (maxerr > eps2);
                    PaintP2(acc2);
                }
                else if (m2 == 2)
                {
                    double maxerr = 1;
                    int iter2 = 1;
                    do
                    {
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            func_p[i] = function2(point[i]);
                        }
                        double w = (func_p[3] - func_p[1]) / (func_p[2] - func_p[0]);
                        double v = SecantC(a2, b2, w, point[0], point[1], point[2], point[3], eps2);
                        double A = (func_p[3] - func_p[1]) / (Math.Pow(point[3], v) - Math.Pow(point[1], v));
                        double A2 = 0.5 * (func_p[0] + func_p[3] - A * (Math.Pow(point[0], v) + Math.Pow(point[3], v)));
                        double[] mu2 = new double[m2 + 2];
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            mu2[i] = func_p[i] - A2 - A * Math.Pow(point[i], v);
                        }
                        double maxdevx = Searchmaxdev(a2, b2, v, A, A2, tab2);
                        maxerr = Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, v, maxdevx)) - Math.Abs(mu2[0]));
                        if (maxerr < eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A2 - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\n\nОстаточнi результати:");
                            richTextBoxOutput2.Text += String.Format("\nx є (" + a2 + "; " + b2 + ")");
                            richTextBoxOutput2.Text += String.Format("\nКiлькiсть iтерацiй: " + (iter2));
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2 + 2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\na2 = " + Math.Round(A2, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC2(x) = a2 + A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC2(x) = " + Math.Round(a2, acc2) + " + " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");

                            richTextBoxOutput2.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, v, maxdevx))), acc2 + 2)));
                        }

                        if (maxerr > eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            richTextBoxOutput2.Text += String.Format("\niтерацiя: " + iter2);
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A2 - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\nЗначення функцiї в точках z:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nf(" + Math.Round(point[i], acc2) + ") = " + Math.Round(function2(point[i]), acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nrho = " + Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, v, maxdevx))), acc2 + 2));
                            //Console.WriteLine("W = " + w);
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\na2 = " + Math.Round(A2, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC2(x) = a2 + A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC2(x) = " + Math.Round(a2, acc2) + " + " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");
                            richTextBoxOutput2.Text += String.Format("\nЗмiна точок альтернансу:\n");
                            if (maxdevx < point[0])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, A2, v, maxdevx)) == Math.Sign(function2(point[0]) - approx(A, A2, v, point[0])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                                else
                                {
                                    for (int i = m2 + 1; i > 0; i--)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i - 1], acc2) + '\n');
                                        point[i] = point[i - 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[m2 + 1])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, A2, v, maxdevx)) == Math.Sign(function2(point[m2 + 1]) - approx(A, A2, v, point[m2 + 1])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                                else
                                {
                                    for (int i = 0; i < m2; i++)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i + 1], acc2) + '\n');
                                        point[i] = point[i + 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[0] && maxdevx < point[m2 + 1])
                            {
                                for (int i = 0; i < m2 + 1; i++)
                                {
                                    if (maxdevx > point[i] && maxdevx < point[i + 1])
                                    {
                                        if (Math.Sign(function2(maxdevx) - approx(A, A2, v, maxdevx)) == Math.Sign(function2(point[i]) - approx(A, A2, v, point[i])))
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i] = maxdevx;
                                        }
                                        else
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i + 1] = maxdevx;
                                        }
                                    }
                                }
                            }
                        }
                        iter2++;
                    } while (maxerr > eps2);
                    PaintP2(acc2);
                }
                else if (m2 == 3)
                {
                    double maxerr = 1;
                    int iter2 = 1;
                    do
                    {
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            func_p[i] = function2(point[i]);
                        }
                        double w = ((func_p[4] - func_p[2]) / (point[4] - point[2]) - (func_p[3] - func_p[1]) / (point[3] - point[1])) / ((func_p[3] - func_p[1]) / (point[3] - point[1]) - (func_p[2] - func_p[0]) / (point[2] - point[0]));
                        double v = SecantC(a2, b2, w, point[0], point[1], point[2], point[3], point[4], eps2);
                        double A = ((point[0] - point[2]) * (func_p[3] - func_p[1]) - (point[1] - point[3]) * (func_p[2] - func_p[0])) / ((point[0] - point[2]) * (Math.Pow(point[3], v) - Math.Pow(point[1], v)) - (point[1] - point[3]) * (Math.Pow(point[2], v) - Math.Pow(point[0], v)));
                        double A3 = (func_p[0] - func_p[2] - A * (Math.Pow(point[2], v) - Math.Pow(point[0], v))) / (point[0] - point[2]);
                        double A2 = 0.5 * (func_p[3] + func_p[0] - A3 * (point[3] + point[0]) - A * (Math.Pow(point[3], v) + Math.Pow(point[0], v)));
                        double[] mu2 = new double[m2 + 2];
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            mu2[i] = function2(point[i]) - A2 - A3 * point[i] - A * Math.Pow(point[i], v);
                        }
                        double maxdevx = Searchmaxdev(a2, b2, v, A, A2, A3, tab2);
                        maxerr = Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, v, maxdevx)) - Math.Abs(mu2[0]));
                        if (maxerr < eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A2 - A3 * point[i] - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\n\nОстаточнi результати:");
                            richTextBoxOutput2.Text += String.Format("\nx є (" + a2 + "; " + b2 + ")");
                            richTextBoxOutput2.Text += String.Format("\nКiлькiсть iтерацiй: " + (iter2));
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2 + 2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\na2 = " + Math.Round(A2, acc2));
                            richTextBoxOutput2.Text += String.Format("\na3 = " + Math.Round(A3, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC3(x) = a2 + a3*x + A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC3(x) = " + Math.Round(A2, acc2) + " + " + Math.Round(A3, acc2) + "*x + " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");
                            richTextBoxOutput2.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, v, maxdevx))), acc2 + 2)));
                        }

                        if (maxerr > eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            richTextBoxOutput2.Text += String.Format("\niтерацiя: " + iter2);
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A2 - A3 * point[i] - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\nЗначення функцiї в точках z:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nf(" + Math.Round(point[i], acc2) + ") = " + Math.Round(function2(point[i]), acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nrho = " + Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, v, maxdevx))), acc2 + 2));
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\na2 = " + Math.Round(A2, acc2));
                            richTextBoxOutput2.Text += String.Format("\na3 = " + Math.Round(A3, acc2));
                            richTextBoxOutput2.Text += String.Format("\nw = " + Math.Round(w, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC3(x) = a2 + a3*x + A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC3(x) = " + Math.Round(A2, acc2) + " + " + Math.Round(A3, acc2) + "*x + " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");
                            richTextBoxOutput2.Text += String.Format("\nЗмiна точок альтернансу:\n");
                            if (maxdevx < point[0])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, A2, A3, v, maxdevx)) == Math.Sign(function2(point[0]) - approx(A, A2, A3, v, point[0])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                                else
                                {
                                    for (int i = m2 + 1; i > 0; i--)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i - 1], acc2) + '\n');
                                        point[i] = point[i - 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[m2 + 1])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, A2, A3, v, maxdevx)) == Math.Sign(function2(point[m2 + 1]) - approx(A, A2, A3, v, point[m2 + 1])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                                else
                                {
                                    for (int i = 0; i < m2; i++)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i + 1], acc2) + '\n');
                                        point[i] = point[i + 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[0] && maxdevx < point[m2 + 1])
                            {
                                for (int i = 0; i < m2 + 1; i++)
                                {
                                    if (maxdevx > point[i] && maxdevx < point[i + 1])
                                    {
                                        if (Math.Sign(function2(maxdevx) - approx(A, A2, A3, v, maxdevx)) == Math.Sign(function2(point[i]) - approx(A, A2, A3, v, point[i])))
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i] = maxdevx;
                                        }
                                        else
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i + 1] = maxdevx;
                                        }
                                    }
                                }
                            }
                        }
                        iter2++;
                    } while (maxerr > eps2);
                    PaintP2(acc2);
                }
                else if (m2 == 4)
                {
                    double maxerr = 1;
                    int iter2 = 1;
                    do
                    {
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            func_p[i] = function2(point[i]);
                        }
                        double[] Fbig = new double[m2];
                        for (int i = 0; i < m2; i++)
                        {
                            Fbig[i] = (func_p[i + 2] - func_p[i]) / (point[i + 2] - point[i]);
                        }
                        double w = ((Fbig[3] - Fbig[2]) / (point[5] + point[3] - point[4] - point[2]) - (Fbig[2] - Fbig[1]) / (point[4] + point[2] - point[3] - point[1])) / ((Fbig[2] - Fbig[1]) / (point[4] + point[2] - point[3] - point[1]) - (Fbig[1] - Fbig[0]) / (point[3] + point[1] - point[2] - point[0]));
                        double v = SecantC(a2, b2, w, point[0], point[1], point[2], point[3], point[4], point[5], eps2);
                        double A = ((Fbig[3] - Fbig[2]) / (point[5] - point[4] + point[3] - point[2]) - (Fbig[2] - Fbig[1]) / (point[4] - point[3] + point[2] - point[1])) / ((Etha4(3, point[3], point[5], v) - Etha4(2, point[2], point[4], v)) / (point[5] - point[4] + point[3] - point[2]) - (Etha4(2, point[2], point[4], v) - Etha4(1, point[1], point[3], v)) / (point[4] - point[3] + point[2] - point[1]));
                        double A4 = (Fbig[3] - Fbig[2] - A * (Etha4(3, point[3], point[5], v) - Etha4(2, point[2], point[4], v))) / (point[5] - point[4] + point[3] - point[2]);
                        double A3 = (func_p[5] - func_p[3] - A4 * (Math.Pow(point[5], 2) - Math.Pow(point[3], 2)) - A * (Math.Pow(point[5], v) - Math.Pow(point[3], v))) / (point[5] - point[3]);
                        double A2 = (func_p[5] + func_p[0] - A4 * (Math.Pow(point[5], 2) + Math.Pow(point[0], 2)) - A3 * (point[5] + point[0]) - A * (Math.Pow(point[5], v) + Math.Pow(point[0], v))) / 2;
                        double[] mu2 = new double[m2 + 2];
                        for (int i = 0; i < m2 + 2; i++)
                        {
                            mu2[i] = func_p[i] - A2 - A3 * point[i] - A4 * Math.Pow(point[i], 2) - A * Math.Pow(point[i], v);
                        }
                        double maxdevx = Searchmaxdev(a2, b2, v, A, A2, A3, A4, tab2);
                        maxerr = Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) - Math.Abs(mu2[0]));
                        if (maxerr < eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A2 - A3 * point[i] - A4 * point[i] * point[i] - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\n\nОстаточнi результати:");
                            richTextBoxOutput2.Text += String.Format("\nx є (" + a2 + "; " + b2 + ")");
                            richTextBoxOutput2.Text += String.Format("\nКiлькiсть iтерацiй: " + (iter2));
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2 + 2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\na2 = " + Math.Round(A2, acc2));
                            richTextBoxOutput2.Text += String.Format("\na3 = " + Math.Round(A3, acc2));
                            richTextBoxOutput2.Text += String.Format("\na4 = " + Math.Round(A4, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC4(x) = a2 + a3*x + a4*x^2 + A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC4(x) = " + Math.Round(A2, acc2) + " + " + Math.Round(A3, acc2) + "*x + " + Math.Round(A4, acc2) + "*x^2 + " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");
                            richTextBoxOutput2.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx))), acc2 + 2)));
                        }

                        if (maxerr > eps2)
                        {
                            dataGridViewZ2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewF2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            dataGridViewMu2.Columns.Add(Convert.ToString(iter2), String.Format("ітерація " + iter2));
                            richTextBoxOutput2.Text += String.Format("\niтерацiя: " + iter2);
                            richTextBoxOutput2.Text += String.Format("\nТочки альтернансу:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nz[" + i + "] = " + Math.Round(point[i], acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                dataGridViewZ2.Rows[i].Cells[iter2].Value = Math.Round(point[i], acc2);
                                dataGridViewF2.Rows[i].Cells[iter2].Value = Math.Round(function2(point[i]), acc2);
                                dataGridViewMu2.Rows[i].Cells[iter2].Value = Math.Round(func_p[i] - A2 - A3 * point[i] - A4 * point[i] * point[i] - A * Math.Pow(point[i], v), acc2 + 2);
                            }
                            dataGridViewMu2.Rows[m2 + 2].Cells[iter2].Value = Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx))), acc2 + 2);
                            richTextBoxOutput2.Text += String.Format("\nЗначення функцiї в точках z:");
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nf(" + Math.Round(point[i], acc2) + ") = " + Math.Round(function2(point[i]), acc2));
                            }
                            for (int i = 0; i < m2 + 2; i++)
                            {
                                richTextBoxOutput2.Text += String.Format("\nmu[" + i + "] = " + Math.Round(mu2[i], acc2));
                            }
                            richTextBoxOutput2.Text += String.Format("\nrho = " + Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx))), acc2 + 2));
                            richTextBoxOutput2.Text += String.Format("\nrho = " + Math.Round(Math.Abs(Math.Abs(function2(maxdevx) - approx(A, A2, v, maxdevx))), acc2 + 2));
                            richTextBoxOutput2.Text += String.Format("\nv = " + Math.Round(v, acc2));
                            richTextBoxOutput2.Text += String.Format("\nA = " + Math.Round(A, acc2));
                            richTextBoxOutput2.Text += String.Format("\na2 = " + Math.Round(A2, acc2));
                            richTextBoxOutput2.Text += String.Format("\na3 = " + Math.Round(A3, acc2));
                            richTextBoxOutput2.Text += String.Format("\na4 = " + Math.Round(A4, acc2));
                            richTextBoxOutput2.Text += String.Format("\nC4(x) = a2 + a3*x + a4*x^2 + A*(x^v)");
                            richTextBoxOutput2.Text += String.Format("\nC4(x) = " + Math.Round(A2, acc2) + " + " + Math.Round(A3, acc2) + "*x + " + Math.Round(A4, acc2) + "*x^2 + " + Math.Round(A, acc2) + "*x^(" + Math.Round(v, acc2) + ")\n");
                            richTextBoxOutput2.Text += String.Format("\nЗмiна точок альтернансу:\n");
                            if (maxdevx < point[0])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) == Math.Sign(function2(point[0]) - approx(A, A2, A3, A4, v, point[0])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                                else
                                {
                                    for (int i = m2 + 1; i > 0; i--)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i - 1], acc2) + '\n');
                                        point[i] = point[i - 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[0]: " + Math.Round(point[0], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewF2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewZ2.Rows[0].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[0] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[m2 + 1])
                            {
                                if (Math.Sign(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) == Math.Sign(function2(point[m2 + 1]) - approx(A, A2, A3, A4, v, point[m2 + 1])))
                                {
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                                else
                                {
                                    for (int i = 0; i < m2; i++)
                                    {
                                        richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(point[i + 1], acc2) + '\n');
                                        point[i] = point[i + 1];
                                    }
                                    richTextBoxOutput2.Text += String.Format("z[2]: " + Math.Round(point[m2 + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                    dataGridViewZ2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    dataGridViewF2.Rows[m2 + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                    point[m2 + 1] = maxdevx;
                                }
                            }
                            else if (maxdevx > point[0] && maxdevx < point[m2 + 1])
                            {
                                for (int i = 0; i < m2 + 1; i++)
                                {
                                    if (maxdevx > point[i] && maxdevx < point[i + 1])
                                    {
                                        if (Math.Sign(function2(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) == Math.Sign(function2(point[i]) - approx(A, A2, A3, A4, v, point[i])))
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i] = maxdevx;
                                        }
                                        else
                                        {
                                            richTextBoxOutput2.Text += String.Format("z[" + i + "]: " + Math.Round(point[i + 1], acc2) + " --> " + Math.Round(maxdevx, acc2) + '\n');
                                            dataGridViewZ2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            dataGridViewF2.Rows[i + 1].Cells[iter2].Style.BackColor = Color.FromArgb(255, 192, 192);
                                            point[i + 1] = maxdevx;
                                        }
                                    }
                                }
                            }
                        }
                        iter2++;
                    } while (maxerr > eps2);
                    PaintP2(acc2);
                }
                else
                {
                    richTextBoxOutput2.Text = "Введіть m від 1 до 4!";
                }
            }
        }
        //////////////////////////////////////////////////////////graphs//////////////////////////////////////////////////////////////////////
        private void buttonZoomReset2_Click(object sender, EventArgs e)
        {
            chartApprox2.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartApprox2.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
            chartError2.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartError2.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
        }
        void PaintP2(int acc)
        {
            chartApprox2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartApprox2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartApprox2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartApprox2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartApprox2.Invalidate();
            chartError2.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartError2.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartError2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartError2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartError2.Invalidate();
            chartApprox2.Series["F(x)"].Points.Clear();
            chartApprox2.Series["Cm(x)"].Points.Clear();
            chartError2.Series["F(x) - Cm(x)"].Points.Clear();
            chartApprox2.Series["F(x)"].Points.DataBindXY(x2Values, func2Values);
            chartApprox2.Series["Cm(x)"].Points.DataBindXY(x2Values, inter2Values);
            chartError2.Series["F(x) - Cm(x)"].Points.DataBindXY(x2Values, error2Values);
            ChartArea CAI2 = chartApprox2.ChartAreas[0];
            CAI2.AxisX.ScaleView.Zoomable = true;
            CAI2.AxisY.ScaleView.Zoomable = true;
            CAI2.CursorY.AutoScroll = true;
            CAI2.CursorY.IsUserSelectionEnabled = true;
            CAI2.CursorX.AutoScroll = true;
            CAI2.CursorX.IsUserSelectionEnabled = true;
            ChartArea CAE2 = chartError2.ChartAreas[0];
            CAE2.AxisX.ScaleView.Zoomable = true;
            CAE2.AxisY.ScaleView.Zoomable = true;
            CAE2.CursorY.AutoScroll = true;
            CAE2.CursorY.IsUserSelectionEnabled = true;
            CAE2.CursorX.AutoScroll = true;
            CAE2.CursorX.IsUserSelectionEnabled = true;
            chartApprox2.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartApprox2.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError2.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError2.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));

        }

        /////////////////////////////////////////////////////////////tab 3////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////textboxes and buttons formatting//////////////////////////////////////////////////////
        //textBoxa3
        private void textBoxa3_Enter(object sender, EventArgs e)
        {
            if (textBoxa3.Text == "Введіть a")
            {
                textBoxa3.ForeColor = Color.Black;
                textBoxa3.Text = "";
            }
        }
        private void textBoxa3_Leave(object sender, EventArgs e)
        {
            if (textBoxa3.Text == "")
            {
                textBoxa3.ForeColor = Color.LightGray;
                textBoxa3.Text = "Введіть a";
            }
        }
        private void textBoxa3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa3.Text != "" && textBoxa3.Text != "Введіть a" && textBoxb3.Text != "" && textBoxb3.Text != "Введіть b" && textBoxa3.Text != "-" && textBoxb3.Text != "-")
            {
                if (Convert.ToDouble(textBoxa3.Text) < Convert.ToDouble(textBoxb3.Text))
                {
                    buttonEval3.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval3.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval3.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void textBoxa3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec3.Checked) e.Handled = true;
        }
        //textboxb3
        private void textBoxb3_Enter(object sender, EventArgs e)
        {
            if (textBoxb3.Text == "Введіть b")
            {
                textBoxb3.ForeColor = Color.Black;
                textBoxb3.Text = "";
            }
        }
        private void textBoxb3_Leave(object sender, EventArgs e)
        {
            if (textBoxb3.Text == "")
            {
                textBoxb3.ForeColor = Color.LightGray;
                textBoxb3.Text = "Введіть b";
            }
        }
        private void textBoxb3_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa3.Text != "" && textBoxa3.Text != "Введіть a" && textBoxb3.Text != "" && textBoxb3.Text != "Введіть b" && textBoxa3.Text != "-" && textBoxb3.Text != "-")
            {
                if (Convert.ToDouble(textBoxa3.Text) < Convert.ToDouble(textBoxb3.Text))
                {
                    buttonEval3.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval3.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval3.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void textBoxb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec3.Checked) e.Handled = true;
        }
        //comboboxfunc3
        private void comboBoxFunc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            func3selector = comboBoxFunc3.SelectedIndex;
            if (checkBoxRec3.Checked)
            {
                textBoxa3.Text = Convert.ToString(funcRecAB3[func3selector, 0]);
                textBoxb3.Text = Convert.ToString(funcRecAB3[func3selector, 1]);
                textBoxa3.ForeColor = Color.Black;
                textBoxb3.ForeColor = Color.Black;
            }
        }
        //comboboxrec3
        private void checkBoxRec3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRec3.Checked)
            {
                textBoxa3.Text = Convert.ToString(funcRecAB3[func3selector, 0]);
                textBoxb3.Text = Convert.ToString(funcRecAB3[func3selector, 1]);
                textBoxa3.ForeColor = Color.Black;
                textBoxb3.ForeColor = Color.Black;
            }
        }
        //richTextBoxOutput3
        private void richTextBoxOutput3_TextChanged(object sender, EventArgs e)
        {
            richTextBoxOutput3.SelectionStart = richTextBoxOutput3.Text.Length;
            richTextBoxOutput3.ScrollToCaret();
        }
        ///////////////////////////////////////////////////////////eval///////////////////////////////////////////////////////////////////////
        //eval functions
        double rho3(double z, double[] arr, int m1)
        {
            return function3(z) - Pm(arr, z, m1);
        }
        double[] max_err3(double[] arr, int tab1, int m1, double a1, double b1)
        {
            double[] res = { 0, 0 };
            double[] tabs = new double[tab1 + 1];
            for (int k = 0; k < tab1 + 1; k++)
            {
                tabs[k] = a1 + (b1 - a1) * k / (tab1);
                if (Math.Abs(function3(tabs[k]) - Pm(arr, tabs[k], m1)) > Math.Abs(res[0]))
                {
                    res[0] = function3(tabs[k]) - Pm(arr, tabs[k], m1);
                    res[1] = tabs[k];
                }
            }
            return res;
        }
        void addinfo(double[] arr, int tab1, int m1, double a1, double b1)
        {
            double[] res = { 0, 0 };
            double[] tabs = new double[tab1 + 1];
            for (int k = 0; k < tab1 + 1; k++)
            {
                tabs[k] = a1 + (b1 - a1) * k / (tab1);
                x3Values.Add(tabs[k]);
                func3Values.Add(function3(tabs[k]));
                inter3Values.Add(Pm(arr, tabs[k], m1));
                error3Values.Add(function3(tabs[k]) - Pm(arr, tabs[k], m1));
            }
        }
        private double epsilon3setter()
        {
            switch (eps3selector)
            {
                case 0:
                    acc3 = 5;
                    return 1E-4;
                case 1:
                    acc3 = 7;
                    return 1E-3;
                case 2:
                    acc3 = 9;
                    return 1E-8;
                case 3:
                    acc3 = 11;
                    return 1E-10;
                default:
                    return 1E-6;
            }
        }
        private double acc3setter()
        {
            switch (acc3selector)
            {
                case 0:
                    accerr = 2;
                    return 1E-1;
                case 1:
                    accerr = 3;
                    return 1E-2;
                case 2:
                    accerr = 4;
                    return 1E-3;
                case 3:
                    accerr = 5;
                    return 1E-4;
                case 4:
                    accerr = 6;
                    return 1E-5;
                case 5:
                    accerr = 7;
                    return 1E-6;
                default:
                    return 1E-2;
            }
        }
        private double function3(double x)
        {
            switch (func3selector)
            {
                case 0:
                    return Math.Pow(x, 3.5);
                case 1:
                    return Math.Exp(0.6 * x) - 1;
                case 2:
                    return Math.Log10(2 * x) - 2;
                case 3:
                    return 3 * Math.Sin(x) + 0.5;
                case 4:
                    return Math.Tan(x) - Math.Sin(x) + 0.3;
                case 5:
                    return Math.Tan(x) / (x + 2);
                case 6:
                    return Math.Log(1 / x) * Math.Sqrt(x);
                case 7:
                    return Math.Sqrt(x * x * x + 2 * x * x - 3 * x + 4);
                case 8:
                    return Math.Log(Math.Cosh(x)) - Math.Tanh(x) + 0.9 * Math.Sin(x);
                default:
                    return -1;
            }
        }
        private double arraydiff(double[,] array, int length)
        {
            double res = 0;
            for (int i = 0; i < length; i++)
            {
                res += Math.Abs(array[2, i] - array[0, i]);
            }
            return res;
        }
        //buttonEval3
        private void buttonEval3_Click(object sender, EventArgs e)
        {
            x3Values.Clear();
            func3Values.Clear();
            inter3Values.Clear();
            error3Values.Clear();
            dataGridViewParts3.DataSource = null;
            dataGridViewParts3.Rows.Clear();
            richTextBoxOutput3.Text = "";
            if (buttonEval3.BackColor != Color.FromArgb(192, 255, 192))
            {
                if (textBoxa3.Text == "" || textBoxa3.Text == "Введіть a" || textBoxb3.Text == "" || textBoxb3.Text == "Введіть b") richTextBoxOutput3.Text = "Заповніть поля a та b";
                else richTextBoxOutput3.Text = "Введіть коректні дані в поля a та b:\na i b повиннi бути числами, а < b";
            }
            else
            {

                dataGridViewParts3.ColumnCount = 4;
                dataGridViewParts3.Columns[0].Name = "Функція";
                dataGridViewParts3.Columns[1].Name = "a";
                dataGridViewParts3.Columns[2].Name = "b";
                dataGridViewParts3.Columns[3].Name = "Похибка";
                int spline = 1;
                double a3 = Convert.ToDouble(textBoxa3.Text);
                double b3 = Convert.ToDouble(textBoxb3.Text);
                int m3 = Convert.ToInt32(numericUpDownm3.Value);
                int tab3 = 50 * m3;
                int w3 = 1;
                eps3selector = comboBoxEps3.SelectedIndex;
                acc3selector = comboBoxAcc3.SelectedIndex;
                double eps3 = epsilon3setter();
                double accerr = acc3setter();
                richTextBoxOutput3.Text += String.Format("Функція: " + comboBoxFunc3.Text + "\n");
                richTextBoxOutput3.Text += String.Format("а = " + Math.Round(a3, acc3) + "\n");
                richTextBoxOutput3.Text += String.Format("b = " + Math.Round(b3, acc3) + "\n");
                richTextBoxOutput3.Text += String.Format("Обрана похибка: " + comboBoxAcc3.Text + "\n\n");
                while (Math.Abs(a3 - b3) > eps3)
                {
                    dataGridViewParts3.Rows.Add(1);
                    bool work = true;
                    int iter3 = 1;
                    double error = 1;
                    while (work)
                    {
                        bool cont3 = true;
                        double[] z_old3 = new double[m3 + 2];
                        double[,] prev_ch = new double[3, m3 + 2];
                        for (int k = 0; k < m3 + 2; k++)
                        {
                            for (int j = 0; j < 3; j++) prev_ch[j, k] = 0;
                        }
                        for (int k = 0; k < m3 + 2; k++)
                        {
                            z_old3[k] = a3 + (b3 - a3) * k / (m3 + 1);
                        }
                        while (cont3)
                        {
                            cont3 = false;
                            double[] func_z3 = new double[m3 + 2];
                            double[,] slar_res3 = new double[m3 + 2, m3 + 3];
                            for (int i = 0; i < m3 + 2; i++)
                            {
                                for (int k = 0; k < m3 + 1; k++)
                                {
                                    slar_res3[i, k] = power(z_old3[i], k);
                                }
                                if (comboBoxType1.SelectedIndex == 1)
                                {
                                    if (spline == 1)
                                    {
                                        if (i == m3 + 1)
                                            slar_res3[i, m3 + 1] = 0;
                                        else slar_res3[i, m3 + 1] = w3 * Math.Pow(-1, i);
                                    }
                                    else
                                    {
                                        if (i == 0) slar_res3[i, m3 + 1] = 0;
                                        else if (i == m3 + 1) slar_res3[i, m3 + 1] = 0;
                                        else slar_res3[i, m3 + 1] = w3 * Math.Pow(-1, i);
                                    }
                                }
                                else slar_res3[i, m3 + 1] = w3 * Math.Pow(-1, i);
                                slar_res3[i, m3 + 2] = function3(z_old3[i]);
                                func_z3[i] = slar_res3[i, m3 + 2];
                            }
                            gauss(slar_res3, m3);
                            double[] coef3 = new double[m3 + 1];
                            double mu_old = slar_res3[m3 + 1, m3 + 2];
                            for (int i = 0; i < m3 + 1; i++)
                            {
                                coef3[i] = slar_res3[i, m3 + 2];
                            }
                            double rho_j3;
                            double x_err3;
                            {
                                double[] result3 = max_err3(coef3, tab3, m3, a3, b3);
                                rho_j3 = result3[0];
                                x_err3 = result3[1];
                            }
                            bool cycled = false;
                            for (int i = 0; i < m3 + 2; i++)
                            {
                                prev_ch[0, i] = prev_ch[1, i];
                                prev_ch[1, i] = prev_ch[2, i];
                                prev_ch[2, i] = z_old3[i];
                            }
                            double mindiff = x_err3 - z_old3[0];
                            for (int i = 1; i < m3 + 2; i++)
                            {
                                if (mindiff > Math.Abs(x_err3 - z_old3[i])) mindiff = Math.Abs(x_err3 - z_old3[i]);
                            }
                            if (arraydiff(prev_ch, m3 + 2) < eps3) cycled = true;
                            //if(spline == 3)MessageBox.Show(Convert.ToString(z_old3[0]) + '\n' + Convert.ToString(z_old3[1]) + '\n' + Convert.ToString(z_old3[2]) + '\n' + Convert.ToString(z_old3[3]) + '\n' + Convert.ToString(x_err3)+ '\n' + Convert.ToString(cycled));
                            if (Math.Abs((Math.Abs(rho_j3) - Math.Abs(mu_old)) / Math.Abs((mu_old))) > eps3 && mindiff > eps3 && !cycled)
                            {
                                cont3 = true;
                                if (x_err3 < z_old3[0])
                                {
                                    if (Math.Sign(rho_j3) == Math.Sign(rho3(z_old3[0], coef3, m3)))
                                    {
                                        z_old3[0] = x_err3;
                                    }
                                    else
                                    {
                                        for (int i = m3 + 1; i > 0; i--)
                                        {
                                            z_old3[i] = z_old3[i - 1];
                                        }
                                        z_old3[0] = x_err3;
                                    }
                                }
                                else if (x_err3 > z_old3[m3 + 1])
                                {
                                    if (Math.Sign(rho_j3) == Math.Sign(rho3(z_old3[m3 + 1], coef3, m3)))
                                    {
                                        z_old3[m3 + 1] = x_err3;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < m3; i++)
                                        {
                                            z_old3[i] = z_old3[i + 1];
                                        }
                                        z_old3[m3 + 1] = x_err3;
                                    }
                                }
                                else if (x_err3 > z_old3[0] && x_err3 < z_old3[m3 + 1])
                                {
                                    for (int i = 0; i < m3 + 1; i++)
                                    {
                                        if (x_err3 > z_old3[i] && x_err3 < z_old3[i + 1])
                                        {
                                            if (Math.Sign(rho_j3) == Math.Sign(rho3(z_old3[i], coef3, m3)))
                                            {
                                                z_old3[i] = x_err3;
                                            }
                                            else
                                            {
                                                z_old3[i + 1] = x_err3;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                error = Math.Abs(rho_j3);
                                if (iter3 == 1 && error < accerr)
                                {
                                    richTextBoxOutput3.Text += String.Format("Ланка " + spline + "\n");
                                    richTextBoxOutput3.Text += String.Format("Для побудови використано 1 ітерацію" + "\n");
                                    string pm = "";
                                    pm += String.Format("S(A{0},x) = {1}", spline - 1, Math.Round(coef3[0], acc3));
                                    for (int i = 1; i < m3 + 1; i++)
                                    {
                                        pm += String.Format("+ {0}*x^{1}", Math.Round(coef3[i], acc3), i);
                                    }
                                    richTextBoxOutput3.Text += pm;
                                    richTextBoxOutput3.Text += String.Format("\nа = " + Math.Round(a3, acc3) + "\n");
                                    richTextBoxOutput3.Text += String.Format("b = " + Math.Round(b3, acc3) + "\n");
                                    richTextBoxOutput3.Text += String.Format("Найбільша похибка = " + Math.Round(error, acc3) + "\n\n");
                                    dataGridViewParts3.Rows[spline - 1].Cells[0].Value = pm;
                                    dataGridViewParts3.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a3, acc3));
                                    dataGridViewParts3.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b3, acc3));
                                    dataGridViewParts3.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(error, acc3));
                                    addinfo(coef3, tab3, m3, a3, b3);
                                    a3 = b3;
                                    b3 = Convert.ToDouble(textBoxb3.Text);
                                    error = 1;
                                    work = false;
                                }
                                if (Math.Abs(error - accerr) < accerr * 0.01 && error < accerr)
                                {
                                    richTextBoxOutput3.Text += String.Format("Ланка " + spline + "\n");
                                    richTextBoxOutput3.Text += String.Format("Для побудови використано " + iter3 + " ітерацій;" + "\n");
                                    string pm = "";
                                    pm += String.Format("S(A{0},x) = {1}", spline - 1, Math.Round(coef3[0], acc3));
                                    for (int i = 1; i < m3 + 1; i++)
                                    {
                                        pm += String.Format("+ {0}*x^{1}", Math.Round(coef3[i], acc3), i);
                                    }
                                    richTextBoxOutput3.Text += pm;
                                    richTextBoxOutput3.Text += String.Format("\nа = " + Math.Round(a3, acc3) + "\n");
                                    richTextBoxOutput3.Text += String.Format("b = " + Math.Round(b3, acc3) + "\n");
                                    richTextBoxOutput3.Text += String.Format("Найбільша похибка = " + Math.Round(error, acc3) + "\n\n");
                                    dataGridViewParts3.Rows[spline - 1].Cells[0].Value = pm;
                                    dataGridViewParts3.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a3, acc3));
                                    dataGridViewParts3.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b3, acc3));
                                    dataGridViewParts3.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(error, acc3));
                                    addinfo(coef3, tab3, m3, a3, b3);
                                    a3 = b3;
                                    b3 = Convert.ToDouble(textBoxb3.Text);
                                    error = 1;
                                    work = false;
                                }
                                else if (error > accerr)
                                {
                                    b3 = (a3 + b3) / 2.0;
                                    iter3++;
                                }
                                else if (error < accerr)
                                {
                                    b3 = a3 + (b3 - a3) * 1.5;
                                    iter3++;
                                }
                            }
                        }
                    }
                    spline++;
                }
                PaintP3(Convert.ToDouble(textBoxa3.Text), Convert.ToDouble(textBoxb3.Text), acc3);
                dataGridViewParts3.ClearSelection();
            }
        }
        //////////////////////////////////////////////////////////graphs//////////////////////////////////////////////////////////////////////
        private void buttonZoomReset3_Click(object sender, EventArgs e)
        {
            chartApprox3.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartApprox3.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
            chartError3.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartError3.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
        }
        private void PaintP3(double min, double max, int acc)
        {
            chartApprox3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartApprox3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartApprox3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartApprox3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartApprox3.Invalidate();
            chartError3.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartError3.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartError3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartError3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartError3.Invalidate();
            chartApprox3.Series["F(x)"].Points.Clear();
            chartApprox3.Series["S(A,x)"].Points.Clear();
            chartError3.Series["F(x) - S(A,x)"].Points.Clear();
            chartApprox3.Series["F(x)"].Points.DataBindXY(x3Values, func3Values);
            chartApprox3.Series["S(A,x)"].Points.DataBindXY(x3Values, inter3Values);
            chartError3.Series["F(x) - S(A,x)"].Points.DataBindXY(x3Values, error3Values);
            ChartArea CAI3 = chartApprox3.ChartAreas[0];
            CAI3.AxisX.ScaleView.Zoomable = true;
            CAI3.AxisY.ScaleView.Zoomable = true;
            CAI3.CursorY.AutoScroll = true;
            CAI3.CursorY.IsUserSelectionEnabled = true;
            CAI3.CursorX.AutoScroll = true;
            CAI3.CursorX.IsUserSelectionEnabled = true;
            ChartArea CAE3 = chartError3.ChartAreas[0];
            CAE3.AxisX.ScaleView.Zoomable = true;
            CAE3.AxisY.ScaleView.Zoomable = true;
            CAE3.CursorY.AutoScroll = true;
            CAE3.CursorY.IsUserSelectionEnabled = true;
            CAE3.CursorX.AutoScroll = true;
            CAE3.CursorX.IsUserSelectionEnabled = true;
            chartApprox3.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartApprox3.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError3.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError3.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));

        }

        /////////////////////////////////////////////////////////////tab 4////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////textboxes and buttons formatting//////////////////////////////////////////////////////
        //textBoxa4
        private void textBoxa4_Enter(object sender, EventArgs e)
        {
            if (textBoxa4.Text == "Введіть a")
            {
                textBoxa4.ForeColor = Color.Black;
                textBoxa4.Text = "";
            }
        }
        private void textBoxa4_Leave(object sender, EventArgs e)
        {
            if (textBoxa4.Text == "")
            {
                textBoxa4.ForeColor = Color.LightGray;
                textBoxa4.Text = "Введіть a";
            }
        }
        private void textBoxa4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa4.Text != "" && textBoxa4.Text != "Введіть a" && textBoxb4.Text != "" && textBoxb4.Text != "Введіть b" && textBoxa4.Text != "-" && textBoxb4.Text != "-")
            {
                if (Convert.ToDouble(textBoxa4.Text) < Convert.ToDouble(textBoxb4.Text))
                {
                    buttonEval4.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval4.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval4.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void textBoxa4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec4.Checked) e.Handled = true;
        }
        //textboxb4
        private void textBoxb4_Enter(object sender, EventArgs e)
        {
            if (textBoxb4.Text == "Введіть b")
            {
                textBoxb4.ForeColor = Color.Black;
                textBoxb4.Text = "";
            }
        }
        private void textBoxb4_Leave(object sender, EventArgs e)
        {
            if (textBoxb4.Text == "")
            {
                textBoxb4.ForeColor = Color.LightGray;
                textBoxb4.Text = "Введіть b";
            }
        }
        private void textBoxb4_TextChanged(object sender, EventArgs e)
        {
            if (textBoxa4.Text != "" && textBoxa4.Text != "Введіть a" && textBoxb4.Text != "" && textBoxb4.Text != "Введіть b" && textBoxa4.Text != "-" && textBoxb4.Text != "-")
            {
                if (Convert.ToDouble(textBoxa4.Text) < Convert.ToDouble(textBoxb4.Text))
                {
                    buttonEval4.BackColor = Color.FromArgb(192, 255, 192);
                }
                else buttonEval4.BackColor = Color.FromArgb(255, 192, 192);
            }
            else buttonEval4.BackColor = Color.FromArgb(255, 192, 192);
        }
        private void textBoxb4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NumberDetectTextbox(e.KeyChar) || checkBoxRec4.Checked) e.Handled = true;
        }
        //comboboxfunc4
        private void comboBoxFunc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            func4selector = comboBoxFunc4.SelectedIndex;
            if (checkBoxRec4.Checked)
            {
                textBoxa4.Text = Convert.ToString(funcRecAB4[func4selector, 0]);
                textBoxb4.Text = Convert.ToString(funcRecAB4[func4selector, 1]);
                textBoxa4.ForeColor = Color.Black;
                textBoxb4.ForeColor = Color.Black;
            }
        }
        //comboboxrec4
        private void checkBoxRec4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRec4.Checked)
            {
                textBoxa4.Text = Convert.ToString(funcRecAB4[func4selector, 0]);
                textBoxb4.Text = Convert.ToString(funcRecAB4[func4selector, 1]);
                textBoxa4.ForeColor = Color.Black;
                textBoxb4.ForeColor = Color.Black;
            }
        }
        //richTextBoxOutput4
        private void richTextBoxOutput4_TextChanged(object sender, EventArgs e)
        {
            richTextBoxOutput3.SelectionStart = richTextBoxOutput3.Text.Length;
            richTextBoxOutput3.ScrollToCaret();
        }
        ///////////////////////////////////////////////////////////eval///////////////////////////////////////////////////////////////////////
        //eval functions
        private double epsilon4setter()
        {
            switch (eps4selector)
            {
                case 0:
                    acc4 = 4;
                    return 1E-3;
                case 1:
                    acc4 = 6;
                    return 1E-5;
                case 2:
                    acc4 = 9;
                    return 1E-8;
                case 3:
                    acc4 = 12;
                    return 1E-11;
                default:
                    return 1E-5;
            }
        }
        private double acc4setter()
        {
            switch (acc4selector)
            {
                case 0:
                    accerr2 = 2;
                    return 1E-1;
                case 1:
                    accerr2 = 3;
                    return 1E-2;
                case 2:
                    accerr2 = 4;
                    return 1E-3;
                case 3:
                    accerr2 = 5;
                    return 1E-4;
                case 4:
                    accerr2 = 6;
                    return 1E-5;
                case 5:
                    accerr2 = 7;
                    return 1E-6;
                default:
                    return 1E-2;
            }
        }
        private double function4(double x)
        {
            switch (func4selector)
            {
                case 0:
                    return Math.Exp(0.6 * x) - 1;
                case 1:
                    return Math.Log10(2 * x) - 2;
                case 2:
                    return 3 * Math.Sin(x) + 0.5;
                case 3:
                    return Math.Tan(x) - Math.Sin(x) + 0.3;
                case 4:
                    return Math.Cosh(x) - 1.5 * Math.Sin(x);
                case 5:
                    return Math.Exp(Math.Sin(x)) + x;
                case 6:
                    return Math.Log(Math.Abs(Math.Cos(0.5 * x)) + 0.6);
                case 7:
                    return Math.Log(Math.Cosh(x)) - Math.Tanh(x) + 0.9 * Math.Sin(x);
                default:
                    return -1;
            }
        }
        void addinfo2(double a, double b, double v, double A, double tab)
        {
            double x;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                x4Values.Add(x);
                func4Values.Add(function4(x));
                inter4Values.Add(approx(A, v, x));
                error4Values.Add(function4(x) - approx(A, v, x));
            }
        }
        void addinfo2(double a, double b, double v, double A, double a2, double tab)
        {
            double x;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                x4Values.Add(x);
                func4Values.Add(function4(x));
                inter4Values.Add(approx(A, a2, v, x));
                error4Values.Add(function4(x) - approx(A, a2, v, x));
            }
        }
        void addinfo2(double a, double b, double v, double A, double a2, double a3, double tab)
        {
            double x;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                x4Values.Add(x);
                func4Values.Add(function4(x));
                inter4Values.Add(approx(A, a2, v, x));
                error4Values.Add(function4(x) - approx(A, a2, v, x));
            }
        }
        void addinfo2(double a, double b, double v, double A, double a2, double a3, double a4, double tab)
        {
            double x;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                x4Values.Add(x);
                func4Values.Add(function4(x));
                inter4Values.Add(approx(A, a2, a3, a4, v, x));
                error4Values.Add(function4(x) - approx(A, a2, a3, a4, v, x));
            }
        }
        double Searchmaxdev2(double a, double b, double v, double A, double tab)
        {
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function4(x) - approx(A, v, x)) > Math.Abs(max))
                {
                    max = function4(x) - approx(A, v, x);
                    x_max = x;
                }
            }
            return x_max;
        }
        double Searchmaxdev2(double a, double b, double v, double A, double a2, double tab)
        {
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function4(x) - approx(A, a2, v, x)) > Math.Abs(max))
                {
                    max = function4(x) - approx(A, a2, v, x);
                    x_max = x;
                }
            }
            return x_max;
        }
        double Searchmaxdev2(double a, double b, double v, double A, double a2, double a3, double tab)
        {
            x4Values.Clear();
            func4Values.Clear();
            inter4Values.Clear();
            error4Values.Clear();
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function4(x) - approx(A, a2, a3, v, x)) > Math.Abs(max))
                {
                    max = function4(x) - approx(A, a2, a3, v, x);
                    x_max = x;
                }
                x4Values.Add(x);
                func4Values.Add(function4(x));
                inter4Values.Add(approx(A, a2, a3, v, x));
                error4Values.Add(function4(x) - approx(A, a2, a3, v, x));
            }
            return x_max;
        }
        double Searchmaxdev2(double a, double b, double v, double A, double a2, double a3, double a4, double tab)
        {
            double max = 0;
            double x;
            double x_max = 0;
            for (int i = 0; i < tab; i++)
            {
                x = a + (i * (b - a) / tab);
                if (Math.Abs(function4(x) - approx(A, a2, a3, a4, v, x)) > Math.Abs(max))
                {
                    max = function4(x) - approx(A, a2, a3, a4, v, x);
                    x_max = x;
                }
            }
            return x_max;
        }
        //buttonEval4
        private void buttonEval4_Click(object sender, EventArgs e)
        {
            x4Values.Clear();
            func4Values.Clear();
            inter4Values.Clear();
            error4Values.Clear();
            dataGridViewParts4.DataSource = null;
            dataGridViewParts4.Rows.Clear();
            richTextBoxOutput4.Text = "";
            if (buttonEval4.BackColor != Color.FromArgb(192, 255, 192))
            {
                if (textBoxa4.Text == "" || textBoxa4.Text == "Введіть a" || textBoxb4.Text == "" || textBoxb4.Text == "Введіть b") richTextBoxOutput4.Text = "Заповніть поля a та b";
                else richTextBoxOutput4.Text = "Введіть коректні дані в поля a та b:\na i b повиннi бути числами, а < b";
            }
            else
            {
                dataGridViewParts4.ColumnCount = 4;
                dataGridViewParts4.Columns[0].Name = "Функція";
                dataGridViewParts4.Columns[1].Name = "a";
                dataGridViewParts4.Columns[2].Name = "b";
                dataGridViewParts4.Columns[3].Name = "Похибка";
                int spline = 1;
                double a4 = Convert.ToDouble(textBoxa4.Text);
                double b4 = Convert.ToDouble(textBoxb4.Text);
                int m4 = Convert.ToInt32(numericUpDownm4.Value);
                int tab4 = 200 * m4;
                int w4 = 1;
                eps4selector = comboBoxEps4.SelectedIndex;
                acc4selector = comboBoxAcc4.SelectedIndex;
                double eps4 = epsilon4setter();
                double accerr = acc4setter();
                double[] point = new double[m4 + 2];
                double[] func_p = new double[m4 + 2];
                if (m4 == 1) richTextBoxOutput4.Text += String.Format("Вигляд ланки: C1(x) = A*(x^v)\n");
                else if (m4 == 2) richTextBoxOutput4.Text += String.Format("Вигляд ланки: C2(x) = a2 + A*(x^v)\n");
                else if (m4 == 3) richTextBoxOutput4.Text += String.Format("Вигляд ланки: C3(x) = a2 + a3*x + A*(x^v)\n");
                else if (m4 == 4) richTextBoxOutput4.Text += String.Format("Вигляд ланки: C4(x) = a2 + a3*x + a4*x^2 + A*(x^v)\n");
                richTextBoxOutput4.Text += String.Format("Функція: " + comboBoxFunc4.Text + "\n");
                richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc4) + "\n");
                richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc4) + "\n");
                richTextBoxOutput4.Text += String.Format("Обрана похибка: " + comboBoxAcc4.Text);
                while (Math.Abs(a4 - b4) > eps4)
                {
                    dataGridViewParts4.Rows.Add(1);
                    bool work = true;
                    int iter = 1;
                    double error = 1;
                    while (work)
                    {
                        for (int i = 0; i < m4 + 2; i++)
                        {
                            point[i] = a4 + i * (b4 - a4) / (m4 + 1);
                        }
                        if (m4 == 1)
                        {
                            double maxerr = 1;
                            bool cont4 = true;
                            while (cont4)
                            {
                                cont4 = false;
                                for (int i = 0; i < m4 + 2; i++)
                                {
                                    func_p[i] = function4(point[i]);
                                }
                                double w = (func_p[2] + func_p[1]) / (func_p[0] + func_p[1]);
                                double v = SecantC(point[0], point[m4 + 1], w, point[0], point[1], point[2], eps4);
                                double A = (func_p[0] + func_p[1]) / (Math.Pow(point[1], v) + Math.Pow(point[0], v));
                                double[] mu2 = new double[m4 + 2];
                                for (int i = 0; i < m4 + 2; i++)
                                {
                                    mu2[i] = func_p[i] - A * Math.Pow(point[i], v);
                                }
                                double maxdevx = Searchmaxdev2(a4, b4, v, A, tab4);
                                maxerr = Math.Abs(Math.Abs(function4(maxdevx) - approx(A, v, maxdevx)) - Math.Abs(mu2[0]));

                                if (maxerr > eps4)
                                {
                                    cont4 = true;
                                    if (maxdevx < point[0])
                                    {
                                        if (Math.Sign(function4(maxdevx) - approx(A, v, maxdevx)) == Math.Sign(function4(point[0]) - approx(A, v, point[0])))
                                        {
                                            point[0] = maxdevx;
                                        }
                                        else
                                        {
                                            for (int i = m4 + 1; i > 0; i--)
                                            {
                                                point[i] = point[i - 1];
                                            }
                                            point[0] = maxdevx;
                                        }
                                    }
                                    else if (maxdevx > point[m4 + 1])
                                    {
                                        if (Math.Sign(function4(maxdevx) - approx(A, v, maxdevx)) == Math.Sign(function4(point[m4 + 1]) - approx(A, v, point[m4 + 1])))
                                        {
                                            point[m4 + 1] = maxdevx;
                                        }
                                        else
                                        {
                                            for (int i = 0; i < m4; i++)
                                            {
                                                point[i] = point[i + 1];
                                            }
                                            point[m4 + 1] = maxdevx;
                                        }
                                    }
                                    else if (maxdevx > point[0] && maxdevx < point[m4 + 1])
                                    {
                                        for (int i = 0; i < m4 + 1; i++)
                                        {
                                            if (maxdevx > point[i] && maxdevx < point[i + 1])
                                            {
                                                if (Math.Sign(function4(maxdevx) - approx(A, v, maxdevx)) == Math.Sign(function4(point[i]) - approx(A, v, point[i])))
                                                {
                                                    point[i] = maxdevx;
                                                }
                                                else
                                                {
                                                    point[i + 1] = maxdevx;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    error = Math.Abs(Math.Abs(function4(maxdevx) - approx(A, v, maxdevx)));
                                    if (iter == 1 && error < accerr)
                                    {
                                        richTextBoxOutput4.Text += String.Format("\n\nЛанка " + spline + "\n");
                                        richTextBoxOutput4.Text += String.Format("Для побудови використано 1 ітерацію");
                                        richTextBoxOutput4.Text += String.Format("\nC1(x) = " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc3) + "\n");
                                        richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc3));
                                        richTextBoxOutput4.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function4(maxdevx) - approx(A, v, maxdevx))), acc4 + 2)));
                                        dataGridViewParts4.Rows[spline - 1].Cells[0].Value = String.Format("\nC1(x) = " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")");
                                        dataGridViewParts4.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(maxdevx, acc4));
                                        addinfo2(a4, b4, v, A, tab4);
                                        a4 = b4;
                                        b4 = Convert.ToDouble(textBoxb4.Text);
                                        error = 1;
                                        work = false;
                                    }
                                    if (Math.Abs(error - accerr) < accerr * 0.01 && error < accerr)
                                    {
                                        richTextBoxOutput4.Text += String.Format("\n\nЛанка " + spline + "\n");
                                        richTextBoxOutput4.Text += String.Format("Для побудови використано " + iter + " ітерацій;");
                                        richTextBoxOutput4.Text += String.Format("\nC1(x) = " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc4) + "\n");
                                        richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc4));
                                        richTextBoxOutput4.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function4(maxdevx) - approx(A, v, maxdevx))), acc4 + 2)));
                                        dataGridViewParts4.Rows[spline - 1].Cells[0].Value = String.Format("\nC1(x) = " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")");
                                        dataGridViewParts4.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(error, acc4));
                                        addinfo2(a4, b4, v, A, tab4);
                                        a4 = b4;
                                        b4 = Convert.ToDouble(textBoxb4.Text);
                                        error = 1;
                                        work = false;
                                    }
                                    else if (error > accerr)
                                    {
                                        b4 = (a4 + b4) / 2.0;
                                        iter++;
                                    }
                                    else if (error < accerr)
                                    {
                                        b4 = a4 + (b4 - a4) * 1.5;
                                        iter++;
                                    }
                                }
                            }

                        }
                        if (m4 == 2)
                        {
                            double maxerr = 1;
                            bool cont4 = true;
                            while (cont4)
                            {
                                cont4 = false;
                                for (int i = 0; i < m4 + 2; i++)
                                {
                                    func_p[i] = function4(point[i]);
                                }
                                double w = (func_p[3] - func_p[1]) / (func_p[2] - func_p[0]);
                                double v = SecantC(a4, b4, w, point[0], point[1], point[2], point[3], eps4);
                                double A = (func_p[3] - func_p[1]) / (Math.Pow(point[3], v) - Math.Pow(point[1], v));
                                double A2 = 0.5 * (func_p[0] + func_p[3] - A * (Math.Pow(point[0], v) + Math.Pow(point[3], v)));
                                double[] mu2 = new double[m4 + 2];
                                for (int i = 0; i < m4 + 2; i++)
                                {
                                    mu2[i] = func_p[i] - A2 - A * Math.Pow(point[i], v);
                                }
                                double maxdevx = Searchmaxdev2(a4, b4, v, A, A2, tab4);
                                maxerr = Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, v, maxdevx)) - Math.Abs(mu2[0]));
                                if (maxerr > eps4)
                                {
                                    cont4 = true;
                                    if (maxdevx < point[0])
                                    {
                                        if (Math.Sign(function4(maxdevx) - approx(A, A2, v, maxdevx)) == Math.Sign(function4(point[0]) - approx(A, A2, v, point[0])))
                                        {
                                            point[0] = maxdevx;
                                        }
                                        else
                                        {
                                            for (int i = m4 + 1; i > 0; i--)
                                            {
                                                point[i] = point[i - 1];
                                            }
                                            point[0] = maxdevx;
                                        }
                                    }
                                    else if (maxdevx > point[m4 + 1])
                                    {
                                        if (Math.Sign(function4(maxdevx) - approx(A, A2, v, maxdevx)) == Math.Sign(function4(point[m4 + 1]) - approx(A, A2, v, point[m4 + 1])))
                                        {
                                            point[m4 + 1] = maxdevx;
                                        }
                                        else
                                        {
                                            for (int i = 0; i < m4; i++)
                                            {
                                                point[i] = point[i + 1];
                                            }
                                            point[m4 + 1] = maxdevx;
                                        }
                                    }
                                    else if (maxdevx > point[0] && maxdevx < point[m4 + 1])
                                    {
                                        for (int i = 0; i < m4 + 1; i++)
                                        {
                                            if (maxdevx > point[i] && maxdevx < point[i + 1])
                                            {
                                                if (Math.Sign(function4(maxdevx) - approx(A, A2, v, maxdevx)) == Math.Sign(function4(point[i]) - approx(A, A2, v, point[i])))
                                                {
                                                    point[i] = maxdevx;
                                                }
                                                else
                                                {
                                                    point[i + 1] = maxdevx;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    error = Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, v, maxdevx)));
                                    if (iter == 1 && error < accerr)
                                    {
                                        richTextBoxOutput4.Text += String.Format("\n\nЛанка " + spline + "\n");
                                        richTextBoxOutput4.Text += String.Format("Для побудови використано 1 ітерацію");
                                        richTextBoxOutput4.Text += String.Format("\nC2(x) = " + Math.Round(a4, acc4) + " + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc3) + "\n");
                                        richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc3));
                                        richTextBoxOutput4.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, v, maxdevx))), acc4 + 2)));
                                        dataGridViewParts4.Rows[spline - 1].Cells[0].Value = String.Format("\nC2(x) = " + Math.Round(a4, acc4) + " + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        dataGridViewParts4.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(maxdevx, acc4));
                                        addinfo2(a4, b4, v, A, A2, tab4);
                                        a4 = b4;
                                        b4 = Convert.ToDouble(textBoxb4.Text);
                                        error = 1;
                                        work = false;
                                    }
                                    if (Math.Abs(error - accerr) < accerr * 0.01 && error < accerr)
                                    {
                                        richTextBoxOutput4.Text += String.Format("\n\nЛанка " + spline + "\n");
                                        richTextBoxOutput4.Text += String.Format("Для побудови використано " + iter + " ітерацій;");
                                        richTextBoxOutput4.Text += String.Format("\nC2(x) = " + Math.Round(a4, acc4) + " + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc4) + "\n");
                                        richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc4));
                                        richTextBoxOutput4.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, v, maxdevx))), acc4 + 2)));
                                        dataGridViewParts4.Rows[spline - 1].Cells[0].Value = String.Format("\nC2(x) = " + Math.Round(a4, acc4) + " + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        dataGridViewParts4.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(error, acc4));
                                        addinfo2(a4, b4, v, A, A2, tab4);
                                        a4 = b4;
                                        b4 = Convert.ToDouble(textBoxb4.Text);
                                        error = 1;
                                        work = false;
                                    }
                                    else if (error > accerr)
                                    {
                                        b4 = (a4 + b4) / 2.0;
                                        iter++;
                                    }
                                    else if (error < accerr)
                                    {
                                        b4 = a4 + (b4 - a4) * 1.5;
                                        iter++;
                                    }
                                }
                            }

                        }
                        if (m4 == 4)
                        {
                            double maxerr = 1;
                            bool cont4 = true;
                            while (cont4)
                            {
                                cont4 = false;
                                for (int i = 0; i < m4 + 2; i++)
                                {
                                    func_p[i] = function4(point[i]);
                                }
                                double[] Fbig = new double[m4];
                                for (int i = 0; i < m4; i++)
                                {
                                    Fbig[i] = (func_p[i + 2] - func_p[i]) / (point[i + 2] - point[i]);
                                }
                                double w = ((Fbig[3] - Fbig[2]) / (point[5] + point[3] - point[4] - point[2]) - (Fbig[2] - Fbig[1]) / (point[4] + point[2] - point[3] - point[1])) / ((Fbig[2] - Fbig[1]) / (point[4] + point[2] - point[3] - point[1]) - (Fbig[1] - Fbig[0]) / (point[3] + point[1] - point[2] - point[0]));
                                double v = SecantC(a4, b4, w, point[0], point[1], point[2], point[3], point[4], point[5], eps4);
                                double A = ((Fbig[3] - Fbig[2]) / (point[5] - point[4] + point[3] - point[2]) - (Fbig[2] - Fbig[1]) / (point[4] - point[3] + point[2] - point[1])) / ((Etha4(3, point[3], point[5], v) - Etha4(2, point[2], point[4], v)) / (point[5] - point[4] + point[3] - point[2]) - (Etha4(2, point[2], point[4], v) - Etha4(1, point[1], point[3], v)) / (point[4] - point[3] + point[2] - point[1]));
                                double A4 = (Fbig[3] - Fbig[2] - A * (Etha4(3, point[3], point[5], v) - Etha4(2, point[2], point[4], v))) / (point[5] - point[4] + point[3] - point[2]);
                                double A3 = (func_p[5] - func_p[3] - A4 * (Math.Pow(point[5], 2) - Math.Pow(point[3], 2)) - A * (Math.Pow(point[5], v) - Math.Pow(point[3], v))) / (point[5] - point[3]);
                                double A2 = (func_p[5] + func_p[0] - A4 * (Math.Pow(point[5], 2) + Math.Pow(point[0], 2)) - A3 * (point[5] + point[0]) - A * (Math.Pow(point[5], v) + Math.Pow(point[0], v))) / 2;
                                double[] mu2 = new double[m4 + 2];
                                for (int i = 0; i < m4 + 2; i++)
                                {
                                    mu2[i] = func_p[i] - A2 - A3 * point[i] - A4 * Math.Pow(point[i], 2) - A * Math.Pow(point[i], v);
                                }
                                double maxdevx = Searchmaxdev2(a4, b4, v, A, A2, A3, A4, tab4);
                                maxerr = Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) - Math.Abs(mu2[0]));
                                if (maxerr > eps4)
                                {
                                    cont4 = true;
                                    if (maxdevx < point[0])
                                    {
                                        if (Math.Sign(function4(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) == Math.Sign(function4(point[0]) - approx(A, A2, A3, A4, v, point[0])))
                                        {
                                            point[0] = maxdevx;
                                        }
                                        else
                                        {
                                            for (int i = m4 + 1; i > 0; i--)
                                            {
                                                point[i] = point[i - 1];
                                            }
                                            point[0] = maxdevx;
                                        }
                                    }
                                    else if (maxdevx > point[m4 + 1])
                                    {
                                        if (Math.Sign(function4(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) == Math.Sign(function4(point[m4 + 1]) - approx(A, A2, A3, A4, v, point[m4 + 1])))
                                        {
                                            point[m4 + 1] = maxdevx;
                                        }
                                        else
                                        {
                                            for (int i = 0; i < m4; i++)
                                            {
                                                point[i] = point[i + 1];
                                            }
                                            point[m4 + 1] = maxdevx;
                                        }
                                    }
                                    else if (maxdevx > point[0] && maxdevx < point[m4 + 1])
                                    {
                                        for (int i = 0; i < m4 + 1; i++)
                                        {
                                            if (maxdevx > point[i] && maxdevx < point[i + 1])
                                            {
                                                if (Math.Sign(function4(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)) == Math.Sign(function4(point[i]) - approx(A, A2, A3, A4, v, point[i])))
                                                {
                                                    point[i] = maxdevx;
                                                }
                                                else
                                                {
                                                    point[i + 1] = maxdevx;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    error = Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, A3, A4, v, maxdevx)));
                                    if (iter == 1 && error < accerr)
                                    {
                                        richTextBoxOutput4.Text += String.Format("\n\nЛанка " + spline + "\n");
                                        richTextBoxOutput4.Text += String.Format("Для побудови використано 1 ітерацію");
                                        richTextBoxOutput4.Text += String.Format("\nC4(x) = " + Math.Round(A2, acc4) + " + " + Math.Round(A3, acc4) + "*x + " + Math.Round(A4, acc4) + "*x^2 + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc4) + "\n");
                                        richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc4));
                                        richTextBoxOutput4.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, v, maxdevx))), acc4 + 2)));
                                        dataGridViewParts4.Rows[spline - 1].Cells[0].Value = String.Format("\nC2(x) = " + Math.Round(a4, acc4) + " + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        dataGridViewParts4.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(maxdevx, acc4));
                                        addinfo2(a4, b4, v, A, A2, A3, A4, tab4);
                                        a4 = b4;
                                        b4 = Convert.ToDouble(textBoxb4.Text);
                                        error = 1;
                                        work = false;
                                    }
                                    if (Math.Abs(error - accerr) < accerr * 0.01 && error < accerr)
                                    {
                                        richTextBoxOutput4.Text += String.Format("\n\nЛанка " + spline + "\n");
                                        richTextBoxOutput4.Text += String.Format("Для побудови використано " + iter + " ітерацій;");
                                        richTextBoxOutput4.Text += String.Format("\nC4(x) = " + Math.Round(A2, acc4) + " + " + Math.Round(A3, acc4) + "*x + " + Math.Round(A4, acc4) + "*x^2 + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        richTextBoxOutput4.Text += String.Format("а = " + Math.Round(a4, acc4) + "\n");
                                        richTextBoxOutput4.Text += String.Format("b = " + Math.Round(b4, acc4));
                                        richTextBoxOutput4.Text += String.Format("\nНайбільша похибка = " + Math.Abs(Math.Round(Math.Abs(Math.Abs(function4(maxdevx) - approx(A, A2, v, maxdevx))), acc4 + 2)));
                                        dataGridViewParts4.Rows[spline - 1].Cells[0].Value = String.Format("\nC2(x) = " + Math.Round(a4, acc4) + " + " + Math.Round(A, acc4) + "*x^(" + Math.Round(v, acc4) + ")\n");
                                        dataGridViewParts4.Rows[spline - 1].Cells[1].Value = Convert.ToString(Math.Round(a4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[2].Value = Convert.ToString(Math.Round(b4, acc4));
                                        dataGridViewParts4.Rows[spline - 1].Cells[3].Value = Convert.ToString(Math.Round(error, acc4));
                                        addinfo2(a4, b4, v, A, A2, A3, A4, tab4);
                                        a4 = b4;
                                        b4 = Convert.ToDouble(textBoxb4.Text);
                                        error = 1;
                                        work = false;
                                    }
                                    else if (error > accerr)
                                    {
                                        b4 = (a4 + b4) / 2.0;
                                        iter++;
                                    }
                                    else if (error < accerr)
                                    {
                                        b4 = a4 + (b4 - a4) * 1.5;
                                        iter++;
                                    }
                                }
                            }
                        }
                        //else break;
                    }
                    spline++;
                }
                PaintP4(Convert.ToDouble(textBoxa4.Text), Convert.ToDouble(textBoxb4.Text), acc4);
                dataGridViewParts4.ClearSelection();
            }
        }
        //////////////////////////////////////////////////////////graphs//////////////////////////////////////////////////////////////////////
        private void buttonZoomReset4_Click(object sender, EventArgs e)
        {
            chartApprox4.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartApprox4.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
            chartError4.ChartAreas[0].AxisX.ScaleView.ZoomReset(100);
            chartError4.ChartAreas[0].AxisY.ScaleView.ZoomReset(100);
        }
        private void PaintP4(double min, double max, int acc)
        {
            chartApprox4.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartApprox4.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartApprox4.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartApprox4.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartApprox4.Invalidate();
            chartError4.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartError4.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chartError4.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chartError4.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chartError4.Invalidate();
            chartApprox4.Series["F(x)"].Points.Clear();
            chartApprox4.Series["S(A,x)"].Points.Clear();
            chartError4.Series["F(x) - S(A,x)"].Points.Clear();
            chartApprox4.Series["F(x)"].Points.DataBindXY(x4Values, func4Values);
            chartApprox4.Series["S(A,x)"].Points.DataBindXY(x4Values, inter4Values);
            chartError4.Series["F(x) - S(A,x)"].Points.DataBindXY(x4Values, error4Values);
            ChartArea CAI4 = chartApprox4.ChartAreas[0];
            CAI4.AxisX.ScaleView.Zoomable = true;
            CAI4.AxisY.ScaleView.Zoomable = true;
            CAI4.CursorY.AutoScroll = true;
            CAI4.CursorY.IsUserSelectionEnabled = true;
            CAI4.CursorX.AutoScroll = true;
            CAI4.CursorX.IsUserSelectionEnabled = true;
            ChartArea CAE4 = chartError4.ChartAreas[0];
            CAE4.AxisX.ScaleView.Zoomable = true;
            CAE4.AxisY.ScaleView.Zoomable = true;
            CAE4.CursorY.AutoScroll = true;
            CAE4.CursorY.IsUserSelectionEnabled = true;
            CAE4.CursorX.AutoScroll = true;
            CAE4.CursorX.IsUserSelectionEnabled = true;
            chartApprox4.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartApprox4.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError4.ChartAreas[0].CursorX.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));
            chartError4.ChartAreas[0].CursorY.Interval = 1 / Math.Pow(10, Convert.ToDouble(acc));

        }

    }
}
