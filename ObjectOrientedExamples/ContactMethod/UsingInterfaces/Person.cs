using UsingInterfaces;

namespace ObjectOrientedExamples.ContactMethod.UsingInterfaces
{
    public class Person
    {
        public Person(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;
        }

        public Person()
        {
        }

        public string Firstname { get; set; }
        public string Surname { get; set;}
        public IContactMethod ContactMethod { get; set; }
    }
}