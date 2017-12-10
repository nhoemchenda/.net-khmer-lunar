using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KhmerLunar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime tDate = DateTime.Parse("2018-01-01");
            textBox1.Text = tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2018-02-25");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2018-02-28");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2018-03-31");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2018-06-30");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2018-08-02");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2018-12-31");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);

            tDate = DateTime.Parse("2017-12-31");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2017-01-01");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2017-04-30");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2017-06-15");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2017-09-09");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);


            tDate = DateTime.Parse("2014-06-15");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2012-05-26");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            tDate = DateTime.Parse("2015-12-26");
            textBox1.Text = textBox1.Text + "\r\n" + tDate.ToString("yyyy-MM-dd") + " => " + KhmerLunarLib.KhmerLunar.getKhmerLunarString(tDate);
            
            /*Build predifined
            DateTime tmp = DateTime.Parse("1900-01-01");
            while (tmp.Year <= 2100)
            {
                Console.WriteLine("hsYear.Add("+tmp.Year.ToString()+", " + KhmerLunarLib.KhmerLunar.getKhmerLunarCode(tmp) + ");");
                tmp = tmp.AddYears(1);
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = KhmerLunarLib.KhmerLunar.getKhmerLunarString(dateTimePicker1.Value);
        }
    }
}
