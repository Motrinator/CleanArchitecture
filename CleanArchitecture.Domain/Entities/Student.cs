﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
