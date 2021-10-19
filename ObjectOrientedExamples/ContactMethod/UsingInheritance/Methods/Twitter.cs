namespace ObjectOrientedExamples.ContactMethod.UsingInheritance.Methods
{
    public class Twitter : ContactMethod
    {
        public string Handle { get; set; } = string.Empty;

        public static bool operator ==(Twitter a, Twitter b)
            => a.Equals(b);
        
        public static bool operator !=(Twitter a, Twitter b) => 
            !a.Equals(b);
        
        public override bool Equals(object obj) => AreEqual(this, obj as Twitter);

        private static bool AreEqual(Twitter a, Twitter b) =>
            (a, b) switch
            {
                (null,null) => false,
                ({ } ta, {} tb) => ta.Handle == tb.Handle,
                _ => false
            };

        public override int GetHashCode() => 
            Handle != null ? Handle.GetHashCode() : 0;
    }
}