using bici_escape_stock.Data.repository;
using bici_escape_stock.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorPaymentController : BiciEscapeController<VendorPayment, VendorPaymentRepository>
    {
        public VendorPaymentController(VendorPaymentRepository repository) : base(repository)
        {
        }
    }
}
