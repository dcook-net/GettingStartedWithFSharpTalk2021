using System;

namespace ObjectOrientedExamples.CurryingAndPartialApplication
{
    public class Currying
    {
        // ReSharper disable once InconsistentNaming
        private readonly Func<int,int,int> Add = (a, b) => a+b;

        private static int Mutate(int valueToMutate, Func<int, int> mutator)
            => mutator(valueToMutate);
        
        public void Example()
        {
            var curriedAdd = Add.Curry();
            var addFive = curriedAdd(5);
            var result1 = addFive(10);

            //or
            
            var result2 = curriedAdd(5)(10);
            
            //or
            var result3 = Add.Curry()(5)(10);
            
            
            const int initialValue = 10;
            var addFiveTo = Add.Curry()(5);

            var result4 = Mutate(initialValue, addFiveTo); //result4 = 15
        }

    }
}