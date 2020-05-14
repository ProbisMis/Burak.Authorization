using System;

namespace Burak.Authorization.Models.CustomExceptions
{
    public class PermissionException : Exception
    {
        public PermissionException(string message, Exception innerEx = null) : base(message, innerEx)
        {
        }
    }
}