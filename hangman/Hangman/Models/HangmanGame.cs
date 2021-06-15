using System;
using System.Collections.Generic;

namespace Hangman.Models
{
    public class HangmanGame
    {
        public int Id { get; set; }
        public string HiddenWord { get; set; }
        public HashSet<char> GuessedLetters { get; set; }
        public bool IsComplete { get; set; } = false;

        public HangmanGame(string word)
        {
            HiddenWord = word;
        }

        public HangmanGame(int id, string word)
        {
            Id = id;
            HiddenWord = word;
            GuessedLetters = new HashSet<char>();
        }

        public HangmanGame(int id, string word, HashSet<char> guessedLetters)
        {
            Id = id;
            HiddenWord = word;
            GuessedLetters = guessedLetters;
        }

        public HangmanGame(HangmanGame that)
        {
            Id = that.Id;
            HiddenWord = that.HiddenWord;
            GuessedLetters = that.GuessedLetters;
        }
    }
}
