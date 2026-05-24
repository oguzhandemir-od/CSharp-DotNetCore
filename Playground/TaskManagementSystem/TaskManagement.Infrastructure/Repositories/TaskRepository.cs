using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Context;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository:ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public TaskRepository() { }

        public async Task AddTaskAsync(TaskItem task)
        {
            _context.TaskItems.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetByIdAsync(id);
            if(task!=null)
            {
                _context.TaskItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem>? GetByIdAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
