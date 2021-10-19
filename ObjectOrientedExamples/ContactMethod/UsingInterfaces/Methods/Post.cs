using System.Collections.Generic;
using System.Linq;
using UsingInterfaces;

namespace ObjectOrientedExamples.ContactMethod.UsingInterfaces.Methods
{
    public class Post : IContactMethod
    {
        public Post()
        {
        }

        public Post(List<string> address)
        {
            Address = address;
        }
        
        public Post(params string[] addressLines)
        {
            Address = addressLines.ToList();
        }

        public List<string> Address { get; set; }
        
        public string ContactMethod => Address.Format();
    }
}