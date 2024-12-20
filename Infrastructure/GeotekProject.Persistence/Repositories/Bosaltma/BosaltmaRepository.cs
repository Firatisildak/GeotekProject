﻿using GeotekProject.Application.Interfaces;
using GeotekProject.Domain.Entities;
using GeotekProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotekProject.Persistence.Repositories
{
    public class BosaltmaRepository(GeotekProjectDbContext context) : GenericRepository<Bosaltma>(context), IBosaltmaRepository
    {
        public async Task<IList<Bosaltma>> GetAllWithKamyonAsync()
        {
            return await Table.Include(b => b.Kamyon).ToListAsync();
        }
    }
}
