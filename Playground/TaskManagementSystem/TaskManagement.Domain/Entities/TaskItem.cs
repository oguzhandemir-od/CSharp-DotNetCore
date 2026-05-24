using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Domain.Entities.Enums;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        private DateTime _dueDate;

        public DateTime DueDate
        {
            get { return _dueDate; }
            set
            {
                if(value < DateTime.UtcNow)
                {
                    throw new ArgumentException("Son teslim tarihi geçmiş bir tarih olamaz!");
                }
                _dueDate= value;
            }
        }

    }
}
