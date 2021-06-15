using System;
namespace Hangman.Exceptions
{
    public class GameCompletedException : Exception
    {
        public GameCompletedException(string message) : base(message)
        {
        }

        public GameCompletedException(string message, Exception e) : base(message, e) {}
    }
}
