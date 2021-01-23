﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using LocalizationExample;
using LocalizationExample.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public WeatherForecastController(IStringLocalizer<SharedResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        public string Get()
        {
             var value = _stringLocalizer.GetString("Sam");

            return value;
        }
    }
}
