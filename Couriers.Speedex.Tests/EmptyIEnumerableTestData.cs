using System;
using System.Collections.Generic;

namespace Couriers.Speedex.Tests
{
    /// <summary>
    /// Used to generate empty data for the type <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <typeparam name="T">he type of data</typeparam>
    public class EmptyIEnumerableTestData<T> : TheoryData<IEnumerable<T>>
        where T : class
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EmptyIEnumerableTestData() : base()
        {
            Add(null!);

            Add(Array.Empty<T>());
        }
    }
}