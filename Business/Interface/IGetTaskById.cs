﻿using Business.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IGetTaskById
    {
        public object getTaskById(TaskTrackerContext context, int id);
        
    }
}
