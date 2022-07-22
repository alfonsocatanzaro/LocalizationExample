using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using LocalizationExample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using RazorEngine;
using RazorEngine.Templating;

namespace LocalizationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStringLocalizer<CosoResource> _stringLocalizer;
        public HomeController(IStringLocalizer<CosoResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }


        [HttpGet]
        public string Get()
        {
            Lazy<string> salute = new Lazy<string>(() => _stringLocalizer.GetString("Hello"));


            var result = Engine.Razor.RunCompile("@(DateTime.Now) @Model.salute", "test", null, new {salute= salute.Value});
            return result;
        }
    }
}
