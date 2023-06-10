using MaterialSkin;
using MaterialSkin.Controls;
using System.Data;
using Microsoft.EntityFrameworkCore;
using laboratorna.Model;
using laboratorna.Data;
using laboratornaEntityFramework;

namespace laboratorna
{
  
    public partial class Form1 : MaterialForm
    {
        public static bool LoginTeacherInSystem = true;

        TeacherEntity loginTeachers = new TeacherEntity();
        StudentEntity loginStudents = new StudentEntity();

        public Form1()
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

    
        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(materialMaskedTextBox1.Text))
            {
                MessageBox.Show("Please enter login", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialMaskedTextBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(materialMaskedTextBox2.Text))
            {
                MessageBox.Show("Please enter password", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialMaskedTextBox2.Focus();
                return;
            }
            if (LoginTeacherInSystem == true)
            { 
                using (var context = new ApplicationDbContext())
                {
                    var LoginTeacher = context.Teachers.FirstOrDefault(u => u.Login == materialMaskedTextBox1.Text && u.Password == materialMaskedTextBox2.Text);

                if (LoginTeacher != null)
                    {
                        loginTeachers.Login = LoginTeacher.Login;
                        MessageBox.Show("You have successfully logged into your account!!!", "Åntered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Ëîã³í òà ïàðîëü â³ðí³, âèêîíóºìî íåîáõ³äí³ ä³¿
                        LoadCourse();
                        materialTabControl1.SelectTab(tabPage2);
                    }
                    else
                    {
                        MessageBox.Show("Password or login entered is incorrect", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                }
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {
                    var LoginStudent = context.Students.FirstOrDefault(u => u.Login == materialMaskedTextBox1.Text && u.Password == materialMaskedTextBox2.Text);

                    if (LoginStudent != null)
                    {
                       loginStudents.Login = LoginStudent.Login;
                        MessageBox.Show("You have successfully logged into your account!!!", "Åntered", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadCourse();

                        materialTabControl1.SelectTab(tabPage2);
                    }
                    else
                    {
                        MessageBox.Show("Password or login entered is incorrect", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (LoginTeacherInSystem == true)
            {
                LoginTeacherInSystem = false;
                label1.Text = "I'm teacher";
                label2.Text = "New student";
                materialTextBox21.Visible = false;
                materialTextBox22.Visible = false;
                materialButton3.Visible = false;
                materialButton4.Visible = false;
                materialButton5.Visible = true;
            }
            else
            {
                LoginTeacherInSystem = true;
                label1.Text = "I'm student";
                label2.Text = "New teacher";
                materialTextBox21.Visible = true;
                materialTextBox22.Visible = true;
                materialButton3.Visible = true;
                materialButton4.Visible = true;
                materialButton5.Visible = false;
            }
        }

        private void LoadCourse()
        {
            if (LoginTeacherInSystem == true)
            { 
                using (var context = new ApplicationDbContext())
                {
                    var LoginTeacher = context.Teachers.FirstOrDefault(u => u.Login == loginTeachers.Login);
                    var courses = context.Courses.Include(p => p.Teacher)
                        .Where(b => b.Teacher.Login == LoginTeacher.Login)
                        .ToList();
                    CoursesdataGridView1.Rows.Clear();
                    foreach (var course in courses)
                    {
                        CoursesdataGridView1.Rows.Add(course.Id, course.Name, course.Description, course.Teacher.Name + " " + course.Teacher.Surname);
                    }
                }
            }
            else {
                using (var context = new ApplicationDbContext())
                { 
                    var courses = context.Courses.Include(p => p.Teacher);
                    CoursesdataGridView1.Rows.Clear();
                    foreach (var course in courses)
                    {
                        CoursesdataGridView1.Rows.Add(course.Id, course.Name, course.Description, course.Teacher.Name + " " + course.Teacher.Surname);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            materialMaskedTextBox2.UseSystemPasswordChar = false;

            label1.Font = new Font("Arial", 12, FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = Color.RoyalBlue;
            label3.Font = new Font("Microsoft Sans Serif", 12);
            label4.Font = new Font("Microsoft Sans Serif", 12); 
            label2.Font = new Font("Arial", 12, FontStyle.Underline, GraphicsUnit.Point);
            label2.ForeColor = Color.RoyalBlue;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            
            register.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            materialMaskedTextBox2.UseSystemPasswordChar = false; 
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            materialMaskedTextBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;     
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            DataGridViewRow CourseData = CoursesdataGridView1.SelectedRows[0];
            using (var context = new ApplicationDbContext())
            {
                
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(materialTextBox21.Text))
            {
                MessageBox.Show("Please enter name new course", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                materialTextBox21.Focus();
                return;
            }
            using (var context = new ApplicationDbContext())
            {
                var LoginTeacher = context.Teachers.FirstOrDefault(u => u.Login == loginTeachers.Login);
                CourseEntity newCourse = new CourseEntity();
                newCourse.Name = materialTextBox21.Text;
                newCourse.Description = materialTextBox21.Text;
                newCourse.Teacher = LoginTeacher;
               
                context.Courses.Add(newCourse);

                context.SaveChanges();
                LoadCourse();
            }
            materialTextBox21.Text = "";
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var LoginStudents = context.Students.FirstOrDefault(u => u.Login == loginStudents.Login);
                //DataGridViewRow CourseData = CoursesdataGridView1.SelectedRows[0];
                int index = CoursesdataGridView1.CurrentCell.RowIndex;
               // string id = CoursesdataGridView1.Rows[index].Cells[0].Value.ToString();
                string name = CoursesdataGridView1.Rows[index].Cells[1].Value.ToString();
                //string id2 = CourseData.Cells[index].Value.ToString();
                var course = context.Courses.FirstOrDefault(u => u.Name == name);
                //  course.EnrolledStudents = new List<Student>(LoginStudents); 
                context.SaveChanges();
            }
            materialTabControl1.SelectTab(tabPage3);
            
        }
    }
}