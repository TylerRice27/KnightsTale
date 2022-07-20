using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using KnightsTale.Models;
using KnightsTale.Services;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Knight>> Create([FromBody] Knight knightData)
        {

            try
            {

                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                knightData.CreatorId = userInfo.Id;
                Knight newKnight = _KServ.Create(knightData);
                newKnight.Creator = userInfo;
                return Ok(newKnight);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }





        }

        [HttpPut("{id}")]
        [Authorize]

        public async Task<ActionResult<Knight>> EditAsync(int id, [FromBody] Knight knightData)
        {

            try
            {

                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                knightData.Id = id;
                knightData.CreatorId = userInfo.Id;
                Knight update = _KServ.Edit(knightData);
                return Ok(update);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Knight>> DeleteAsync(int id)
        {

            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Knight deletedKnight = _KServ.Delete(id, userInfo.Id);
                return Ok(deletedKnight);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

    }
}