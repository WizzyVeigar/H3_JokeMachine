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
            new Joke("Hvad kalder man en indbagt haj? haj med dej",JokeType.Dad,Language.Danish,1),
            new Joke("Jeg overvejer at gifte mig med en tysker er det over grænsen?",JokeType.Dad,Language.Danish,2),
            new Joke("What do you call a cow with no legs? Ground beef",JokeType.Dad,Language.English,3),
            new Joke("Wanna hear a joke about construction? I'm still working on it.",JokeType.Dad,Language.English,4),
            new Joke("Marcs kode",JokeType.Programmer,Language.Danish,5),
            new Joke("Min kode",JokeType.Programmer,Language.Danish,6),
            new Joke("What's 9+10? 910",JokeType.Programmer,Language.English,7),
            new Joke("To whoever stole my copy of Microsoft Office, I will find you. You have my Word",JokeType.Programmer,Language.English,8),
            new Joke("Hvor tager duer på ferie?I Duebai",JokeType.Animal,Language.Danish,9),
            new Joke("Hvorfor er fisk generelt så grimme? Fordi de er nogle vandskabninger",JokeType.Animal,Language.Danish,10),
            new Joke("What do you call a penguin in the desert? Lost",JokeType.Animal,Language.English,11),
            new Joke("What is the best way to cook a gator? In a crock-pot",JokeType.Animal,Language.English,12),
        };
    }
}
