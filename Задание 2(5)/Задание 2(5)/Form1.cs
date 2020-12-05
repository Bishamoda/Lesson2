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

namespace Задание_2_5_
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        


        public void button1_Click(object sender, EventArgs e)
        {
            String Filename = textBox1.Text;

            TextWriter sw = new StreamWriter(@"C:\Users\Mike\Desktop\" + Filename + ".txt");


            try
            {

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {                      
                        sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + (" "));
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
            }

            label9.Text = "Запись прошла успешно";
        }




        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
           
            int n, m;

            n = dataGridView1.Columns.Count;
            label6.Text = n.ToString();

            m = dataGridView1.Rows.Count;
            label8.Text = m.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void button3_Click(object sender, EventArgs e)
        {

            bool btn = true;
            if (btn == true)
            {
                

                String Filename = textBox1.Text;

                DataTable table = new DataTable();


                StreamReader rd = new StreamReader(@"C:\Users\Mike\Desktop\" + Filename + ".txt");
                string[] str;
                int num = 0;

                try
                {
                    string[] str1 = rd.ReadToEnd().Split('\n');
                    num = str1.Count();
                  

                    dataGridView2.RowCount = num;

                    for (int i = 0; i < num; i++)
                    {
                        
                            str = str1[i].Split(' ');
                        
                        
                        
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            try
                            {

                                dataGridView2.Rows[i].Cells[j].Value = str[j];
                            }

                            catch { }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    rd.Close();
                }

                dataGridView2.AllowUserToAddRows = false;
            }


            textBox2_TextChanged();
        }

        public void textBox2_TextChanged()
        {
            String Filename = textBox1.Text;
            string m = File.ReadAllText(@"C:\Users\Mike\Desktop\" + Filename + ".txt");
            
            textBox2.Text = "№"+ " Name" + " Age" + Environment.NewLine + m;

        }


        

    }
}
