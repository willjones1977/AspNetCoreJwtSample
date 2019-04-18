using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreJWTSample.Controllers
{
    // [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult View()
        {
            return Ok("You can view invoices!");
        }

        [Authorize(Roles = "Administrator,Accountant")]
        [HttpGet]
        public IActionResult Create()
        {
            var userIdClaim = HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
            return Ok($"Your User ID is {userIdClaim.Value} and you can create invoices!");
        }

        [Authorize(Roles = "Administrator,Accountant")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id == 1)
            {
                return Ok($"Here is the invoice number 1!");
                
            }
            if (id == 2)
            {
                return Ok($"Here is the invoice number 2!");

            }
            return NotFound();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Delete()
        {
            var userIdClaim = HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
            return Ok($"Your User ID is {userIdClaim.Value} and you can delete invoices!");
        }
    }
}
