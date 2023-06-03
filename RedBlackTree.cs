using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;



namespace BinaryTreeApp
{
    public class RedBlackTree
    {
        public Node Root;
        public event EventHandler TreeChanged;
        public enum NodeColor { Red, Black }

        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public Node Parent;
            public NodeColor Color;

            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
                Parent = null;
                Color = NodeColor.Red;
            }
        }
        private Node Min(Node node)
        {
            Node currentNode = node;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode;
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                Root.Color = NodeColor.Black;
            }
            else
            {
                Root = Insert(Root, value);
                Root.Color = NodeColor.Black;
            }

            TreeChanged?.Invoke(this, EventArgs.Empty);
            OnTreeChanged();
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (value < node.Data)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Data)
            {
                node.Right = Insert(node.Right, value);
            }

            // Kırmızı-Siyah Ağaç düzeltme işlemleri:
            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }
        private bool IsRed(Node node)
        {
            if (node == null) return false;
            return node.Color == NodeColor.Red;
        }

        private Node RotateLeft(Node node)
        {
            Node newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
            newRoot.Color = node.Color;
            node.Color = NodeColor.Red;
            return newRoot;
        }

        private Node RotateRight(Node node)
        {
            Node newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            newRoot.Color = node.Color;
            node.Color = NodeColor.Red;
            return newRoot;
        }

        private void FlipColors(Node node)
        {
            node.Color = NodeColor.Red;
            node.Left.Color = NodeColor.Black;
            node.Right.Color = NodeColor.Black;
        }


        // ... (Insert, FixInsert, RotateLeft, RotateRight ve diğer eklemeyle ilgili metotlar)

        public void Delete(int value)
        {
            if (Root == null)
            {
                return;
            }

            if (!Search(value))
            {
                return;
            }

            if (!IsRed(Root.Left) && !IsRed(Root.Right))
            {
                Root.Color = NodeColor.Red;
            }

            Root = Delete(Root, value);

            if (Root != null)
            {
                Root.Color = NodeColor.Black;
            }

            TreeChanged?.Invoke(this, EventArgs.Empty);
            OnTreeChanged();
        }
        private Node Delete(Node node, int value)
        {
            if (value < node.Data)
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                {
                    node = MoveRedLeft(node);
                }

                node.Left = Delete(node.Left, value);
            }
            else
            {
                if (IsRed(node.Left))
                {
                    node = RotateRight(node);
                }

                if (value == node.Data && (node.Right == null))
                {
                    return null;
                }

                if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                {
                    node = MoveRedRight(node);
                }

                if (value == node.Data)
                {
                    Node min = Min(node.Right);
                    node.Data = min.Data;
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = Delete(node.Right, value);
                }
            }

            return FixUp(node);
        }

        private Node MoveRedLeft(Node node)
        {
            FlipColors(node);
            if (IsRed(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
                FlipColors(node);
            }
            return node;
        }

        private Node MoveRedRight(Node node)
        {
            FlipColors(node);
            if (IsRed(node.Left.Left))
            {
                node = RotateRight(node);
                FlipColors(node);
            }
            return node;
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return null;
            }

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {
                node = MoveRedLeft(node);
            }

            node.Left = DeleteMin(node.Left);

            return FixUp(node);
        }

        private Node FixUp(Node node)
        {
            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }
        private void OnTreeChanged()
        {
            TreeChanged?.Invoke(this, EventArgs.Empty);
        }
        // ... (DeleteNode, FixDelete, FindSiblingNode ve diğer silmeyle ilgili metotlar)
        public bool Search(int value)
        {
            return Search(Root, value) != null;
        }

        private Node Search(Node node, int value)
        {
            if (node == null || node.Data == value)
                return node;

            if (value < node.Data)
                return Search(node.Left, value);

            return Search(node.Right, value);
        }

        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
            Console.WriteLine();
        }

        private void PreorderTraversal(Node node)
        {
            if (node == null) return;

            Console.Write(node.Data + " ");
            PreorderTraversal(node.Left);
            PreorderTraversal(node.Right);
        }

        public void InorderTraversal()
        {
            InorderTraversal(Root);
            Console.WriteLine();
        }

        private void InorderTraversal(Node node)
        {
            if (node == null) return;

            InorderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InorderTraversal(node.Right);
        }

        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
            Console.WriteLine();
        }

        private void PostorderTraversal(Node node)
        {
            if (node == null) return;

            PostorderTraversal(node.Left);
            PostorderTraversal(node.Right);
            Console.Write(node.Data + " ");
        }
        public void PreorderTraversal(Action<int> action)
        {
            PreorderTraversal(Root, action);
        }

        private void PreorderTraversal(Node node, Action<int> action)
        {
            if (node == null) return;

            action(node.Data);
            PreorderTraversal(node.Left, action);
            PreorderTraversal(node.Right, action);
        }

        public void InorderTraversal(Action<int> action)
        {
            InorderTraversal(Root, action);
        }

        private void InorderTraversal(Node node, Action<int> action)
        {
            if (node == null) return;

            InorderTraversal(node.Left, action);
            action(node.Data);
            InorderTraversal(node.Right, action);
        }

        public void PostorderTraversal(Action<int> action)
        {
            PostorderTraversal(Root, action);
        }

        private void PostorderTraversal(Node node, Action<int> action)
        {
            if (node == null) return;

            PostorderTraversal(node.Left, action);
            PostorderTraversal(node.Right, action);
            action(node.Data);
        }

    }

}