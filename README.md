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
We can use `QueryReadTools.ReadQueryFromConsole(bool slowMode)` method to grab a Query from the console.
Slow mode format given below:
```sql
from Users
where Age > 25 or Age < 60 and FullName = "Denis Ritchie"
select Email
```
And the same query in the normal mode:
```sql
from Users where Age > 25 or Age < 60 and FullName = "Denis Ritchie" select Email
```

Ouput is given to the console. In this example using pre-initialized data inside Program.cs, the output should be
```
csharp31@ms.com
----------------------------------------------------------------
denix@rise.net
----------------------------------------------------------------
bugs@company.com
----------------------------------------------------------------
```
