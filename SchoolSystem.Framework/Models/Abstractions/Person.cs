﻿namespace SchoolSystem.Framework.Models.Abstractions
{
    using System;
    using System.Text.RegularExpressions;
    using DataModels;
    using Framework.Models.Contracts;

    public abstract class Person : IEntity
    {
        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ValidateParameters();
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int Id { get; private set; }

        public void SetId(int id)
        {
            this.Id = id;
        }

        private void ValidateParameters()
        {
            var patern = new Regex(Constraints.NamePattern);

            if (this.IsOutOfRange(this.FirstName) || patern.IsMatch(this.FirstName) == false)
            {
                throw new ArgumentException("First Name is invalid");
            }

            if (this.IsOutOfRange(this.LastName) || patern.IsMatch(this.LastName) == false)
            {
                throw new ArgumentException("Last Name is invalid");
            }
        }

        private bool IsOutOfRange(string name)
        {
            return name.Length < Constraints.MinNameLength || name.Length > Constraints.MaxNameLength;
        }
    }
}
