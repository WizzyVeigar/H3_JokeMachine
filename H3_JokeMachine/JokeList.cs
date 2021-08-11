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
            new Joke("Hvorfor ligger ballerne på marken? fordi de er presset til det",JokeType.Dad,Language.Danish,1),
            new Joke("Jeg overvejer at gifte mig med en tysker er det over grænsen?",JokeType.Dad,Language.Danish,2),
            new Joke("What do you call a cow with no legs? Ground beef",JokeType.Dad,Language.English,3),
            new Joke("Wanna hear a joke about construction? I'm still working on it.",JokeType.Dad,Language.English,4),
            new Joke("Marcs kode",JokeType.Programmer,Language.Danish,5),
            new Joke("",JokeType.Programmer,Language.Danish,6),
            new Joke("What's 9+10? 910",JokeType.Programmer,Language.English,7),
            new Joke("",JokeType.Programmer,Language.English,8),
            new Joke("",JokeType.Animal,Language.Danish,9),
            new Joke("",JokeType.Animal,Language.Danish,10),
            new Joke("",JokeType.Animal,Language.English,11),
            new Joke("",JokeType.Animal,Language.English,12),
        };
    }
}
