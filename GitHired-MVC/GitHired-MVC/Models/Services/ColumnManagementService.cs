﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitHired_MVC.Models.Services
{
    public class ColumnManagementService : IColumnManager
    {
        private GitHiredDBContext _context { get; }

        public ColumnManagementService(GitHiredDBContext context)
        {
            _context = context;
        }

        public async Task CreateColumn(Column column)
        {
            _context.Column.Add(column);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteColumn(int id)
        {
            Column col = _context.Column.FirstOrDefault(x => x.ID == id);
            // Remove the Column from the DB
            _context.Column.Remove(col);
            await _context.SaveChangesAsync();
        }

        public async Task<Column> GetColumn(int id)
        {
            return await _context.Column.FirstOrDefaultAsync(x => x.ID == id);

        }

        public async Task UpdateColumn(Column column)
        {
            _context.Column.Update(column);
            await _context.SaveChangesAsync();
        }
    }
}
