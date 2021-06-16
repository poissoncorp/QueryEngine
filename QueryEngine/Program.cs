using System;
using System.Collections.Generic;

namespace QueryEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data()
            {
                Users = new List<User>(new User[] {new User() { Age = 21, Email = "csharp@ms.com", FullName = "Anthony Fan" },
                                                            new User() { Age = 31, Email = "csharp31@ms.com", FullName = "John Doe" } })
            };
            Query q = QueryReadTools.ReadQueryFromConsole();
            QueryEngine queryEngine = new QueryEngine();
            queryEngine.RunConsoleQuery(data, q);
        }
    }
}
