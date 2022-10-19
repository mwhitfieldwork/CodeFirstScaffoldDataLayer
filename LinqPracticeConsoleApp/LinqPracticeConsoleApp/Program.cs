using NorthwindScaffold;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPracticeConsoleApp
{
    class Program
    {
        private static northwindContext nwcontext = new northwindContext();
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Contains
            var emp = nwcontext.Employees.Where(x => x.FirstName.Contains("Daphne")).ToList();
            //Console.WriteLine(emp);

            //All
            var isAllProductExpensive = nwcontext.Products.All(x => x.UnitPrice < 2);
            //returns a bool if all of the data in the collection are greateer than 2
            //Console.WriteLine(isAllProductExpensive);

            //Any
            var expensiveProduct = nwcontext.Products.Any(x => x.UnitPrice > 2);
            //returns true if any of the unit prices in the products table are larger than 2
            //Console.WriteLine(expensiveProduct);

            //Concat
            //Concat merges two collections into one, but doesnt remove duplicates
            var numbers1 = new[] { 1, 3, 5, 7, 9 };
            var numbers2 = new[] { 2, 4, 6, 7, 8, 10 };
            var concatenatedNumbers = numbers1.Concat(numbers2);
            //Console.WriteLine(concatenatedNumbers);

            //use distinct to remove duplicates from contact collection
            var concatenatedNoDupNumbers = numbers1.Concat(numbers2).Distinct();
            //Console.WriteLine(concatenatedNoDupNumbers);

            //the easier way is to use a union
            var unionatedNumbers = numbers1.Union(numbers2);
            //Console.WriteLine(unionatedNumbers);

            //Count
            int dairyProducts = nwcontext.Products.Count(x => x.CategoryId.Equals(4));
            //Console.WriteLine(dairyProducts);

            //Distict
            var numbers = new[] { 10, 1, 10, 4, 17, 17, 122 };
            var distinctNumbs = numbers.Distinct();
            //Console.WriteLine(distinctNumbs);

            //First
            var firstProductThatMeetsCriteria = nwcontext.Products.Where(x => x.UnitsInStock > 30).First();
            //Console.WriteLine(firstProductThatMeetsCriteria);

            //Min&MAx
            var LeastExpensiveProduct = nwcontext.Products.Min(x => x.UnitPrice);
            //Console.WriteLine(LeastExpensiveProduct);

            var MostExpensiveProduct = nwcontext.Products.Max(x => x.UnitPrice);
            //Console.WriteLine(MostExpensiveProduct);

            //OrderBy
            var highestProducts = nwcontext.Products.OrderByDescending(x => x.UnitPrice);
            //Console.WriteLine(highestProducts);


            //OfType returns all the objects of given type
            var objects = new object[]
            {
            null,
            1,
            "all",
            2,
            "ducks",
            new List<int>(),
            "are",
            "awesome",
            true
            };

            var strings = objects.OfType<string>();
            //Console.WriteLine(strings);

            //Prepend & Append
            var someNumbers = new[] { 1, 3, 5, 8, 19, 20, 55 };
            var add100InArrayToEnd = someNumbers.Append(120);
            var add100InArrayToBeginning = someNumbers.Prepend(222);
            var addBothEndsOfArray = someNumbers.Append(120).Prepend(500);//usually used together

            //Console.WriteLine(someNumbers);//original array
            //Console.WriteLine(add100InArrayToEnd);
            //Console.WriteLine(add100InArrayToBeginning);
            //Console.WriteLine(addBothEndsOfArray);


            //Select projects each element of a sequence into a new form
            //it simply applies a method defined in lambda 
            //to each of the collection's elements, creating a new collection
            var newNumbers = new[] { 10, 1, 4, 17, 122 };
            var doubledNumbers = newNumbers.Select(n => n * 2);
            //Console.WriteLine(doubledNumbers);

            //Where & Select 
            var heavyOrders = nwcontext.Orders.Where(x => x.Freight > 50).Select(x => x.ShipCity).Distinct();
            //Console.WriteLine(heavyOrders);

            //skips the specified number of records in the recordset
            var skip3Employees = nwcontext.Employees.Skip(3);
            //Console.WriteLine(skip3Employees);

            //var skipToLast3Employees = Employees.SkipLast(3);
            //Console.WriteLine(skipToLast3Employees);

            //get the last elements of a collection 
            var skipToLast3Employees = nwcontext.Employees.Skip(nwcontext.Employees.Count() - 2);
            //Console.WriteLine(skipToLast3Employees);

            //get last half of a record set
            var skipToSecondHalfEmployees = nwcontext.Employees.Skip(nwcontext.Employees.Count() / 2);
            //Console.WriteLine(skipToSecondHalfEmployees);

            //Sum
            var sumOfPrductPrices = nwcontext.Products.Sum(x => x.UnitPrice);
            //Console.WriteLine(sumOfPrductPrices);

            //takes the specified number of result at the beginning of the record set
            var threeHeaviestOrders = nwcontext.Orders.OrderByDescending(x => x.Freight).Take(3).ToList();
            var secondHeaviestOrder = nwcontext.Orders.OrderByDescending(x => x.Freight).Take(2).First();
            var onePercentOfOrders = nwcontext.Orders.Take((int)(nwcontext.Orders.Count() * 0.01));
            //var smallerThanFiftyLbs = Orders.TakeWhile( x => x.Freight < 50);

            //get first half of a record set
            var skipToSecondHalfEmployeesNew = nwcontext.Employees.Take(nwcontext.Employees.Count() / 2);
            //Console.WriteLine(skipToSecondHalfEmployeesNew);

            //Console.WriteLine(threeHeaviestOrders);
            //Console.WriteLine(secondHeaviestOrder);
            //Console.WriteLine(onePercentOfOrders);

            //Where 
            var territoryID = "01581";
            var empTerritories = nwcontext.EmployeeTerritories.Where(x => x.TerritoryId == territoryID);
            //Console.WriteLine(empTerritories);

            //New Collections (Empty)
            var empthInts = Enumerable.Empty<int>();

            //Repeat
            var copy100IntList = Enumerable.Repeat(100, 10);//10 items witha value of 100

            //Repeat2 - indexing the repeated items in a list
            var foxes = Enumerable.Repeat("fox", 3)
                         .Select((word, index) => $"{index + 1}. {word}");
            Console.WriteLine(foxes);

            //Range
            var tenToThirty = Enumerable.Range(10, 21);//first param is the start, the second is the number of times to increment


            //Range (Powers of 2)
            var powerOf2 = Enumerable.Range(0, 10)//create the list of number 0-10
                            .Select(power => Math.Pow(2, power));//calculate eachm number the second power
            Console.WriteLine(powerOf2);

            var letters = Enumerable.Range('A', 10)
                          .Select(number => (char)number);
            Console.WriteLine(letters);

            var nonEmptyNumbers = new[] { 1, 2, 3, };
            var defaultEmpty1 = nonEmptyNumbers.DefaultIfEmpty();
            Console.WriteLine(defaultEmpty1);

            var emptyNumbers = new int[0];
            var defaultEmpty2 = emptyNumbers.DefaultIfEmpty();
            Console.WriteLine(defaultEmpty2);


        }
    }
}
