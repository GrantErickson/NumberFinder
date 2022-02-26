// See https://aka.ms/new-console-template for more information
using NumberFinder;

Computer c = new();
c
    .Equal("A*B,CD")
    .Equal("B*C,DE")
    .Unique("A,B,C,D,E,F,G,H,I,J")
    .Equal("A+F,D+I,E+J")
    .Even("B+G,C+H")
    .Equal("C*E,I")
;
//.Even("A,B");
var results = c.Calculate();

Console.WriteLine($"Found: {results.Count()} results with {c.Attempts} iterations");

Console.WriteLine(string.Join(",", c.Unknowns.ToArray()));
foreach(var result in results.Keys)
{
    Console.WriteLine(result);
}