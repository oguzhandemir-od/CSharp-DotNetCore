using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Entities.Enums;

namespace TaskManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            throw new Exception("Veritabanına bağlanırken beklenmedik bir hata yaşandı.");

            var tasks = await _taskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if(task==null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto dto)
        {
            var taskItem = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = TaskStatusEnum.Todo,
                Priority = dto.Priority,
                CreatedDate = DateTime.Now,
                DueDate = dto.DueDate
            };     

            await _taskRepository.AddTaskAsync(taskItem);
            return Ok(taskItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto dto)
        {
            var existingTask = await _taskRepository.GetByIdAsync(dto.Id);

            if(existingTask==null)
            {
                return NotFound("Güncellemek istenen görev bulunamadı.");
            }

            existingTask.Title = dto.Title;
            existingTask.Description = dto.Description;
            existingTask.Status = dto.Status;
            existingTask.Priority = dto.Priority;
            existingTask.DueDate = dto.DueDate;

            await _taskRepository.UpdateTaskAsync(existingTask);
            return Ok(existingTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            return Ok();
        }
    }
}
