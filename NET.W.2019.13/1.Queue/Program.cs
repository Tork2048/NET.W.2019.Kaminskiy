// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericCollectionQueue
{
    using System;

    /// <summary>
    /// Class that contains entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">
        /// Start arguments.
        /// </param>
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < 15; i++)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine("Type - int\n");
            Console.WriteLine("Source queue");
            DisplayQueue(queue);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Console.WriteLine("Peek:");
            Console.WriteLine(queue.Peek());
            Console.WriteLine("Dequeue:");
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine("Peek:");
            Console.WriteLine(queue.Peek());

            Console.WriteLine("queue:");
            DisplayQueue(queue);
            Console.WriteLine();

            Console.WriteLine("Type - Person\n");

            Queue<Person> people = new Queue<Person>();
            Person p1 = new Person("Max", "Kaminskiy", 29);
            Person p2 = new Person("Bob", "Bobkins", 45);
            Person p3 = new Person("Steve", "Smith", 39);
            people.Enqueue(p1);
            people.Enqueue(p2);
            people.Enqueue(p3);

            Console.WriteLine("Source queue:");
            DisplayQueue(people);

            Console.WriteLine("Peek:");
            Console.WriteLine(people.Peek());
            Console.WriteLine("Dequeue:");
            Console.WriteLine(people.Dequeue());
            Console.WriteLine("Peek:");
            Console.WriteLine(people.Peek());

            Console.WriteLine("queue:");
            DisplayQueue(people);
        }

        public static void DisplayQueue<T>(Queue<T> queue)
        {
            foreach (T item in queue)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
