using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        private BinaryTreeNode _head;

        public void BuildTree(int[] array)
        {
            foreach (var element in array)
            {
                Add(element);
            }
        }
        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode(value);
            }
            else
            {
                AddTo(_head, new BinaryTreeNode(value));
            }
        }

        private static void AddTo(BinaryTreeNode node, BinaryTreeNode valueNode)
        {
            if (valueNode.Value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = valueNode;
                    valueNode.ParentNode = node;
                }
                else
                {
                    AddTo(node.LeftNode, valueNode);
                }
            }
            else if (valueNode.Value.CompareTo(node.Value) > 0)
            {
                if (node.RightNode == null)
                {
                    node.RightNode = valueNode;
                    valueNode.ParentNode = node;
                }
                else
                {
                    AddTo(node.RightNode, valueNode);
                }
            }
        }

        public int GetHeight(int height = 1, BinaryTreeNode starterNode = null )
        {
            if (_head == null)
            {
                return 0;
            }
            
            starterNode ??= _head;

            if (starterNode.LeftNode == null && starterNode.RightNode == null)
            {
                return height;
            }

            int leftHeight = 0;
            int rightHeight = 0;
            if (starterNode.LeftNode != null)
            { 
                leftHeight = GetHeight(height + 1, starterNode.LeftNode);
            }

            if (starterNode.RightNode != null)
            {
                rightHeight = GetHeight(height + 1, starterNode.RightNode);
            }

            return leftHeight > rightHeight ? leftHeight : rightHeight;
        }
        
        public bool Contains(int value) => FindByValue(value) != null;

        public bool Remove(int value)
        {
            BinaryTreeNode current = FindByValue(value);

            if (current == null)
            {
                return false;
            }
            
            BinaryTreeNode parent = current.ParentNode;
            
            if (current.RightNode == null || current.LeftNode == null)
            {
                BinaryTreeNode nodeToPlace = current.RightNode ?? current.LeftNode;
                if (parent == null)
                {
                    _head = nodeToPlace;
                }
                else
                {
                    if (parent.LeftNode.CompareTo(current.Value) == 0)
                        parent.LeftNode = nodeToPlace;
                    else
                        parent.RightNode = nodeToPlace;
                }
            }

            if (current.RightNode != null && current.LeftNode != null)
            {
                if (parent == null)
                {
                    _head = current.RightNode;
                    AddTo(_head, current.LeftNode);
                }
                else
                {
                    if (parent.LeftNode != null && parent.LeftNode.CompareTo(current.Value) == 0)
                    {
                        parent.LeftNode = current.LeftNode;
                        AddTo(parent.LeftNode, current.RightNode);
                    }

                    if (parent.RightNode != null && parent.RightNode.CompareTo(current.Value) == 0)
                    {
                        parent.RightNode = current.LeftNode;
                        AddTo(parent.RightNode, current.RightNode);
                    }
                }
            }
            
            return true;
        }

        private BinaryTreeNode FindByValue(int value, BinaryTreeNode headOfSubtree = null)
        {
            BinaryTreeNode current = headOfSubtree ?? _head;
            
            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    current = current.LeftNode;
                }
                else if (result < 0)
                {
                    current = current.RightNode;
                }
                else
                    break;
            }

            return current;
        }
        
        public void PrintTree()
        {
            TreePrinter.PrintNode(_head);
        }

        public List<int> AscendingSequence()
        {
            List<int> ascendingList = new List<int>();
            InAscendingOrderWalk(_head, ascendingList);
            return ascendingList;
        }

        public List<int> DescendingSequence()
        {
            List<int> descendingList = new List<int>();
            InDescendingOrderWalk(_head, descendingList);
            return descendingList;
        }

        public List<int> EquivalentSequence()
        {
            List<int> equivalentList = new List<int>();
            InSourceOrderWalk(_head, equivalentList);
            return equivalentList;
        }

        private void InAscendingOrderWalk(BinaryTreeNode node, List<int> ascendingList)
        {
            if (node != null)
            {
                InAscendingOrderWalk(node.LeftNode, ascendingList);
                ascendingList.Add(node.Value);
                InAscendingOrderWalk(node.RightNode, ascendingList);
            }
        }

        private void InDescendingOrderWalk(BinaryTreeNode node, List<int> descendingList)
        {
            if (node != null)
            {
                InDescendingOrderWalk(node.RightNode, descendingList);
                descendingList.Add(node.Value);
                InDescendingOrderWalk(node.LeftNode, descendingList);
            }
        }

        private void InSourceOrderWalk(BinaryTreeNode node, List<int> equivalentList)
        {
            if (node != null)
            {
                equivalentList.Add(node.Value);
                InSourceOrderWalk(node.LeftNode, equivalentList);
                InSourceOrderWalk(node.RightNode, equivalentList);
            }
        }

        public List<int> Across()
        {
            List<int> finalList = new List<int>();
            Queue<BinaryTreeNode> workingQueue = new Queue<BinaryTreeNode>();
            workingQueue.Enqueue(_head);

            while (workingQueue.Count != 0)
            {
                
                if (workingQueue.Peek().LeftNode != null)
                {
                    workingQueue.Enqueue(workingQueue.Peek().LeftNode);
                }

                if (workingQueue.Peek().RightNode != null)
                {
                    workingQueue.Enqueue(workingQueue.Peek().RightNode);
                }
                
                finalList.Add(workingQueue.Dequeue().Value);
            }

            return finalList;
        }

        public int FindKthMinimalElement(int k, BinaryTreeNode headOfSubtree = null)
        {
            headOfSubtree ??= _head;
            List<int> listOfElements = new List<int>();
            InAscendingOrderWalk(headOfSubtree, listOfElements);
            
            return listOfElements[k - 1];
        }
    }
}