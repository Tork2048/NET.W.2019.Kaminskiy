// <copyright file="Tree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that represents Binary Search Tree behaviour.
    /// </summary>
    /// <typeparam name="T">
    /// Data type in tree.
    /// </typeparam>
    public class Tree<T>
    {
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree{T}"/> class.
        /// Constructor take no arguments. Extracts default Comparer directly from T.
        /// </summary>
        public Tree()
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new ArgumentException(message: $"The {typeof(T)} must immplement IComparable<{typeof(T)}> interface.");
            }

            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree{T}"/> class.
        /// Constructor takes custom comparer as argument and sets this.comparer.
        /// </summary>
        /// <param name="comparer">
        /// Custom comparer.
        /// </param>
        public Tree(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), message: "Tree cannot be constructed with null comparer");
            }

            this.comparer = comparer;
        }

        /// <summary>
        /// Gets Root node in tree.
        /// </summary>
        public Node<T> Root { get; private set; }

        /// <summary>
        /// Method Adds node to the tree while keeping it balanced.
        /// </summary>
        /// <param name="value">
        /// Data value for the node.
        /// </param>
        /// <returns>
        /// If there is no such value in the tree returns true.
        /// </returns>
        public bool Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), message: "Null values cannot be added to the tree.");
            }

            Node<T> previous = null;
            Node<T> next = this.Root;

            while (next != null)
            {
                previous = next;
                if (this.comparer.Compare(value, next.Value) == -1)
                {
                    next = next.LeftNode;
                }
                else if (this.comparer.Compare(value, next.Value) == 1)
                {
                    next = next.RightNode;
                }
                else
                {
                    return false;
                }
            }

            Node<T> newNode = new Node<T>();
            newNode.Value = value;

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (this.comparer.Compare(value, previous.Value) == -1)
                {
                    previous.LeftNode = newNode;
                }
                else
                {
                    previous.RightNode = newNode;
                }
            }

            return true;
        }

        /// <summary>
        /// External method searches for Node with specific value in the tree.
        /// </summary>
        /// <param name="value">
        /// Value to search for.
        /// </param>
        /// <returns>
        /// Node with specific value (null if not found).
        /// </returns>
        public Node<T> Find(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), message: "Cannot search for null");
            }

            return this.Find(value, this.Root);
        }

        /// <summary>
        /// External method that removes Node with specific value from the tree.
        /// </summary>
        /// <param name="value">
        /// Value to remove.
        /// </param>
        public void Remove(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), message: "Cannot remove null");
            }

            this.Remove(this.Root, value);
        }

        /// <summary>
        /// Method allows to iterate Search tree in preorder mode.
        /// </summary>
        /// <param name="parent">
        /// Root Node.
        /// </param>
        /// <returns>
        /// IEnumerable object for iterator.
        /// </returns>
        public IEnumerable<T> TraversePreOrder()
        {
            List<T> list = new List<T>();
            this.CollectTraversePreOrder(this.Root, list);

            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        /// <summary>
        /// Method allows to iterate Search tree in inorder mode.
        /// </summary>
        /// <param name="parent">
        /// Root Node.
        /// </param>
        /// <returns>
        /// IEnumerable object for iterator.
        /// </returns>
        public IEnumerable<T> TraverseInOrder()
        {
            List<T> list = new List<T>();
            this.CollectTraverseInOrder(this.Root, list);

            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        /// <summary>
        /// Method allows to iterate Search tree in postorder mode.
        /// </summary>
        /// <param name="parent">
        /// Root Node.
        /// </param>
        /// <returns>
        /// IEnumerable object for iterator.
        /// </returns>
        public IEnumerable<T> TraversePostOrder()
        {
            List<T> list = new List<T>();
            this.CollectTraversePostOrder(this.Root, list);

            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        /// <summary>
        /// Starts traverse with given root node, then left subtree, then right subtree.
        /// Works recursively.
        /// Creates collection of node items.
        /// </summary>
        /// <param name="parent">
        /// Root node.
        /// </param>
        /// <param name="list">
        /// Used to store node values collection.
        /// </param>
        private void CollectTraversePreOrder(Node<T> parent, List<T> list)
        {
            if (parent != null)
            {
                list.Add(parent.Value);
                this.CollectTraversePreOrder(parent.LeftNode, list);
                this.CollectTraversePreOrder(parent.RightNode, list);
            }
        }

        /// <summary>
        /// Starts traverse from left subtree, then given root, then right subtree.
        /// Works recursively.
        /// Creates collection of node items.
        /// </summary>
        /// <param name="parent">
        /// Root node.
        /// </param>
        /// <param name="list">
        /// Used to store node values collection.
        /// </param>
        private void CollectTraverseInOrder(Node<T> parent, List<T> list)
        {
            if (parent != null)
            {
                this.CollectTraverseInOrder(parent.LeftNode, list);
                list.Add(parent.Value);
                this.CollectTraverseInOrder(parent.RightNode, list);
            }
        }

        /// <summary>
        /// Starts traverse with left subtree, then right subtree, the root node.
        /// Works recursively.
        /// Creates collection of node items.
        /// </summary>
        /// <param name="parent">
        /// Root node.
        /// </param>
        /// <param name="list">
        /// Used to store node values collection.
        /// </param>
        private void CollectTraversePostOrder(Node<T> parent, List<T> list)
        {
            if (parent != null)
            {
                this.CollectTraversePostOrder(parent.LeftNode, list);
                this.CollectTraversePostOrder(parent.RightNode, list);
                list.Add(parent.Value);
            }
        }

        /// <summary>
        /// Find method for internal use.
        /// Additional argument - root node allows to use recursion.
        /// </summary>
        /// <param name="value">
        /// Node value to search for.
        /// </param>
        /// <param name="parent">
        /// Root node.
        /// </param>
        /// <returns>
        /// Node with specifiv value or null if not found.
        /// </returns>
        private Node<T> Find(T value, Node<T> parent)
        {
            if (parent != null)
            {
                if (this.comparer.Compare(value, parent.Value) == 0)
                {
                    return parent;
                }

                if (this.comparer.Compare(value, parent.Value) == -1)
                {
                    return this.Find(value, parent.LeftNode);
                }
                else
                {
                    return this.Find(value, parent.RightNode);
                }
            }

            return null;
        }

        /// <summary>
        /// Remove method for internal use.
        /// Additional argument - root node allows to use recursion.
        /// </summary>
        /// <param name="parent">
        /// Root node.
        /// </param>
        /// <param name="value">
        /// Specofoc node value to remove.
        /// </param>
        /// <returns>
        /// Removed node.
        /// </returns>
        private Node<T> Remove(Node<T> parent, T value)
        {
            if (parent == null)
            {
                return parent;
            }

            if (this.comparer.Compare(value, parent.Value) == -1)
            {
                parent.LeftNode = this.Remove(parent.LeftNode, value);
            }
            else if (this.comparer.Compare(value, parent.Value) == 1)
            {
                parent.RightNode = this.Remove(parent.RightNode, value);
            }
            else
            {
                if (parent.LeftNode == null)
                {
                    return parent.RightNode;
                }
                else if (parent.RightNode == null)
                {
                    return parent.LeftNode;
                }

                parent.Value = this.MinValue(parent.RightNode);
                parent.RightNode = this.Remove(parent.RightNode, parent.Value);
            }

            return parent;
        }

        private T MinValue(Node<T> node)
        {
            T minValue = node.Value;

            while (node.LeftNode != null)
            {
                minValue = node.LeftNode.Value;
                node = node.LeftNode;
            }

            return minValue;
        }
    }
}
