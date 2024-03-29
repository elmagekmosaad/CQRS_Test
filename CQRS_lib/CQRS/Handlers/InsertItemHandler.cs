﻿using CQRS_lib.CQRS.Commands;
using CQRS_lib.Data;
using CQRS_lib.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Handelers
{
    public class InsertItemHandler : IRequestHandler<InsertItemCommand, Items>
    {
        private AppDbContext _db;
        public InsertItemHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Items> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
            await _db.Items.AddAsync(request.item);
            _db.SaveChanges();
            return await Task.FromResult(request.item);
        }
    }
}
