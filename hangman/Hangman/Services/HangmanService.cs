using System;
using System.Collections.Generic;
using System.Linq;
using Hangman.Dao;
using Hangman.Exceptions;
using Hangman.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hangman.Services
{
    public class HangmanService
    {
        private HangmanDao dao;
        private Random _rng;
        private List<string> words;

        public HangmanService()
        {
            dao = new HangmanDao();
            _rng = new Random();
            words = new List<string>() { "zebra", "elephant", "lion", "giraffe", "seal", "turtle", "tiger" };
        }

        public int StartNewGame()
        {
            return dao.CreateGame(words[_rng.Next(words.Count)]);
        }

        public List<HangmanGame> GetAllGames()
        {
            return HangmanDao.HangmanGames.Select(game =>
            {
                return game.IsComplete ? game : CreateViewModel(game);
            }).ToList();
        }

        public HangmanGame GetGameById(int id)
        {
            HangmanGame game = dao.FindGameById(id);
            if(!game.IsComplete)
            {
                game = CreateViewModel(game);
            }
            return game;
        }

        private HangmanGame CreateViewModel(HangmanGame game)
        {
            string word = "";
            foreach(char letter in game.HiddenWord.ToCharArray())
            {
                if (game.GuessedLetters.Contains(letter))
                {
                    word += letter;
                }
                else word += "_";
            }
            return new HangmanGame(game.Id, word, game.GuessedLetters);
        }

        public void Guess(GuessRequest guess)
        {
            HangmanGame game = dao.FindGameById(guess.Id);
            if(game.IsComplete)
            {
                throw new GameCompletedException("Game is already complete.");
            }
            game.GuessedLetters.Add(guess.Letter);
            if (CountGuesses(game) >= 6)
            {
                game.IsComplete = true;
                throw new GuessAmountExceededException("Too many incorrect guesses.");
            }
        }

        public int CountGuesses(HangmanGame game)
        {
            int incorrectGuesses = 0;
            int correctGuesses = 0;
            foreach(char letter in game.GuessedLetters)
            {
                if(game.HiddenWord.Contains(letter))
                {
                    correctGuesses++;
                }
                else
                {
                    incorrectGuesses++;
                }
            }

            if (!CreateViewModel(game).HiddenWord.Contains("_"))
                game.IsComplete = true;

            return incorrectGuesses;
        }
    }
}
