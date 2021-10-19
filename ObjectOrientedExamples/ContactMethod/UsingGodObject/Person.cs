using System.Collections.Generic;

namespace ObjectOrientedExamples.ContactMethod.UsingGodObject
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Surname { get; set;}
        public PreferredContactMethod PreferredContactMethod { get; set;}
        public string EmailAddress { get; set;}
        public string PhoneNumber { get; set;}
        public IEnumerable<string> Address { get; set;}
    }
}