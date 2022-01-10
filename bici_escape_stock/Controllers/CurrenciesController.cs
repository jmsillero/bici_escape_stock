using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bici_escape_stock.Models;
using bici_escape_stock.Data.repository;
using bici_escape_stock.domain.repository;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : BiciEscapeController<Currency, CurrencyRepository>
    {
        public CurrenciesController(CurrencyRepository repository) : base(repository)
        {
        }  
    }
}