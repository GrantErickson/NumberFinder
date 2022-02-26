using NumberFinder;

Computer c = new();
c
    .Equal("A*B,CD")
    .Equal("B*C,DE")
    .Unique("A,B,C,D,E,F,G,H,I,J")
    .Equal("A+F,D+I,E+J")
    .Even("B+G,C+H")
    .Equal("C*E,I")
    // The other example
    //.Equal("8,A+B+C")
    //.Equal("10,A+D,B+E,C+F")
    //.Equal("13,C+E")
    //.Unique("A,B,C,D,E,F")
;


var results = c.Calculate();

Console.WriteLine($"Found: {results.Count()} results with {c.Attempts} iterations");

Console.WriteLine(string.Join(",", c.Unknowns.ToArray()));
foreach (var result in results.Keys)
{
    Console.WriteLine(result);
}