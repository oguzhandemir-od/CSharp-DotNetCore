using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Entities.Enums;

namespace TaskManagement.Application.DTOs
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status {  get; set; }
        public TaskPriority Priority {  get; set; }
        public DateTime DueDate {  get; set; }
    }
}
