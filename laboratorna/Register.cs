using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using laboratorna.Data;
using laboratorna.Model;
using MaterialSkin;
using MaterialSkin.Controls;

namespace laboratorna
{
    public partial class Register : MaterialForm
    {
        public Register()
        {
            InitializeComponent();
            
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        
        //ApplicationDbContext _dbContext= 

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(materialTextBox1.Text))
            {
                MessageBox.Show("Please enter login", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(materialTextBox2.Text))
            {
                MessageBox.Show("Please enter name", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(materialTextBox3.Text))
            {
                MessageBox.Show("Please enter surname", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox3.Focus();
                return;
            }
            if (string.IsNullOrEmpty(materialTextBox4.Text))
            {
                MessageBox.Show("Please enter password", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox4.Focus();
                return;
            }
            if (Form1.LoginTeacherInSystem)
            {
                using (var context = new ApplicationDbContext())
                {
                    var searchForTheSame = context.Teachers.FirstOrDefault(u => u.Login == materialTextBox1.Text);
                    if (searchForTheSame != null)
                    {
                        MessageBox.Show("This login is already in use!", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        TeacherEntity newteacher = new TeacherEntity();
                        newteacher.Login = materialTextBox1.Text;
                        newteacher.Name = materialTextBox2.Text;
                        newteacher.Surname = materialTextBox3.Text;
                        newteacher.Password = materialTextBox4.Text;
                        context.Teachers.Add(newteacher);
                        context.SaveChanges();
                        MessageBox.Show("New teacher has been add", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   
                }
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {
                    var searchForTheSame = context.Students.FirstOrDefault(u => u.Login == materialTextBox1.Text);
                    if (searchForTheSame != null)
                    {
                        MessageBox.Show("This login is already in use!", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        StudentEntity newstudent = new StudentEntity();
                        newstudent.Login = materialTextBox1.Text;
                        newstudent.Name = materialTextBox2.Text;
                        newstudent.Surname = materialTextBox3.Text;
                        newstudent.Password = materialTextBox4.Text;
                        context.Students.Add(newstudent);
                        context.SaveChanges();
                        MessageBox.Show("New student has been add", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            materialTextBox1.Text = "";
            materialTextBox2.Text = "";
            materialTextBox3.Text = "";
            materialTextBox4.Text = "";
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Microsoft Sans Serif", 12);
            label2.Font = new Font("Microsoft Sans Serif", 12);
            label3.Font = new Font("Microsoft Sans Serif", 12);
            label4.Font = new Font("Microsoft Sans Serif", 12);
        }
    }
}
