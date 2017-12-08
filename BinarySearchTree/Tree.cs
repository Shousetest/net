using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Tree<T> : IEnumerable<T>
    {
        public Node<T> Root { get; set; }

        private IComparer<T> Comparer;

        private int Length { get; set; }

        public Tree(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public void Insert(T item)
        {
            var node = new Node<T>(item);
            if (null == Root)
            {
                Root = node;
            } else
            {
                Node<T> currentNode = Root, parentNode = null;

                while (null != currentNode)
                {
                    parentNode = currentNode;
                    if (Comparer.Compare(item, currentNode.Value) < 0)
                    {
                        currentNode = currentNode.LeftNode;
                    } else
                    {
                        currentNode = currentNode.RightNode;
                    }
                }

                if (Comparer.Compare(item, parentNode.Value) < 0)
                {
                    parentNode.LeftNode = node;
                } else
                {
                    parentNode.RightNode = node;
                }
            }
            Length++;
        }

        public bool Remove(T item)
        {
            if (null == Root)
                return false;

            Node<T> parentNode = null;

            var found = Find(item, ref parentNode);

            if (found == null)
                return false;

            if (found.RightNode == null)
            {
                AddChildToParent(parentNode, found, found.LeftNode);
            }
            else if (found.RightNode.LeftNode == null)
            {
                found.RightNode.LeftNode = found.LeftNode;
                AddChildToParent(parentNode, found, found.RightNode);
            }  else {
                Node<T> minNode = found.RightNode.LeftNode, prevNode = found.RightNode;
                while (minNode.LeftNode != null)
                {
                    prevNode = minNode;
                    minNode = minNode.LeftNode;
                }
                prevNode.LeftNode = minNode.RightNode;
                minNode.LeftNode = found.LeftNode;
                minNode.RightNode = found.RightNode;

                AddChildToParent(parentNode, found, minNode);
            }

            Length--;

            return false;
        }

        private void AddChildToParent(Node<T> parent, Node<T> current, Node<T> child)
        {
            if (current == Root)
            {
                Root = child;
                return;
            }
            AddChildToParent(parent, current.Value, child);
        }

        private void AddChildToParent(Node<T> parent, T value, Node<T> child)
        {
            int result = Comparer.Compare(value, parent.Value);
            if (result < 0)
                parent.LeftNode = child;
            else
                parent.RightNode = child;
        }


        public Node<T> Find(T item, ref Node<T> parent)
        {
            var current = Root;
            while (current != null)
            {
                var res = Comparer.Compare(item, current.Value);
                if (res == 0)
                    return current;
                parent = current;
                current = res < 0 ? current.LeftNode : current.RightNode;
            }
            return null;
        }

        

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Preorder(Node<T> node)
        {
            if (null == node)
            {
                yield break;
            }

            yield return node.Value;

            foreach (var n in Preorder(node.LeftNode))
                yield return n;

            foreach (var n in Preorder(node.RightNode))
                yield return n;
        }

        public IEnumerable<T> Postorder(Node<T> node)
        {
            if (null == node)
            {
                yield break;
            }

            foreach (var n in Postorder(node.LeftNode))
                yield return n;

            foreach (var n in Postorder(node.RightNode))
                yield return n;

            yield return node.Value;
        }


        public IEnumerable<T> Inorder(Node<T> node)
        {
            if (null == node)
            {
                yield break;
            }

            foreach (var n in Inorder(node.LeftNode))
                yield return n;

            yield return node.Value;

            foreach (var n in Inorder(node.RightNode))
                yield return n;
        }

    }

    public class Node<TValue>
    {
        public TValue Value;

        public Node<TValue> LeftNode { get; set; }

        public Node<TValue> RightNode { get; set; }

        public Node(TValue value)
        {
            Value = value;
        }
    }
}
