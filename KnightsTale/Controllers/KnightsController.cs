using System;
using System.Collections.Generic;
using KnightsTale.Models;
using KnightsTale.Services;
using Microsoft.AspNetCore.Mvc;

namespace KnightsTale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnightsController : ControllerBase
    {
        private readonly KnightsService _KServ;

        public KnightsController(KnightsService kServ)
        {
            _KServ = kServ;
        }
        [HttpGet]

        public ActionResult<List<Knight>> Get()
        {
            try
            {
                List<Knight> knights = _KServ.Get();
                return Ok(knights);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
        [HttpGet("{id}")]
        public ActionResult<Knight> Get(int id)
        {
            try
            {
                Knight knight = _KServ.Get(id);
                return Ok(knight);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }


    }
}