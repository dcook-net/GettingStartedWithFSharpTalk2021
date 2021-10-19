using UsingInterfaces;

namespace ObjectOrientedExamples.ContactMethod.UsingInterfaces.Methods
{
    public class Phone : IContactMethod
    {
        public Phone()
        {
        }

        public Phone(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
        
        public string ContactMethod => Number;
    }
}