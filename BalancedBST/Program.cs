// ReSharper disable TailRecursiveCall
using System.Diagnostics;

Console.WriteLine("Hello, Balanced BST!");

var bst = new AVLBinarySearchTree<int>();

bst.Add(1);
bst.Add(3);
bst.Add(2);
bst.Add(4);

Console.WriteLine("\nIn-Order");
bst.PreOrderTraversal();

bst.LeftRotation();

Console.WriteLine("\nIn-Order after Left rotation");
bst.PreOrderTraversal();


 

public class AVLBinarySearchTree<T> where T : IComparable<T>
{


    private Node? _root;

    public void LeftRotation()
    {
        var oldRoot = _root;
        var newRoot = _root.Right;

        oldRoot.Right = newRoot.Left;

        newRoot.Left = oldRoot;

        _root = newRoot;
    }
    public void RightRotation()
    {
        var oldRoot = _root;
        var newRoot = _root.Left;

        oldRoot.Left = newRoot.Right;

        newRoot.Right = oldRoot;

        _root = newRoot;
    }


    #region Traversals

    public void PostOrderTraversal()
    {
        PostOrderTraversal(_root);
    }

    private static void PostOrderTraversal(Node? node)
    {
        if (node is null) return;

        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.WriteLine(node.Value);
    }


    public void InOrderTraversal()
    {
        InOrderTraversal(_root);
    }

    private static void InOrderTraversal(Node? node)
    {
        if (node is null) return;

        InOrderTraversal(node.Left);
        Console.WriteLine(node.Value);
        InOrderTraversal(node.Right);
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversal(_root);
    }

    private static void PreOrderTraversal(Node? node)
    {
        if (node is null) return;

        Console.WriteLine(node.Value);
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    #endregion

    #region Add

    public void Add(T value)
    {
        if (_root is null)
        {
            _root = new Node(value);
            return;
        }

        Add(value, _root);
    }

    private static void Add(T value, Node node)
    {
        if (value.CompareTo(node.Value) < 0)
        {
            //is less
            if (node.Left is null)
            {
                node.Left = new Node(value);
                return;
            }

            Add(value, node.Left);
        }
        else
        {
            if (node.Right is null)
            {
                node.Right = new Node(value);
                return;
            }

            Add(value, node.Right);
        }
    }
    #endregion

    #region Search

    public Node? Search(T value)
    {
        return Search(value, _root);
    }

    private Node? Search(T value, Node? node)
    {
        if (node is null) return null;

        return value.CompareTo(node.Value) switch
        {
            0 => node,
            < 0 => Search(value, node.Left),
            > 0 => Search(value, node.Right)
        };
    }

    #endregion


    [DebuggerDisplay("Value: {Value}")]
    public class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public T Value { get; private init; }

        public Node(T value)
        {
            Value = value;
        }

        public int ChildrenNumber()
        {
            var number = 0;
            if (Left is not null) number++;
            if (Right is not null) number++;
            return number;
        }

        public override string ToString()
        {
            return Value.ToString()!;
        }
    }
}