﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo
{

    class Student
    {
        /// <summary>
        /// _rollNo can only be assigned to or changed in the constructor or using direct initialization
        /// after it returns from the constructor, the variable value is locked and cannot be changed
        /// </summary>
        private readonly int _rollNo;
        private string _name;

        public Student(int rollNo, string name)
        {
            _rollNo = rollNo;
            _name = name;
        }

        public void Show()
        {
            _name = "";
        }
    }

    internal class ReadonlyDemo
    {
        internal static void Demo()
        {

        }
    }
}
