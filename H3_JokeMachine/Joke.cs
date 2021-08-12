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

    public enum Language
    {
        Danish,
        English
    }

    public class Joke
    {

        public int JokeId { get; set; }
        public string JokeText { get; set; }
        public JokeType Type { get; set; }
        public Language Language { get; set; }
        public Joke(string jokeText, JokeType type, Language language,int id)
        {
            JokeText = jokeText;
            Type = type;
            Language = language;
            JokeId = id;
        }
    }
}
