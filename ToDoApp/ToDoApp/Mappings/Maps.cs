using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<ToDoItem, ToDoItemVM>().ReverseMap();
        }
        
    }
}
