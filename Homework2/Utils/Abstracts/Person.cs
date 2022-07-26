﻿namespace Homework2.Utils.Abstracts
{
    /// <summary>
    /// Class represents abstract person.
    /// </summary>
    public abstract class Person
    {
        public string? Name
        {
            get; set;
        }

        protected Person(){}

        protected Person(string? name)
        {
            Name = name;
        }
    }
}