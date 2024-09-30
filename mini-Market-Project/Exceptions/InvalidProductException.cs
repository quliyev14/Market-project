using System;
namespace mini_Market_Project.Exceptions
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException(string? message) : base(message) { }
    }
}