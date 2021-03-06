using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_JokeMachine
{
    //What can we put this attribute on?
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        public string key { get; set; }

        //public string[] keys = new string[]
        //{
        //    "Dadk3y",
        //    "Programm3rdadk3y",
        //    "Dankm3m3rk3y"
        //};

        //This is used to authorize the request before hitting the controller
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //for (int i = 0; i < keys.Length; i++)
            //{
            if (context.HttpContext.Request.Headers.TryGetValue(key, out var potentialApiKey))
            {
                //Dependency inject the config object
                IConfiguration config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                //Get the potential keys from appsettings.json
                string apiKey = config.GetValue<string>("ApiKeys:" + key);

                if (apiKey != potentialApiKey)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                await next();
            }
            //}

            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
