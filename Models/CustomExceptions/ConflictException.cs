using System;

namespace Burak.Authorization.Models.CustomExceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}