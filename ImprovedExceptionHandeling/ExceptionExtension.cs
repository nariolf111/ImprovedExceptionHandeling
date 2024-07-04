using System;
using System.Linq;
using System.Text.Json;

namespace ImprovedExceptionHandeling
{
    public static class ExceptionExtension
    {
        public static TException AddData<TException>(this TException exception, string keyword, object value) where TException : Exception
        {
            exception.ThrowArgumentNullExceptionIfNull();
            keyword.ThrowArgumentExceptionIfNullOr(x => string.IsNullOrWhiteSpace(x));
            
            exception.Data.Add(keyword, value is null ? "Null" : JsonSerializer.Serialize(value));
            return exception;
        }

        public static TException AddData<TException>(this TException exception, params (string keyword, object value)[] datapairs) where TException : Exception 
        {
            exception.ThrowArgumentNullExceptionIfNull();
            datapairs.ThrowArgumentExceptionIfNullOr(x => !x.Any());
            foreach (var item in datapairs)
            {
                exception.AddData(item.keyword,item.value);
            }
            return exception;
        }
    }
}
