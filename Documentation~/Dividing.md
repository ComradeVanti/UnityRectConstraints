Sometimes you want to divide an existing into multiple smaller sections. An
example would be rows, like in the following example.

```csharp
var rect = new Rect(0, 0, 200, 200);
var rows = rect.Rows(10).Select(row => row.PadBottom(5));

EditorGUI.DrawRect(rect, Color.green);
foreach (var row in rows) EditorGUI.DrawRect(row, Color.blue);
```

![image](./Images/Rows.png)

Similarly there also exists a `Column` method.