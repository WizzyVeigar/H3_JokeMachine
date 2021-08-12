﻿using H3_JokeMachine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_JokeMachine.Controllers
{
    [Route("[controller]")]
    public class JokeController : Controller
    {
        private JokeList jokeList = new JokeList();
        Random randomJokePicker = new Random();

        [HttpGet]
        public IActionResult GetJoke()
        {
            try
            {
                FilterUsedJokes();
            }
            catch (Exception)
            {
                return BadRequest("Session has been tampered with");
            }

            //Need to sanitize
            string jokeType = HttpContext.Request.Cookies["Favorite_Joke"];
            if (jokeType != null)
            {
                for (int i = 0; i < Enum.GetNames(typeof(JokeType)).Length; i++)
                {

                }
                GetJoke("", "");
            }

            return SendJoke();
        }


        [HttpGet]
        [Route("Type/{type}/{language?}")]
        public IActionResult GetJoke(string type, [FromHeader] string language)
        {
            JokeType jokeType;
            Language? languageType = null;

            //Sanitize parameters
            try
            {
                jokeType = (JokeType)Enum.Parse(typeof(JokeType),
                    type.First().ToString().ToUpper() + type.Substring(1));
                if (language != "" && language != null)
                    languageType = (Language)Enum.Parse(typeof(Language),
                        language.First().ToString().ToUpper() + language.Substring(1));
            }
            catch (ArgumentException)
            {
                return BadRequest("Bad parameters, check if everything is spelled correctly");
            }

            try
            {
                //Check if session is tainted
                FilterUsedJokes();
            }
            catch (Exception e)
            {
                return BadRequest("Session has been tampered with\n" + e);
            }

            //Remove all jokes not requested by type
            for (int i = jokeList.Jokes.Count - 1; i >= 0; i--)
            {
                if (jokeList.Jokes[i].Type != jokeType)
                {
                    jokeList.Jokes.RemoveAt(i);
                }
            }

            //If language is picked, remove all jokes not requested by language
            if (languageType != null)
            {
                for (int i = jokeList.Jokes.Count - 1; i >= 0; i--)
                {
                    if (jokeList.Jokes[i].Language != languageType)
                    {
                        jokeList.Jokes.RemoveAt(i);
                    }
                }
            }

            return SendJoke(true);
        }

        private IActionResult SendJoke(bool setCookie = false)
        {
            List<Joke> usedJokes = GetJokeListFromSession();
            if (usedJokes == null)
                usedJokes = new List<Joke>();

            //Joke to return
            if (jokeList.Jokes.Count > 0)
            {
                Joke returnJoke = GetRandomJoke(jokeList.Jokes);
                usedJokes.Add(returnJoke);
                //Save the list back into session
                HttpContext.Session.SetObjectAsJson("jokes", usedJokes);
                if (setCookie)
                {
                    HttpContext.Response.Cookies.Append("Favorite_Joke",
                        returnJoke.Type.ToString(),
                        new CookieOptions() { MaxAge = TimeSpan.FromMinutes(10) });
                }
                //return Ok(returnJoke);
                return Ok(returnJoke.JokeText);
            }
            else
                return Ok("No jokes left!");
        }

        [HttpGet]
        [Route("Types")]
        public string GetJokeTypes()
        {
            string jokeTypes = "";

            foreach (string jokeName in Enum.GetNames(typeof(JokeType)))
            {
                jokeTypes += jokeName + "\n";
            }

            return jokeTypes;
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
        private void FilterUsedJokes()
        {
            try
            {
                List<Joke> usedJokes = GetJokeListFromSession();
                if (usedJokes != null)
                    if (usedJokes.Count > 0)
                    {
                        GetUnusedJokes(usedJokes);
                    }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private List<Joke> GetJokeListFromSession()
        {
            return HttpContext.Session.GetObjectFromJson<List<Joke>>("jokes");
        }

        private List<Joke> GetUnusedJokes(List<Joke> usedJokes)
        {
            for (int i = 0; i < usedJokes.Count; i++)
            {
                for (int j = 0; j < jokeList.Jokes.Count; j++)
                {
                    if (usedJokes[i].JokeId == jokeList.Jokes[j].JokeId)
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
