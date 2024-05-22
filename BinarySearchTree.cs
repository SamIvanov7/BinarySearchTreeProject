using System;
using System.Collections.Generic;
using System.IO;

public class BinarySearchTree
{
    public TreeNode? Root { get; protected set; }

    public void Add(int value)
    {
        if (Root == null)
        {
            Root = new TreeNode(value);
        }
        else
        {
            AddRecursively(Root, value);
        }
    }

    protected void AddRecursively(TreeNode node, int value)
    {
        if (value < node.Value)
        {
            if (node.Left == null)
            {
                node.Left = new TreeNode(value);
            }
            else
            {
                AddRecursively(node.Left, value);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new TreeNode(value);
            }
            else
            {
                AddRecursively(node.Right, value);
            }
        }
    }

    public TreeNode? Search(int value)
    {
        return SearchRecursively(Root, value);
    }

    private TreeNode? SearchRecursively(TreeNode? node, int value)
    {
        if (node == null || node.Value == value)
        {
            return node;
        }
        if (value < node.Value)
        {
            return SearchRecursively(node.Left, value);
        }
        else
        {
            return SearchRecursively(node.Right, value);
        }
    }

    public void Delete(int value)
    {
        Root = DeleteRecursively(Root, value);
    }

    private TreeNode? DeleteRecursively(TreeNode? node, int value)
    {
        if (node == null) return node;

        if (value < node.Value)
        {
            node.Left = DeleteRecursively(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = DeleteRecursively(node.Right, value);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            node.Value = FindMin(node.Right).Value;
            node.Right = DeleteRecursively(node.Right, node.Value);
        }
        return node;
    }

    protected TreeNode FindMin(TreeNode node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    public void PreOrderTraversal(Action<int> action)
    {
        PreOrderTraversal(Root, action);
    }

    private void PreOrderTraversal(TreeNode? node, Action<int> action)
    {
        if (node != null)
        {
            action(node.Value);
            PreOrderTraversal(node.Left, action);
            PreOrderTraversal(node.Right, action);
        }
    }

    public void InOrderTraversal(Action<int> action)
    {
        InOrderTraversal(Root, action);
    }

    private void InOrderTraversal(TreeNode? node, Action<int> action)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, action);
            action(node.Value);
            InOrderTraversal(node.Right, action);
        }
    }

    public void LevelOrderTraversal(Action<int> action)
    {
        if (Root == null) return;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            action(node.Value);

            if (node.Left != null)
            {
                queue.Enqueue(node.Left);
            }
            if (node.Right != null)
            {
                queue.Enqueue(node.Right);
            }
        }
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            SaveNodeToFile(writer, Root);
        }
    }

    private void SaveNodeToFile(StreamWriter writer, TreeNode? node)
    {
        if (node == null)
        {
            writer.WriteLine("#");
            return;
        }

        writer.WriteLine(node.Value);
        SaveNodeToFile(writer, node.Left);
        SaveNodeToFile(writer, node.Right);
    }

    public void LoadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            Root = LoadNodeFromFile(reader);
        }
    }

    private TreeNode? LoadNodeFromFile(StreamReader reader)
    {
        string? line = reader.ReadLine();
        if (line == "#" || line == null)
        {
            return null;
        }

        TreeNode node = new TreeNode(int.Parse(line));
        node.Left = LoadNodeFromFile(reader);
        node.Right = LoadNodeFromFile(reader);

        return node;
    }

    public Dictionary<int, TreeNode> ToDictionary()
    {
        Dictionary<int, TreeNode> dictionary = new Dictionary<int, TreeNode>();
        AddNodeToDictionary(Root, dictionary);
        return dictionary;
    }

    private void AddNodeToDictionary(TreeNode? node, Dictionary<int, TreeNode> dictionary)
    {
        if (node != null)
        {
            dictionary[node.Value] = node;
            AddNodeToDictionary(node.Left, dictionary);
            AddNodeToDictionary(node.Right, dictionary);
        }
    }

    public void PrintTree()
    {
        PrintTree(Root, "", true);
    }

    private void PrintTree(TreeNode? node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "     ";
            }
            else
            {
                Console.Write("L----");
                indent += "|    ";
            }
            Console.WriteLine(node.Value);
            PrintTree(node.Left, indent, false);
            PrintTree(node.Right, indent, true);
        }
    }
}
