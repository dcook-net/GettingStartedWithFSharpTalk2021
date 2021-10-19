namespace ObjectOrientedExamples.ContactMethod.UsingInheritance
{
    public class Email : ContactMethod
    {
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public Email()
        {
        }

        public string EmailAddress { get; set; }
    }
}