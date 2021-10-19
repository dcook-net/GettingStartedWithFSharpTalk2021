using System;
using System.Collections.Generic;
using ObjectOrientedExamples.ContactMethod.UsingInterfaces.Methods;

namespace ObjectOrientedExamples.ContactMethod.UsingInterfaces
{
    public static class Example
    {
        public static void DoSomethingWithPeople()
        {
            var dave = new Person
            {
                Firstname = "",
                Surname = "",
                ContactMethod = new Email { EmailAddress = "dave@email.com" }
            };

            var graham = new Person
            {
                Firstname = "",
                Surname = "",
                ContactMethod = new Phone { Number = "01733 123456" }
            };

            var ross = new Person
            {
                Firstname = "",
                Surname = "",
                ContactMethod = new Post { Address = new List<string> { "address line 1", "address line 2", "address line 3", "PE2 6XL" } }
            };

            PrintPersonContactDetails(dave);
            PrintPersonContactDetails(graham);
            PrintPersonContactDetails(ross);
        }

        private static void PrintPersonContactDetails(Person p) 
            => Console.WriteLine(GetContactDetails(p));

        public static string GetContactDetails(Person p) =>
            p.ContactMethod switch
            {
                Email email => $"Email: {email.EmailAddress}",
                Phone phone => $"Phone #: {phone.Number}",
                Post post => $"Address: {post.Address.Format()}",
                _ => throw new UnsupportedContactMethod(p.ContactMethod)
            };
    }
}