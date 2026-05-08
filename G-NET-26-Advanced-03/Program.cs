#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
#endregion
namespace G_NET_26_Advanced_03;
    public class Program { 
        public static void Main(string[] args) {
        #region Ex1: Student Grade Manager
        //1
            List<int> Grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };
            Console.WriteLine("Grades:"); 
            for (int i = 0; i < Grades.Count; i++) 
            Console.WriteLine($"Grade {i + 1}: {Grades[i]}");
            Console.WriteLine($"Total count is: {Grades.Count}");
            Console.WriteLine($"First Grade is: {Grades.First()}");
            





        #endregion


    }
} 

