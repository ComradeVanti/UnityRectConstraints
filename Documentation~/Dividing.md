# Dividing rectangles

Sometimes you want to divide an existing into multiple smaller sections. Here
you will find the utilities which allow you to do that.

## Rows/Columns

If you want to split a rectangle into rows or columns use the `Rows`
and `Columns` methods.

```csharp
var rect = new Rect(0, 0, 200, 200);
var rows = rect.Rows(10).Select(row => row.PadBottom(5));

EditorGUI.DrawRect(rect, Color.green);
foreach (var row in rows) EditorGUI.DrawRect(row, Color.blue);
```

![image](./Images/Rows.png)

Notice, I gave the rows some bottom-padding so they don't stick to each other.

## Splitting

You can also split a rectangle into two parts according to some ration. Here is
an example:

```csharp
var rect = new Rect(10, 10, 200, 100);
var (split1, split2) = rect.Split2Horizontal(0.25f);

EditorGUI.DrawRect(split1, Color.red);
EditorGUI.DrawRect(split2, Color.blue);
```

![image](./Images/Split.png)