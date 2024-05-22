# AVL Tree Implementation in C#

This repository contains an implementation of an AVL Tree in C#. 
The AVL Tree is a self-balancing binary search tree where the difference between heights of left and right subtrees cannot be more than one for all nodes.

## Features

- **Add:** Insert elements into the AVL tree while maintaining its balanced property.
- **Search:** Find elements in the AVL tree.
- **Delete:** Remove elements from the AVL tree and re-balance it.
- **Traversals:**
  - PreOrder Traversal
  - InOrder Traversal
  - LevelOrder Traversal
- **Print Tree:** Visualize the structure of the AVL tree.
- **Save and Load:** Persist the AVL tree to a file and load it from a file.

## Files

- `TreeNode.cs`: Defines the `TreeNode` class.
- `BinarySearchTree.cs`: Implements a basic binary search tree.
- `AVLTree.cs`: Extends `BinarySearchTree` to create an AVL tree with balancing logic.
- `Program.cs`: Contains the main program that tests the AVL tree with different datasets.

## Usage

1. **Clone the repository:**

   ```sh
   git clone https://github.com/SamIvanov7/BinarySearchTreeProject.git
   cd BinarySearchTreeProject

2. **Build the project:**

   Open the project in your preferred C# IDE (like Visual Studio) and build the solution.

3. **Run the program:**

    Run the Program.cs to see the AVL tree in action with various datasets.
