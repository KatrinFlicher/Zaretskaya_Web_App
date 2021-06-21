using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Zaretskaya_Html_Intro.Tests
{
    class Comparer<T> : IEqualityComparer<T>
    {
        Func<T, T, bool> comparerFunction;

        public Comparer(Func<T, T, bool> comparerFunction)
        {
            this.comparerFunction = comparerFunction;
        }

        public static Comparer<T> GetComparer(Func<T, T, bool> func)
        {
            return new Comparer<T>(func);
        }

        public bool Equals(T x, T y)
        {
            return comparerFunction(x, y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            throw new NotImplementedException();
        }
    }
}