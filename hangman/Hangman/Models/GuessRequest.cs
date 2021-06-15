using System;
namespace Hangman.Models
{
    public class GuessRequest
    {
        public int Id { get; set; }
        public char Letter { get; set; }
        public GuessRequest()
        {
        }
    }
}
