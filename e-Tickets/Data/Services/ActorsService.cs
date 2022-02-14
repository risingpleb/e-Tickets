﻿using e_Tickets.Data.Base;
using e_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor> , IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { } 
    }
}
