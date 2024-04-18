
using Filter.Demo;
using GamiDroid.Filter.EF.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using var db = new DemoDbContext();

while(true)
{
    Console.Write("Filter: ");
    var input = Console.ReadLine();
    
    var query = db.Projects.ApplySearch(input);
    var queryString = query.ToQueryString();
    
    Console.WriteLine();
    Console.WriteLine(queryString);
    Console.WriteLine();

    var sw = Stopwatch.StartNew();

    var count = await query.CountAsync();

    sw.Stop();

    Console.WriteLine($"Count {count}");
    Console.WriteLine($"And it took {sw.ElapsedMilliseconds}ms"); 
}
