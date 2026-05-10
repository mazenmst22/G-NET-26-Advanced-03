#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
#endregion
namespace G_NET_26_Advanced_03;
    public class Program {
    #region Comparer tool for leaderboard (Ex2)
    public class ScoreCompare<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
    #endregion
    public static void Main(string[] args) {

        #region Ex1: Student Grade Manager
        //1
        List<int> Grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };
        //2
        Console.WriteLine("Grades:");
        for (int i = 0; i < Grades.Count; i++)
            Console.WriteLine($"Grade {i + 1}: {Grades[i]}");
        Console.WriteLine($"Total count is: {Grades.Count}");
        Console.WriteLine($"First Grade is: {Grades.First()}");
        Console.WriteLine($"Last Grade is: {Grades.Last()}");
        //3
        Grades.Sort();
        Console.WriteLine("Sorted Grades: ");
        for (int i = 0; i < Grades.Count; i++)
            Console.WriteLine($"Grade {i + 1}: {Grades[i]}");
        //4
        foreach (int grade in Grades)
        {
            if (grade > 90)
            {
                Console.WriteLine($"First Grade above 90: {grade}");
                break;
            }
        }
        //5
        Console.WriteLine("Failing Grades: ");
        int idx = 1;
        foreach (int grade in Grades)
        {
            if (grade < 75)
            {
                Console.WriteLine($"Grade {idx}: {grade}");
                idx++;
            }
        }
        //6
        Grades.RemoveAll(g => g < 75);
        //7
        Console.Write("Grades at 100: ");
        int scount = 0;
        foreach (int grade in Grades)
        {
            if (grade == 100)
            {
                scount++;
            }
        }
        Console.Write(scount);
        //8
        List<String> NewGrades = new();
        foreach (int grade in Grades)
        {
            NewGrades.Add($"Grade: {grade}");
        }

        #endregion
        #region Ex2: Leaderboard
        Console.WriteLine();
        //1
        SortedList<int, string> leaderboard = new SortedList<int, string>(new ScoreCompare<int>())
                {
                    {500,"Ahmed" },
                    {200,"Sara" },
                    {800,"Ali" },
                    {350,"Mona" }
                };
        //2
        Console.WriteLine("Players Results: ");
        foreach (var player in leaderboard)
        {

            Console.WriteLine($"Player: {player.Value},Score: {player.Key}");
        }
        //3
        int TopScore = leaderboard.Keys[0];
        string TopPlayer = leaderboard.Values[0];
        Console.WriteLine($"Top player Name: {TopPlayer}, Score: {TopScore}");
        //4
        foreach (var player in leaderboard)
        {
            if (player.Key == 500)
            {
                Console.WriteLine($"Player: {player.Value},Score: {player.Key}");
            }
        }
        //5

        Console.WriteLine(leaderboard.TryGetValue(999, out string? nplayer)
        ? $"Found Player!!!: Player Name {nplayer}, Score 999" :
        "Player with Score 999 not found!!!");
        //6
        leaderboard.Remove(200);
        Console.WriteLine("Updated List:");
        foreach (var player in leaderboard)
        {
            Console.WriteLine($"Player: {player.Value}, Score {player.Key}");
        }
        #endregion
        #region Ex3: Phone Book
        //1
        Dictionary<string, int> Phone = new Dictionary<string, int>()
        {
            {"Ahmed", 01055555555 },
            {"Sara", 01066666666 },
            {"Ali", 01077777777 },
            {"Mona", 01088888888 }
        };
        //2
        Console.WriteLine("Phones before changes: ");
        foreach (var contact in Phone)
        {
            Console.WriteLine($"Name: {contact.Key}, Phone: {contact.Value}");
        }
        if (Phone.Remove("Ahmed", out int value))
        {
            Phone["Mazen"] = value;
        }
        Phone["Mazen"] = 01064262626;
        Console.WriteLine();
        Console.WriteLine("Phones after changes: ");
        foreach (var contact in Phone)
        {
            Console.WriteLine($"Name: {contact.Key}, Phone: {contact.Value}");
        }
        //3
        try
        {
            Phone.Add("Mazen", 01064262626);
            Console.WriteLine("Contact Added Successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: Same contact cannot be added twice.");
        }
        //4
        Console.WriteLine(Phone.TryAdd("Mazen", 01064262626)
            ? $"Contact Added Successfully." :
            "Contact cannot be added twice!!!");
        //5
        Console.WriteLine(Phone.TryGetValue("Shahin", out int sphone) ?
            $"Contact found!!!, Name: Shahin, Contact number: {sphone}" :
            $"Contact not found!!!");
        //6
        var scontact = Phone.GetValueOrDefault("Shahin", -1);
        if (scontact != -1)
        {
            Console.WriteLine($"Contact found!!!, Name: Shahin, Contact number: {scontact}");
        }
        else
        {
            Console.WriteLine("Not Found.");
        }
        //7
        Console.WriteLine("Phone numbers: ");
        int idx2 = 1;
        foreach (var k in Phone.Values)
        {
            Console.Write($"Number {idx2}: {k} | ");
            idx2++;
        }
        Console.WriteLine();
        Console.WriteLine("Contact Names: ");
        foreach (var v in Phone.Keys)
        {
            Console.Write($"Name: {v} | ");
        }
        #endregion
        #region Ex4: Unique Email Validator
        //1
        HashSet<string> Emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        //2
        Emails.Add("ahmed@test.com");
        Emails.Add("AHMED@test.com");
        Emails.Add("sara@test.com");
        Emails.Add("Sara@test.com");
        //3
        Console.WriteLine($"Email Count: {Emails.Count()}");
        //Explanation: HasSet does not allow storing duplicate values, and since we used StringComparer.OrdinalIgnoreCase, it treats 
        //emails with different cases as the same, Sara and sara are considered the same, and Ahmed and AHMED are also considered the same,
        //so only 2 unique emails are stored in the HashSet.

        //4
        HashSet<int> SetA = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> SetB = new HashSet<int> { 4, 5, 6, 7, 8 };
        //5
        SetA.UnionWith(SetB);
        Console.WriteLine($"Result is: {string.Join(", ", SetA)}");
        SetA.IntersectWith(SetB);
        Console.WriteLine($"Result is: {string.Join(", ", SetA)}");
        SetA.ExceptWith(SetB);
        Console.WriteLine($"Result is: {string.Join(", ", SetA)}");
        //6
        HashSet<int> SetC = new HashSet<int> { 1, 2 };
        bool isSubset = SetA.IsSubsetOf(SetC);
        Console.WriteLine($"Is A a subset of C(1,2): {isSubset}");

        #endregion
        #region Ex5: Print Queue Simulator

        Queue<string> Printer = new Queue<string>();
        Printer.Enqueue("Report.pdf");
        Printer.Enqueue("Invoice.pdf");
        Printer.Enqueue("Letter.docx");
        Printer.Enqueue("Resume.pdf");
        Printer.Enqueue("Photo.jpg");
        //1
        int pcount = Printer.Count;
        foreach(string doc in Printer)Console.WriteLine($"Document: {doc}");
        Console.WriteLine(pcount);
        //2
        if( pcount > 0)
        {
            string nextDoc = Printer.Peek();
            Console.WriteLine($"Next document: {nextDoc}");
        }
        //3
        while (Printer.Count > 0)
        {
            string curDoc = Printer.Dequeue();
            Console.WriteLine($"Printing: [{curDoc}]");
        }
        Console.WriteLine();
        Console.WriteLine($"Print job completed.");
        //4
        bool success = Printer.TryDequeue(out string current);

        if (success)
        {
            Console.WriteLine($"Printing: {current}");
        }
        else
        {
            Console.WriteLine("The printer queue is currently empty. Nothing to print.");
            Console.WriteLine($"Value of currentDocument: {current ?? "null"}");
        }
        #endregion
        #region Ex6: Browser History (Undo)
        //1
        Stack<string> browserHistory = new Stack<string>();
        browserHistory.Push("google.com");
        browserHistory.Push("github.com");
        browserHistory.Push("stackoverflow.com");
        browserHistory.Push("youtube.com");
        browserHistory.Push("claude.ai");
        //2
        string currentPage = browserHistory.Peek();
        Console.WriteLine(currentPage);
        //3
        for (int i = 1; i <= 3; i++)
        {
            if (browserHistory.Count > 0)
            {
                string leftPage = browserHistory.Pop();
                Console.WriteLine($"Leaving {leftPage}...");
            }
        }
        //4
        Console.WriteLine();
        Console.WriteLine($"Current Page {browserHistory.Peek()}");
        //5
        bool success1 = browserHistory.TryPop(out string poppedUrl);
        if (success1)
        {
            Console.WriteLine($"Successfully popped: {poppedUrl}");
        }
        else
        {
            Console.WriteLine("Could not pop: The stack is empty.");
            Console.WriteLine($"Value of poppedUrl is: {(poppedUrl == null ? "null" : poppedUrl)}");
        }

        #endregion


    }
} 

