using H3_JokeMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_JokeMachine
{
    public class JokeList
    {
        public List<Joke> Jokes = new List<Joke>()
        {
            new Joke("",JokeType.Dad,1),
            new Joke("",JokeType.Dad,2),
            new Joke("",JokeType.Dad,3),
            new Joke("",JokeType.Dad,4),
            new Joke("",JokeType.Programmer,5),
            new Joke("",JokeType.Programmer,6),
            new Joke("",JokeType.Programmer,7),
            new Joke("",JokeType.Programmer,8),
            new Joke("",JokeType.Animal,9),
            new Joke("",JokeType.Animal,10),
            new Joke("",JokeType.Animal,11),
            new Joke("",JokeType.Animal,12),
        };
    }
}
