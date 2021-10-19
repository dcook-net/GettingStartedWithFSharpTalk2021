namespace ObjectOrientedExamples.ContactMethod.UsingInheritance
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;
        }

        public string Firstname { get; set; }
        public string Surname { get; set;}
        public ContactMethod ContactMethod { get; set; }
    }
}