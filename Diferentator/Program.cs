using System;
using System.Collections.Generic;
using System.Linq;

namespace Diferentator
{
    class Diferentator
    {

        static void Main(string[] args)
        {
            string[] servers ={
                            "Alpha",
                            "Beta",
                            "Delta",
                            "Echo",
                            "Epsilon",
                            "Eta",
                            "Fox",
                            "Gama",
                            "Iota",
                            "Omega",
                            "Omicron",
                            "Papa",
                            "Pi",
                            "Sigma",
                            "Tango",
                            "Tau",
                            "Zeta",
                            "Zulu"
            };


            
            string capaPath = @"\\capa\c$\inetpub\Win.Services\Robots";
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(capaPath);
            IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            

            foreach (var server in servers) {
                Console.WriteLine($"█████████████████████████████████      {server}      █████████████████████████████████");
                Console.WriteLine();
                var robotsPath = @"\\" + server + @"\c$\inetpub\Win.Services\Robots";
                System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(robotsPath);            
                IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

                FileCompare myFileCompare = new FileCompare();
                var queryList1Only = (from file in list1 select file).Except(list2, myFileCompare);

                Console.WriteLine("");

                Console.WriteLine("The following files are in list1 but not list2:");
                foreach (var v in queryList1Only)
                {
                    Console.WriteLine(v.FullName);
                }

                // Keep the console window open in debug mode.  
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

                   
        }
    }

    class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
    {
        public FileCompare() { }

        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
        {
            return (f1.Name == f2.Name &&
                    f1.Length == f2.Length);
        }
        public int GetHashCode(System.IO.FileInfo fi)
        {
            string s = $"{fi.Name}{fi.Length}";
            return s.GetHashCode();
        }
    }
}

