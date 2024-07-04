using System;
using System.Linq.Expressions;
using System.Text.Json;

namespace ImprovedExceptionHandeling
{
    public static class ThrowingExtension
    {
        private static Func<ArgumentException> _error = () => new ArgumentException("Argument is Invalid. please see the Exception Data for more Detail.");
        public static void ThrowArgumentNullExceptionIfNull<T>(this T value) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
        public static void ThrowArgumentExceptionIfNullOr<T>(this T value, Expression<Predicate<T>> predicate) where T : class
        {
            if (value is null || predicate.Compile()(value))
            {
                var ex = _error();
                ex.AddData("value", JsonSerializer.Serialize(value));
                ex.AddData("TypeOf", typeof(T));
                ex.AddData("Expression", predicate.Body.ToString());
                throw ex;
            }
        }
        public static void ThrowArgumentExceptionIf<T>(this T value, Expression<Predicate<T>> predicate)
        {
            if (predicate.Compile()(value))
            {
                var ex = _error();
                ex.AddData("value", JsonSerializer.Serialize(value));
                ex.AddData("TypeOf", typeof(T).ToString());
                ex.AddData("Expression", predicate.Body.ToString());
                throw ex;
            }
        }

        public static void ThrowIf<TException, TType>(this TType value, Expression<Predicate<TType>> expression, Func<TException> factory) where TException : Exception
        {
            if (expression.Compile()(value))
            {
                var ex = factory();
                ex.AddData("value", JsonSerializer.Serialize(value));
                ex.AddData("TypeOf", typeof(TType).ToString());
                ex.AddData("Expression", expression.Body.ToString());
                throw ex;
            }
        }

    }
}
