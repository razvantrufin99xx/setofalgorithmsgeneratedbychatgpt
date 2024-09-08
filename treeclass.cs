Here is an example implementation of a tree class in C#:

```
public class TreeNode<T>
{
    public T Value { get; private set; }
    public List<TreeNode<T>> Children { get; private set; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(T value)
    {
        Children.Add(new TreeNode<T>(value));
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }

    public void RemoveChild(TreeNode<T> child)
    {
        Children.Remove(child);
    }
}

public class Tree<T>
{
    public TreeNode<T> Root { get; private set; }

    public Tree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }
}
```

This implementation uses two classes, `TreeNode<T>` and `Tree<T>`. The `TreeNode<T>` class represents a single node in the tree, with a value of type `T` and a list of child nodes. The `Tree<T>` class represents the entire tree, with a `Root` property that points to the root node of the tree.

The `TreeNode<T>` class has an overloaded `AddChild` method that allows for adding a child node either by passing in a value of type `T` or an existing `TreeNode<T>` object. The `RemoveChild` method removes a child node from the list of children.

The `Tree<T>` class has a single constructor that takes a value of type `T` for the root node.