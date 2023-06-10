namespace laboratorna.Model
{

    public class GradeEntity
    {
            public int Id { get; set; }
            public CourseEntity Course_Grade { get; set; }
            public StudentEntity Student_Grade { get; set; }
            public TeacherEntity Teacher_Grade { get; set; }
            public int Value { get; set; }

            //Grade(Course course, Student student, Teacher teacher, int value)
            //{
            //    Course = course;
            //    Student = student;
            //    Teacher = teacher;
            //    Value = value;
            //}
        }
}
