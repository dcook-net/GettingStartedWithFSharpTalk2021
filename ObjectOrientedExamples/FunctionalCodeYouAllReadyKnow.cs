using System;
using System.Linq;

namespace ObjectOrientedExamples
{
    // See FSharpSyntax.FunctionalCodeYouAlreadyKnow.fs for the F# version of this code.
    
    public static class FunctionalCodeYouAllReadyKnow
    {
        public static int TotalOfEvenNumbersUpTo(int maxValue = 10) =>
            Enumerable.Range(1, maxValue)   // 1,2,3,4,5,6,7,8,9,10
                .Where(x => x % 2 == 0)  // 2,4,6,8,10
                .Select(x => x * x)      // 4,16,36,64,100
                .Sum();                     // 220

        public static int TotalOfEvenNumbersUpToV2(int maxValue = 10) =>
            Enumerable.Range(1, maxValue) // 1,2,3,4,5,6,7,8,9,10
                .Where(IsEven)            // 2,4,6,8,10
                .Select(Squared)          // 4,16,36,64,100
                .Sum();                   // 220
        
        public static int TotalOfEvenNumbersUpToV3(int maxValue = 10)
        {
            var sequence = Enumerable.Range(1, maxValue);
            // sequence = 1,2,3,4,5,6,7,8,9,10
            var filtered = sequence.Where(IsEven);
            // sequence = 1,2,3,4,5,6,7,8,9,10
            var squared = filtered.Select(Squared);
            // sequence = 1,2,3,4,5,6,7,8,9,10
            var total = squared.Sum();
            // sequence = 1,2,3,4,5,6,7,8,9,10
            return total; // 120
        }

        private static readonly Func<int, bool> IsEven = x => x % 2 == 0;
        
        private static int Squared(int x) => x * x;
    }
}