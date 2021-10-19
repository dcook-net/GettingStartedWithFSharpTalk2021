using System;

namespace ObjectOrientedExamples.CurryingAndPartialApplication
{
    public static class Extensions
    {
        public static Func<T1, Func<T2, TR>> Curry<T1, T2, TR>(this Func<T1, T2, TR> func)
            => t1 => t2 => func(t1, t2);

        public static Func<T2, TR> Apply<T1, T2, TR> (this Func<T1, T2, TR> f, T1 t1)
            => t2 => f(t1, t2);
    }
}