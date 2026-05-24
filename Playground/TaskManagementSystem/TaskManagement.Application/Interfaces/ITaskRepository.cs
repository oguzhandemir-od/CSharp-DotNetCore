using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem>? GetByIdAsync(int id);
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int id);
    }
}
