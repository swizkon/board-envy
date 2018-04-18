using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoardEnvy.Domain.Models;
using BoardEnvy.Infrastructure.Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace BoardEnvy.Web.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        readonly string _username = "swizkon";

        private readonly AzureCollaboratorService _service;

        public BoardsController(IConfiguration configuration)
        {
            _service = new AzureCollaboratorService(configuration);
        }

        [HttpGet]
        public async Task<IEnumerable<Board>> Get()
        {
            return await _service.GetAllBoards();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value for " + id;
        }

        [HttpGet("{id}/tasks")]
        public string Tasks(int id)
        {
            return "tasks for " + id;
        }

        [HttpPost]
        public void Post([FromBody] CreateBoardModel data)
        {
            _service.CreateBoard(_username, data.Name);
        }
    }
}
