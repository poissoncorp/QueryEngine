# QueryEngine
**Engine that accepts SQL string** in `from <Source> where <Expression> select <Field>` format and **runs query**.
`Source` is one of the properties on the data source (`IEnumerable`), where `Expression` is a potentially compound predicate that can include equality, range comparisons, etc.

Exemplary data source : 

```csharp
public class Data
{
  public List<User> Users;
  public List<Order> Orders;
  //etc
}
```



Ouput is given to the console.
