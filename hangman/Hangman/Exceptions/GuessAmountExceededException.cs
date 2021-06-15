using System;
namespace Hangman.Exceptions
{
    public class GuessAmountExceededException : Exception
    {
        public GuessAmountExceededException(string message) : base(message)
        {
        }

        public GuessAmountExceededException(string message, Exception e) : base(message, e) { }
    }
}
