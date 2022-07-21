using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2.Utils.Abstracts
{
    public abstract class Person
    {
        public string? Name
        {
            get => default;
            set
            {
            }
        }

        protected Person()
        {
        }

        protected Person(string? name)
        {
            Name = name;
        }
    }
}