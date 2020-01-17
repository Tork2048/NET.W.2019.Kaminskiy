// <copyright file="Queue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GenericCollectionQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Generic queue class that implements standard methods for queue (Enqueue, Dequeue, Peek).
    /// Supports iterators.
    /// </summary>
    /// <typeparam name="T">
    /// Type of items in collection.
    /// </typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private T[] innerArray;
        private int actualLength = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// Constructor that creates array that will store values.
        /// For better performance array has exceeded capacity.
        /// </summary>
        public Queue()
        {
            this.innerArray = new T[4];
        }

        /// <summary>
        /// Gets the amount of elements in queue.
        /// </summary>
        public int Length
        {
            get
            {
                return this.actualLength;
            }
        }

        /// <summary>
        /// Adds element to the end of queue.
        /// </summary>
        /// <param name="value">
        /// Element to add.
        /// </param>
        public void Enqueue(T value)
        {
            if (this.actualLength == this.innerArray.Length)
            {
                T[] extendedArray = new T[this.innerArray.Length * 2];
                for (int i = 0; i < this.innerArray.Length; i++)
                {
                    extendedArray[i] = this.innerArray[i];
                }

                this.innerArray = extendedArray;
            }

            this.innerArray[this.actualLength] = value;
            this.actualLength++;
        }

        /// <summary>
        /// Extracts the first element in collection.
        /// </summary>
        /// <returns>
        /// first element in collection (T).
        /// </returns>
        public T Dequeue()
        {
            if (this.actualLength == 0)
            {
                throw new IndexOutOfRangeException(message: "No elements to dequeue - queue is empty");
            }

            T value = this.innerArray[0];

            T[] shrinkedArray = new T[this.innerArray.Length];

            for (int i = 1; i < this.actualLength; i++)
            {
                shrinkedArray[i - 1] = this.innerArray[i];
            }

            this.actualLength--;
            this.innerArray = shrinkedArray;
            return value;
        }

        /// <summary>
        /// Return the first element in collection.
        /// </summary>
        /// <returns>
        /// The first element in collection.
        /// </returns>
        public T Peek()
        {
            if (this.actualLength > 0)
            {
                return this.innerArray[0];
            }
            else
            {
                throw new IndexOutOfRangeException(message: "No elements to peek - queue is empty");
            }
        }

        /// <summary>
        /// Returns current class instance as IEnumerator(T).
        /// </summary>
        /// <returns>
        /// IEnumerator(T).
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }

        /// <summary>
        /// Method for iterators that don't support generic collections.
        /// </summary>
        /// <returns>
        /// IEnumerator(T).
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class QueueEnumerator<T> : IEnumerator<T>
        {
            private int position = -1;
            private Queue<T> data;

            public QueueEnumerator(Queue<T> data)
            {
                this.data = data;
            }

            /// <summary>
            /// Gets element at current position.
            /// IEnumerator<T> method implementation.
            /// </summary>
            public T Current
            {
                get
                {
                    if (this.position == -1 || this.position >= this.data.actualLength)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.data.innerArray[this.position];
                }
            }

            /// <summary>
            /// Gets element at current position.
            /// IEnumerator method implementation.
            /// Support for iterators that don't work with generic collections.
            /// </summary>
            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            /// <summary>
            /// Moves position one step further.
            /// </summary>
            /// <returns>
            /// True if still within array range, false otherwise.
            /// </returns>
            public bool MoveNext()
            {
                if (this.position < this.data.actualLength - 1)
                {
                    this.position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Resets iterator's position.
            /// </summary>
            public void Reset()
            {
                this.position = -1;
            }

            /// <summary>
            /// No unmanaged/managed resources here.
            /// Interface requires Dispose method implementation.
            /// </summary>
            void IDisposable.Dispose()
            {
            }
        }
    }
}
