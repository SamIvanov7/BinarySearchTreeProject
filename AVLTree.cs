public class AVLTree : BinarySearchTree
{
    public new void Add(int value)
    {
        Root = AddRecursively((AVLTreeNode?)Root, value);
    }

    private AVLTreeNode AddRecursively(AVLTreeNode? node, int value)
    {
        if (node == null)
        {
            return new AVLTreeNode(value);
        }

        if (value < node.Value)
        {
            node.Left = AddRecursively((AVLTreeNode?)node.Left, value);
        }
        else
        {
            node.Right = AddRecursively((AVLTreeNode?)node.Right, value);
        }

        UpdateHeight(node);
        return Balance(node);
    }

    private void UpdateHeight(AVLTreeNode node)
    {
        node.Height = 1 + Math.Max(GetHeight((AVLTreeNode?)node.Left), GetHeight((AVLTreeNode?)node.Right));
    }

    private int GetHeight(AVLTreeNode? node)
    {
        return node?.Height ?? 0;
    }

    private AVLTreeNode Balance(AVLTreeNode node)
    {
        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (GetBalanceFactor((AVLTreeNode?)node.Left) < 0)
            {
                node.Left = RotateLeft((AVLTreeNode?)node.Left);
            }
            return RotateRight(node);
        }

        if (balanceFactor < -1)
        {
            if (GetBalanceFactor((AVLTreeNode?)node.Right) > 0)
            {
                node.Right = RotateRight((AVLTreeNode?)node.Right);
            }
            return RotateLeft(node);
        }

        return node;
    }

    private int GetBalanceFactor(AVLTreeNode? node)
    {
        return node == null ? 0 : GetHeight((AVLTreeNode?)node.Left) - GetHeight((AVLTreeNode?)node.Right);
    }

    private AVLTreeNode RotateRight(AVLTreeNode? y)
    {
        if (y == null) throw new ArgumentNullException(nameof(y));

        AVLTreeNode x = (AVLTreeNode)y.Left!;
        AVLTreeNode? T2 = (AVLTreeNode?)x.Right;

        x.Right = y;
        y.Left = T2;

        UpdateHeight(y);
        UpdateHeight(x);

        return x;
    }

    private AVLTreeNode RotateLeft(AVLTreeNode? x)
    {
        if (x == null) throw new ArgumentNullException(nameof(x));

        AVLTreeNode y = (AVLTreeNode)x.Right!;
        AVLTreeNode? T2 = (AVLTreeNode?)y.Left;

        y.Left = x;
        x.Right = T2;

        UpdateHeight(x);
        UpdateHeight(y);

        return y;
    }

    public new void Delete(int value)
    {
        Root = DeleteRecursively((AVLTreeNode?)Root, value);
    }

    private AVLTreeNode? DeleteRecursively(AVLTreeNode? node, int value)
    {
        if (node == null) return node;

        if (value < node.Value)
        {
            node.Left = DeleteRecursively((AVLTreeNode?)node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = DeleteRecursively((AVLTreeNode?)node.Right, value);
        }
        else
        {
            if (node.Left == null || node.Right == null)
            {
                node = (AVLTreeNode?)(node.Left ?? node.Right);
            }
            else
            {
                AVLTreeNode temp = FindMin((AVLTreeNode)node.Right);
                node.Value = temp.Value;
                node.Right = DeleteRecursively((AVLTreeNode?)node.Right, temp.Value);
            }
        }

        if (node == null) return node;

        UpdateHeight(node);
        return Balance(node);
    }

    public new AVLTreeNode FindMin(AVLTreeNode node)
    {
        while (node.Left != null)
        {
            node = (AVLTreeNode)node.Left;
        }
        return node;
    }
}

public class AVLTreeNode : TreeNode
{
    public int Height { get; set; }

    public AVLTreeNode(int value) : base(value)
    {
        Height = 1;
    }
}
