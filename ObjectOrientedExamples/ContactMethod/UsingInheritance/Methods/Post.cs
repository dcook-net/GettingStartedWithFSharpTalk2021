using System.Collections.Generic;
using System.Linq;

namespace ObjectOrientedExamples.ContactMethod.UsingInheritance
{
    public class Post : ContactMethod
    {
        public Post(List<string> address)
        {
            Address = address;
        }

        public Post()
        {
        }

        public Post(params string[] addressLines)
        {
            Address = addressLines.ToList();
        }

        public List<string> Address { get; set; }
    }
}