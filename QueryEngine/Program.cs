﻿using System.Collections.Generic;

namespace QueryEngine
{
    class Program
    {
        static void Main()
        {
            QueryEngine queryEngine = new QueryEngine(new Data()
            {
                Users = new List<User>(new[]
                {
                    new User() {Age = 21, Email = "csharp@ms.com", FullName = "Anthony Fantano"},
                    new User() {Age = 31, Email = "csharp31@ms.com", FullName = "John Doe"},
                    new User() {Age = 55, Email = "jobs@ravendb.net", FullName = "Denis Ritchie"},
                    new User() {Age = 46, Email = "jobs@hibernatingrhinos.com", FullName = "Alfred Aho"}
                })
            });

            Query q = QueryReadTools.ReadQueryFromConsole(true);
            queryEngine.RunConsoleQuery(q);
        }
    }
}
