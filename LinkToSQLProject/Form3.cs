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
    public partial class Form3 : Form
    {
        CompanyDBDataContext dc;
       
        public Form3()
        {
            InitializeComponent();
        }
        private void loaddata()
        {
            dc = new CompanyDBDataContext();
            dgView.DataSource = dc.Employees;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
            loaddata();

        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count > 0)
            {
                Form4 form = new Form4();
                form.textBox1.ReadOnly= true;
                form.textBox1.Text = dgView.SelectedRows[0].Cells[0].Value.ToString();
                form.textBox2.Text = dgView.SelectedRows[0].Cells[1].Value.ToString();
                form.textBox3.Text = dgView.SelectedRows[0].Cells[2].Value.ToString();
                form.textBox4.Text = dgView.SelectedRows[0].Cells[3].Value.ToString();
                form.textBox5.Text = dgView.SelectedRows[0].Cells[4].Value.ToString();
                form.ShowDialog();
                loaddata();
            }
            else
            {
                MessageBox.Show("please select the record for updation.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dgView.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure of deleting the selected record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CompanyDBDataContext dc = new CompanyDBDataContext();

                    int Eno = Convert.ToInt32(dgView.SelectedRows[0].Cells[0].Value);

                    Employee obj = dc.Employees.SingleOrDefault(E => E.Eno == Eno);

                    if (obj != null)
                    {
                        dc.Employees.DeleteOnSubmit(obj);
                        dc.SubmitChanges();
                        MessageBox.Show("Record deleted successfully!");
                        dgView.DataSource = dc.Employees.ToList();
                    }
                }
            }
            else
            {
                MessageBox.Show("please select the record for Deletion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
            
        }
    }
