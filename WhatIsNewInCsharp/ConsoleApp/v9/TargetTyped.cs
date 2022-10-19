﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v9
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Father Father { get; set; }

        public Student()
        {

        }
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Father
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
