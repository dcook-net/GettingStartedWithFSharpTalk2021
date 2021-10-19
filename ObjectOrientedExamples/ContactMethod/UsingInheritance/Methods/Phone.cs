namespace ObjectOrientedExamples.ContactMethod.UsingInheritance
{
    public class Phone : ContactMethod
    {
        public Phone()
        {
        }

        public Phone(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}