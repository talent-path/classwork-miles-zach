using System;
using System.Collections.Generic;
using System.Linq;
using Hangman.Models;

namespace Hangman.Dao
{
    public class HangmanDao
    {
        public static List<HangmanGame> HangmanGames = new List<HangmanGame>();

        public HangmanDao()
        {
        }

        public int CreateGame(string word)
        {
            int id;
            if (HangmanGames.Count == 0) id = 1;
            else id = HangmanGames.TakeLast(1).Single().Id + 1;
            HangmanGames.Add(new HangmanGame(id, word));
            return id;
        }

        public HangmanGame FindGameById(int id)
        {
            return HangmanGames.SingleOrDefault(g => g.Id == id);
        }

        public void UpdateGame(HangmanGame game)
        {
            HangmanGames = HangmanGames.Select(g => g.Id == game.Id ? game : g).ToList();
        }
    }
}
