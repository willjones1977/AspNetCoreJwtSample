using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreJWTSample.Data;
using ASPNetCoreJWTSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreJWTSample.Controllers
{
    [Route("api/[controller]/[action]")]
    // [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private InvoiceContext _invoiceContext;
        public InvoiceController(InvoiceContext invoiceContext)
        {
            _invoiceContext = invoiceContext;
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
        public async Task<Invoice> Get(int id)
        {
            return await _invoiceContext.Invoices.FindAsync(id);
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
