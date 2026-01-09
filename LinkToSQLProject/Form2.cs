using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkToSQLProject
{
    public partial class Form2 : Form
    {
        CompanyDBDataContext dc;
        List<Employee> emps;
        int rno = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dc=new CompanyDBDataContext();
            emps= dc.Employees.ToList();
            showData();
        }
        private void showData()
        {
            textBox1.Text=emps[rno].Eno.ToString();
            textBox2.Text = emps[rno].Ename;
            textBox3.Text = emps[rno].Job;
            textBox4.Text = emps[rno].Salary.ToString();
            textBox5.Text = emps[rno].Dname.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rno > 0)
            {
                rno -= 1;
                showData();
            }
            else
            {
                MessageBox.Show("First Record of the Table.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(rno<emps.Count-1)
            {
                rno += 1;
                showData();
            }
            else
            {
                MessageBox.Show("Last Record of the Table.");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
