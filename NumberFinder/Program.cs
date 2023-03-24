using NumberFinder;

Computer c = new();
c
    // An example
    //.Equal("A*B,CD")
    //.Equal("B*C,DE")
    //.Unique("A,B,C,D,E,F,G,H,I,J")
    //.Equal("A+F,D+I,E+J")
    //.Even("B+G,C+H")
    //.Equal("C*E,I")

    // The other example
    //.Equal("8,A+B+C")
    //.Equal("10,A+D,B+E,C+F")
    //.Equal("13,C+E")
    //.Unique("A,B,C,D,E,F")

    //Specific problem
    .Equal("A*B/C,4")
    .Equal("D-E-F,2")
    .Equal("G+H-I,6")
    .Equal("A*D-G,6")
    .Equal("B/E/H,1")
    .Equal("C+F/I,1")
    .Unique("A,B,C,D,E,F,G,H,I")

;


var results = c.Calculate();

Console.WriteLine($"Found: {results.Count()} results with {c.Attempts} iterations");

Console.WriteLine(string.Join(",", c.Unknowns.ToArray()));
foreach (var result in results.Keys)
{
    Console.WriteLine(result);
}