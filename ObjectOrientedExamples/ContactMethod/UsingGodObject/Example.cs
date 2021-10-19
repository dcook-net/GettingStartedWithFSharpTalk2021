using System;
using System.Collections.Generic;
using static ObjectOrientedExamples.ContactMethod.UsingGodObject.PreferredContactMethod;

namespace ObjectOrientedExamples.ContactMethod.UsingGodObject
{
    public class Example
    {
        public static void DoSomethingWithPeople()
        {
            var person = new Person
            {
                Firstname = "",
                Surname = "",
                PreferredContactMethod = Phone, 
                EmailAddress = "dave@email.com", //Inconsistent state on Preferred Contact method and Email address!
                PhoneNumber = "",
                Address = new List<string>{""}
            };
            
            PrintPersonContactDetails(person);
        }

        private const string Unknown = "Unknown";

        private static void PrintPersonContactDetails(Person p)
        {
            var contactDetails = p.PreferredContactMethod switch
            {
                Email => $"Phone #: {p.EmailAddress ?? Unknown}",
                Phone => $"Phone #: {p.PhoneNumber ?? Unknown}",
                Post => $"Email: {p.Address.Format() ?? Unknown}",
                _ => throw new UnsupportedContactMethod(p.PreferredContactMethod)
            };
            
            Console.WriteLine(contactDetails);
        }
    }
}