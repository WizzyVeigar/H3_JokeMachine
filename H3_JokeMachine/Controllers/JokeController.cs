using H3_JokeMachine.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_JokeMachine.Controllers
{
    public class JokeController : Controller
    {
        private JokeList jokeList = new JokeList();
        Random randomJokePicker = new Random();

        [HttpGet]
        public IActionResult GetJoke()
        {
            return Ok(GetRandomJoke(jokeList.Jokes));
        }

        [HttpGet]
        [Route("Type/{type}")]

        public IActionResult GetJoke(JokeType type)
        {
            for (int i = 0; i < jokeList.Jokes.Count; i++)
            {
                if (jokeList.Jokes[i].Type != type)
                {
                    jokeList.Jokes.RemoveAt(i);
                }
            }


            return Ok(GetRandomJoke(jokeList.Jokes));
        }


        /// <summary>
        /// Get a random joke from a filtered list of jokes
        /// </summary>
        /// <param name="jokes">List of already filtered jokes</param>
        /// <returns>Returns a random joke</returns>
        private Joke GetRandomJoke(List<Joke> jokes)
        {
            return jokes[randomJokePicker.Next(0, jokes.Count)];
        }

        /// <summary>
        /// Used to take out already used jokes from the session
        /// </summary>
        /// <returns></returns>
        private List<Joke> FilterUsedJokes()
        {
            List<Joke> usedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("jokes");

            if (usedJokes.Count > 0)
            {
                GetUnusedJokes(usedJokes);
            }

            return jokeList.Jokes;
        }

        private List<Joke> GetUnusedJokes(List<Joke> usedJokes)
        {
            for (int i = 0; i < usedJokes.Count; i++)
            {
                for (int j = 0; j < jokeList.Jokes.Count; j++)
                {
                    if (usedJokes[j].JokeId == jokeList.Jokes[j].JokeId)
                    {
                        jokeList.Jokes.RemoveAt(j);
                        j = jokeList.Jokes.Count + 1;
                    }
                }
            }
            return jokeList.Jokes;
        }
    }
}
