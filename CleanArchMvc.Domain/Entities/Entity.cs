using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id{get; protected set;}
    }
}