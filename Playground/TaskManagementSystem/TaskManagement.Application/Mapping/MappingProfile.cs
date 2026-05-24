using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Entities;
using AutoMapper;

namespace TaskManagement.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTaskDto, TaskItem>();
            CreateMap<UpdateTaskDto, TaskItem>();
        }
    }
}
