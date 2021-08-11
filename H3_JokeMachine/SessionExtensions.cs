using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_JokeMachine
{
    //Imported from OreosAndMilk
    public static class SessionExtensions
    {
        /// <summary>
        /// Sets <paramref name="value"/> into the <see cref="HttpContext.Session"/> as json
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">The accessing name of the set value</param>
        /// <param name="value">The data that needs to be stored in the session</param>
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Get a specific object from a json string with the specific <paramref name="key"/>
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="session"></param>
        /// <param name="key">The identifying name which holdes the object</param>
        /// <returns>Returns an object of a specified type <typeparamref name="T"/></returns>
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}