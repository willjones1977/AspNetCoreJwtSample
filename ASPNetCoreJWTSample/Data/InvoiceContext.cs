using Microsoft.EntityFrameworkCore;
using ASPNetCoreJWTSample.Models;

namespace ASPNetCoreJWTSample.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
