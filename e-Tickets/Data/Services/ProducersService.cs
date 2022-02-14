using e_Tickets.Data.Base;
using e_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer> , IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}
