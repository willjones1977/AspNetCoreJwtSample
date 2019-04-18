using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreJWTSample.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Due { get; set; }
        public bool Paid { get; set; }
    }
}
