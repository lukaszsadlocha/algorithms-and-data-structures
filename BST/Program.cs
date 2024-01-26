// ReSharper disable TailRecursiveCall
Console.WriteLine("Hello, BST!");

var bst = new BinarySearchTree<int>();

bst.Add(12);
bst.Add(7);
bst.Add(15);
bst.Add(18);
bst.Add(16);
bst.Add(3);

/*
         12
         / \
        7  15
       /     \
      3       18
              /
             16
*/

Console.WriteLine("\nSearch result of 18 is {0}", bst.Search(18));
Console.WriteLine("\nSearch result of 4 is {0}", bst.Search(4));
Traversals(); 


void Traversals()
{
    Console.WriteLine("\nIn-Order");
    bst.InOrderTraversal(); // 3,7,12,15,16,18

    Console.WriteLine("\nPre-Order");
    bst.PreOrderTraversal(); //12, 7, 3, 15, 18, 16

    Console.WriteLine("\nPost-Order");
    bst.PostOrderTraversal(); //3, 7, 16, 18, 15, 12
}

public class BinarySearchTree<T> where T : IComparable<T>
{


    private Node? _root;

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
        if(node is null) return null;

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
