using System;
using ObjectOrientedExamples.ContactMethod.UsingGodObject;
using ObjectOrientedExamples.ContactMethod.UsingInheritance;
using ObjectOrientedExamples.ContactMethod.UsingInterfaces;
using UsingInterfaces;

namespace ObjectOrientedExamples.ContactMethod
{
    public class UnsupportedContactMethod : Exception
    {
        public IContactMethod _pPreferredContactMethod { get; }
        public PreferredContactMethod PPreferredContactMethod { get; }
        public UsingInheritance.ContactMethod PContactMethod { get; }

        public UnsupportedContactMethod(UsingInheritance.ContactMethod pContactMethod)
        {
            PContactMethod = pContactMethod;
        }

        public UnsupportedContactMethod(PreferredContactMethod pPreferredContactMethod)
        {
            PPreferredContactMethod = pPreferredContactMethod;
        }

        public UnsupportedContactMethod(IContactMethod pPreferredContactMethod)
        {
            _pPreferredContactMethod = pPreferredContactMethod;
        }
    }
}