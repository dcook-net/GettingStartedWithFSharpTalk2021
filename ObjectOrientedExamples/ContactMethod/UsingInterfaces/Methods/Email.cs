using UsingInterfaces;

namespace ObjectOrientedExamples.ContactMethod.UsingInterfaces.Methods
{
    public class Email : IContactMethod
    {
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public Email()
        {
        }

        public string EmailAddress { get; set; }
        
        public string ContactMethod => EmailAddress;
    }
}