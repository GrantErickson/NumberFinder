﻿using NumberFinder;

// An example
//Computer c = new();
//c
//.Equal("A*B,CD")
//.Equal("B*C,DE")
//.Unique("A,B,C,D,E,F,G,H,I,J")
//.Equal("A+F,D+I,E+J")
//.Even("B+G,C+H")
//.Equal("C*E,I")

// The other example
//Computer c = new();
//c//.Equal("8,A+B+C")
//.Equal("10,A+D,B+E,C+F")
//.Equal("13,C+E")
//.Unique("A,B,C,D,E,F")

//Specific problem
// Make sure this list is sorted from smallest to largest
// The order does matter. The logic is weak so make sure to change the order if things don't work.
Computer c = new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
c
    .Equal("A*B/C,4")
    .Equal("D-E-F,2")
    .Equal("G+H-I,6")
    .Equal("A*D-G,6")
    .Equal("B/E/H,1")
    .Equal("C+F/I,1")
    .Unique("A,B,C,D,E,F,G,H,I")
;

// Example from Dec 2nd 2021
//Computer c = new(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
//c
//    .Unique("A,B,C,D,E,F")
//    .Equal("A+1,E")
//    .Equal("D,A-4")
//    .Equal("A+C,F")
//    .Equal("A+B+C+D+E+F,24")
//;


var results = c.Calculate();



Console.WriteLine($"Found: {results.Count()} results with {c.Attempts} iterations");

Console.WriteLine(string.Join(",", c.Unknowns.ToArray()));
foreach (var result in results.Keys)
{
    Console.WriteLine(result);
}