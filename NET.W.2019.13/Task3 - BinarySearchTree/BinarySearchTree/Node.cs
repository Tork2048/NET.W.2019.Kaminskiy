// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    /// <summary>
    /// Class that represents node in binary search tree.
    /// </summary>
    /// <typeparam name="T">
    /// Node data type.
    /// </typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Gets or Sets node value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or Sets right subtree.
        /// </summary>
        public Node<T> RightNode { get; set; }

        /// <summary>
        /// Gets or Sets left subtree.
        /// </summary>
        public Node<T> LeftNode { get; set; }
    }
}
