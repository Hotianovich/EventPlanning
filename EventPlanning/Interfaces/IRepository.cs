﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanning.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T t);
        IEnumerable<T> GetAll();
        
    }
}
