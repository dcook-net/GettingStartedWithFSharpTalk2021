using UsingInterfaces;

namespace ObjectOrientedExamples.ContactMethod.UsingInterfaces.Methods
{
    public class Twitter : IContactMethod
    {
        public string Handle { get; set; }
       
        public string ContactMethod => Handle;
    }
}