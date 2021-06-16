using System;
using System.Collections.Generic;
using Hangman.Exceptions;
using Hangman.Models;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hangman.Controllers
{
    [ApiController]
    [Route("/api")]
    public class HangmanController : ControllerBase
    {

        private HangmanService _service;

        public HangmanController()
        {
            _service = new HangmanService();
        }

        [HttpPost("begin")]
        public ActionResult<int> BeginGame()
        {
            return this.Created("/api/begin", _service.StartNewGame());
        }

        [HttpGet("games")]
        public ActionResult<List<HangmanGame>> GetAllGames()
        {
            return this.Ok(_service.GetAllGames());
        }

        [HttpGet("game/{id}")]
        public ActionResult<HangmanGame> GetGameById(int id)
        {
            return this.Ok(_service.GetGameById(id));
        }

        [HttpPut("game")]
        public ActionResult UpdateGame(GuessRequest guess)
        {
            try
            {
                _service.Guess(guess);
        } catch(Exception ex) when(ex is GameCompletedException || ex is GuessAmountExceededException)
        {
            return this.BadRequest(ex.Message);
        }
            return this.LocalRedirect($"/api/game/{guess.Id}");
        }
    }
}
