

namespace laboratorna.Model
{
    public class StudentEntity: PersonEntity
    {
        public int Id { get; set; }

        //public List<Course> Courses { get; set; }
       // public List<Grade> Grades { get; set; }

        public ICollection<CourseEntity> Courses { get; set; }
       //2 public ICollection<Grade> Grades { get; set; }

        //public Student(string name, string surname)
        //{
        //    Name = name;
        //    Surname = surname;
        //    Courses = new List<Course>();
        //    Grades = new List<Grade>();
        //}

        //public new string GetName()
        //{
        //    return $"Student's name: {Name} {Surname}";
        //}

        //public string GetStudentInfo()
        //{
        //    string personInfo = base.GetInfo();
        //    return $"{personInfo}, Group: {Courses}, GPA: {Grades}";
        //}

    }
}
