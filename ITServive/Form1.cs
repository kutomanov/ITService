using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ITServive
{
    public partial class Form1 : Form
    {
        private string name;
        private int number;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                name = openFileDialog1.FileName;
                comboBox1.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = File.ReadLines(name).First();
                if (File.ReadLines(name).First().Equals("Задание 2"))
                {
                    textBox1.Text = File.ReadLines(name).Skip(2).First();
                }
                else
                {
                    textBox1.Text = File.ReadLines(name).Skip(2).First() + "\r\n" + File.ReadLines(name).Skip(3).First();
                }                          
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals(""))
            {
                label1.Text = "Выберите задание";
            }
            else if (comboBox1.Text.Equals("Задание 1") && saveFileDialog1.ShowDialog() == DialogResult.OK)    //этот метод вызывает окно диалога и возвращает значение, когда нажата ОК
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, comboBox1.Text + "\r\n" + "\r\n" + textBox1.Text + "\r\n" + textBox2.Text); //метод file пишет
            }
            else if (comboBox1.Text.Equals("Задание 2") && saveFileDialog1.ShowDialog() == DialogResult.OK)    //этот метод вызывает окно диалога и возвращает значение, когда нажата ОК
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, comboBox1.Text + "\r\n" + "\r\n" + textBox1.Text); //метод file пишет
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Задание 1"))
            {
                label1.Text = "";
                textBox2.Text = "";
                if (textBox1.Text == "")
                {
                    label1.Text = "Введите условие для Задания 1";
                }
                else
                {
                    try
                    {
                        string s1 = textBox1.Lines.First();
                        string s2 = textBox1.Lines.Skip(1).First();

                        string[] array1 = s1.Split(' ', ',');
                        string[] array2 = s2.Split(' ', ',');
                        List<string> list = new List<string>();

                        for (int i = 0; i < array1.Length; i++)
                        {
                            for (int j = 0; j < array2.Length; j++)
                            {
                                if (array2[j].Contains(array1[i]))
                                {
                                    list.Add(array1[i] + " ");
                                }
                            }
                        }

                        IEnumerable<String> noduplicates = list.Distinct();
                        list.Sort();
                        foreach (var name in noduplicates)
                        {
                            textBox2.Text += name;
                        }
                    }
                    catch (System.InvalidOperationException)
                    {
                        label1.Text = "Условие не соответствует Заданию 1";
                    }

                }
            }

            else if (comboBox1.Text.Equals("Задание 2"))
            {
                label1.Text = "";
                textBox2.Text = "";
                if (textBox1.Text == "")
                {
                    label1.Text = "Введите условие для Задания 2";
                }
                else
                {
                    try
                    {
                        number = Convert.ToInt32(textBox1.Text);
                        int n = number;
                        int ed, des, sot, tis;
                        if (textBox1.Text.Length == 1)
                        {
                            ed = (n % 10);
                            textBox2.Text = ed.ToString();
                        }
                        else if (textBox1.Text.Length == 2)
                        {
                            des = (n % 100) - (n % 10);
                            ed = (n % 10);
                            if (ed == 0)
                            {
                                textBox2.Text = des.ToString();
                            }
                            else
                            {
                                textBox2.Text = des.ToString() + " + " + ed.ToString();
                            }
                        }
                        else if (textBox1.Text.Length == 3)
                        {
                            sot = (n % 1000) - (n % 100);
                            des = (n % 100) - (n % 10);
                            ed = (n % 10);
                            if (ed == 0 && des == 0)
                            {
                                textBox2.Text = sot.ToString();
                            }
                            else if (des == 0)
                            {
                                textBox2.Text = sot.ToString() + " + " + ed.ToString();
                            }
                            else if (ed == 0)
                            {
                                textBox2.Text = sot.ToString() + " + " + des.ToString();
                            }
                            else
                            {
                                textBox2.Text = sot.ToString() + " + " + des.ToString() + " + " + ed.ToString();
                            }
                        }
                        else
                        {
                            tis = n - (n % 1000);
                            sot = (n % 1000) - (n % 100);
                            des = (n % 100) - (n % 10);
                            ed = (n % 10);
                            if (ed == 0 && des == 0 && sot == 0)
                            {
                                textBox2.Text = tis.ToString();
                            }
                            else if (des == 0 && sot == 0)
                            {
                                textBox2.Text = tis.ToString() + " + " + ed.ToString();
                            }
                            else if (sot == 0 && ed == 0)
                            {
                                textBox2.Text = tis.ToString() + " + " + des.ToString();
                            }
                            else if (des == 0 && ed == 0)
                            {
                                textBox2.Text = tis.ToString() + " + " + sot.ToString();
                            }
                            else if (des == 0)
                            {
                                textBox2.Text = tis.ToString() + " + " + sot.ToString() + " + " + ed.ToString();
                            }
                            else if (sot == 0)
                            {
                                textBox2.Text = tis.ToString() + " + " + des.ToString() + " + " + ed.ToString();
                            }
                            else if (ed == 0)
                            {
                                textBox2.Text = tis.ToString() + " + " + sot.ToString() + " + " + des.ToString();
                            }
                            else
                            {
                                textBox2.Text = tis.ToString() + " + " + sot.ToString() + " + " + des.ToString() + " + " + ed.ToString();
                            }
                        }
                    }
                    catch (System.FormatException)
                    {
                        label1.Text = "Условие не соответствует Заданию 2";
                        textBox2.Clear();
                    }
                }
            }
            else
            {
                label1.Text = "Выберите задание";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
