// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericCollectionQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Test data class.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">
        /// class data - Name.
        /// </param>
        /// <param name="lastName">
        /// class data - Last name.
        /// </param>
        /// <param name="age">
        /// class data - Age.
        /// </param>
        public Person(string name, string lastName, int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
        }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Method converts class data to string. Required for output.
        /// </summary>
        /// <returns>
        /// Class data as a string.
        /// </returns>
        public override string ToString()
        {
            string output = $"{this.Name}, {this.LastName}, {this.Age}";
            return output;
        }
    }
}
