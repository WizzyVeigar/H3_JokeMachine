using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_JokeMachine.Models
{
    public enum JokeType
    {
        Dad,
        Programmer,
        Animal
    }

    public class Joke
    {

        public int JokeId { get; set; }
        public string JokeText { get; set; }
        public JokeType Type { get; set; }
        public Joke(string jokeText, JokeType type, int id)
        {
            JokeText = jokeText;
            Type = type;
            JokeId = id;
        }
    }
}
