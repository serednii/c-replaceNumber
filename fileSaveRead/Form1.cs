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
using System.Text.RegularExpressions;


namespace fileSaveRead
{
    public partial class Form1 : Form
    {
        private string name;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
                textBox2.Text = textBox1.Text;

                Regex regex = new Regex("[+]{0,1}[0-9]{3,5}-[0-9]{3}-[0-9]{2}-[0-9]{0,2}");
                MatchCollection matches = regex.Matches(textBox1.Text);
                if (matches.Count > 0)
                {
                    Random rnd = new Random(); 
                    foreach (Match match in matches)
                    {
                        //textBox2.Text = textBox2.Text + match.Value + "    ";
                        
                        char[] temp = match.Value.ToCharArray();
                        int lengthText = temp.Length;
                        int counter = 0;
                        do
                        {
                           int number =  rnd.Next(0, lengthText);
                            if(temp[number] != '*' && (temp[number] >= '0' && temp[number]<='9'))
                            {
                                temp[number] = '*';
                                counter++;

                            }
                        } while (counter<3);
                        //string tt = new string(temp);
                        //textBox2.Text = textBox2.Text + " @@@ " + tt +" @@@ "+ "    ";
                        textBox1.Text= textBox1.Text.Replace(match.Value, new string(temp));
                        //Console.WriteLine(tt);
                    }
                    
                    
                        
                }
                else
                {
                    Console.WriteLine("Совпадений не найдено");
                }
                //int start = textBox1.Text.IndexOf("+380");
               // textBox2.Text = start.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }
    }
}
