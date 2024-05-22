using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int[]> datasets = new List<int[]>
        {
            new int[] { 20, 4, 26, 3, 9, 15, 30, 21, 2, 7 },
            new int[] { 50, 30, 70, 20, 40, 60, 80, 10, 35, 75 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
            new int[] { 15, 5, 20, 3, 10, 17, 25, 8, 12, 22 }
        };

        for (int i = 0; i < datasets.Count; i++)
        {
            Console.WriteLine($"\nDataset {i + 1}:");
            TestAVLTree(datasets[i]);
        }
    }

    private static void TestAVLTree(int[] dataset)
    {
        AVLTree avlTree = new AVLTree();
        foreach (var value in dataset)
        {
            avlTree.Add(value);
        }

        Console.WriteLine("Tree Structure:");
        avlTree.PrintTree();

        int searchValue = dataset[dataset.Length / 2];
        TreeNode? foundNode = avlTree.Search(searchValue);
        Console.WriteLine(foundNode != null ? $"Found {searchValue}" : $"{searchValue} not found");

        if (avlTree.Root != null)
        {
            avlTree.Delete(avlTree.FindMin((AVLTreeNode)avlTree.Root).Value);

            Console.WriteLine("Tree Structure After Deleting Minimum Element:");
            avlTree.PrintTree();
        }

        Console.WriteLine("PreOrder Traversal:");
        avlTree.PreOrderTraversal(value => Console.Write($"{value} "));
        Console.WriteLine();

        Console.WriteLine("InOrder Traversal:");
        avlTree.InOrderTraversal(value => Console.Write($"{value} "));
        Console.WriteLine();

        Console.WriteLine("LevelOrder Traversal:");
        avlTree.LevelOrderTraversal(value => Console.Write($"{value} "));
        Console.WriteLine();
    }
}
