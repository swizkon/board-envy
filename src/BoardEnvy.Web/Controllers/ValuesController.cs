﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardEnvy.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardEnvy.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Board> Get()
        {
            return new Board[] { new Board() ,new Board() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value for " + id;
        }
    }
}
