
namespace laboratorna.Model
{
    public class PersonEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        //public virtual string GetInfo()
        //{
        //    return $"{Name} {Surname}";
        //}
        //public new string GetName()
        //{
        //    return $"{Name} {Surname}";
        //}

        //public void WriteToFile(string fileName)
        //{
        //    using (StreamWriter sw = new StreamWriter(fileName))
        //    {
        //        sw.WriteLine(Name);
        //        sw.WriteLine(Surname);

        //    }
        //}

        //public void ReadFromFile(string fileName)
        //{
        //    using (StreamReader sr = new StreamReader(fileName))
        //    {
        //        Name = sr.ReadLine();
        //        Surname = sr.ReadLine();

        //    }
        //}
    }
}
