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
    public partial class Form4 : Form
    {
        internal readonly object btnClear;
        Employee obj=new Employee();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompanyDBDataContext dc=new CompanyDBDataContext();
            Employee obj = new Employee();
            if (textBox1.ReadOnly == false)
            {

                obj.Eno = int.Parse(textBox1.Text);
                obj.Ename = textBox2.Text;
                obj.Job = textBox3.Text;
                obj.Salary = decimal.Parse(textBox4.Text);
                obj.Dname = textBox5.Text;

                dc.Employees.InsertOnSubmit(obj);
                dc.SubmitChanges();
                MessageBox.Show("RECORD INSERTED INTO THE TABLE");
            }
            else
            {
                obj=dc.Employees.SingleOrDefault(E=> E.Eno== int.Parse(textBox1.Text));
                obj.Ename= textBox2.Text;
                obj.Job = textBox3.Text;
                obj.Salary= int.Parse(textBox4.Text);
                obj.Dname = textBox5.Text;
                dc.SubmitChanges();
                MessageBox.Show("Record updated in the Table.");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox tb=ctrl as TextBox;
                    tb.Clear();
                }
            }
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
