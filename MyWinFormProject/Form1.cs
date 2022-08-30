using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWinFormProject.Entities;

namespace MyWinFormProject
{
    public partial class Form1 : Form
    {

        Detail MyDetail = new Detail();
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            PopGridView();
        }

        private void PopGridView()
        {
            using (var MyModelEntities = new MyModel())
            {
                dataGridView1.DataSource = MyModelEntities.Details.ToList<Detail>();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyDetail.Name = txtName.Text;
            MyDetail.Surname = txtSname.Text;
            MyDetail.Age = Convert.ToInt32(txtAge.Text);
            MyDetail.Address = txtAddress.Text;
            MyDetail.BirthDate = Convert.ToDateTime(dtDOB.Text);


            using (var MyDbEntities = new MyModel())
            {

              
                    MyDbEntities.Details.Add(MyDetail);
                    MyDbEntities.SaveChanges();
                    btnSave.Text = "Save";
                    MyDetail.Id = 0;
                    ClearFields();

                MessageBox.Show("Data Saved","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                
              
            }

            PopGridView();
        }

     

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MyDetail.Name = txtName.Text;
            MyDetail.Surname = txtSname.Text;
            MyDetail.Age = Convert.ToInt32(txtAge.Text);
            MyDetail.Address = txtAddress.Text;
            MyDetail.BirthDate = Convert.ToDateTime(dtDOB.Text);


            using (var MyDbEntities = new MyModel())
            {

              
                    MyDbEntities.Entry(MyDetail).State = System.Data.Entity.EntityState.Modified;
                    MyDbEntities.SaveChanges();

                MessageBox.Show("Data Updated", "Modified", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();

            }

            PopGridView();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index != -1)
            {
                MyDetail.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                using (var MyDbEntities = new MyModel())
                {
                    MyDetail = MyDbEntities.Details.Where(x => x.Id == MyDetail.Id).FirstOrDefault();
                    txtName.Text = MyDetail.Name;
                    txtAddress.Text = MyDetail.Address;
                    txtSname.Text = MyDetail.Surname;
                    txtAge.Text = MyDetail.Age.ToString();
                    dtDOB.Text = MyDetail.BirthDate.ToString();


                    //btnSave.Text = "Update";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure want to delete this information?", "Please Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var MyDbEntities = new MyModel())
                {
                    var entry = MyDbEntities.Entry(MyDetail);

                    if (entry.State == System.Data.Entity.EntityState.Detached)
                    {
                        MyDbEntities.Details.Attach(MyDetail);

                        MyDbEntities.Details.Remove(MyDetail);
                        MyDbEntities.SaveChanges();
                        PopGridView();
                        ClearFields();
                        
                    }
                }
            }
        }


        void ClearFields()
        {
            txtName.Text = "";
            txtSname.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            dtDOB.Text = DateTime.Now.ToString();
        }
    }
}
