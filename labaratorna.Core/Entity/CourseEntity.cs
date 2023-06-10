
namespace laboratorna.Model
{

    public class CourseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<StudentEntity> EnrolledStudents { get; set; }
       // public List<Student> EnrolledStudents { get; set; }
        public TeacherEntity Teacher { get; set; }
       // public List<Grade> Grades { get; set; }
       //2 public ICollection<Grade> Grades { get; set; }
        

        //Course(string name, string description, List<Student> enrolledStudents, Teacher teacher, List<Grade> grades)
        //{
        //    Name = name;
        //    Description = description;
        //    EnrolledStudents = enrolledStudents;
        //    Teacher = teacher;
        //    Grades = grades;
        //}
    }
}
