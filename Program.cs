using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Hilbert_curv_test
{
    class Program
    {

        static void Main(string[] args)
        {
            List<int> coord = new List<int> { 1, 2, 3, 4, 1, 1, 3, 5, 6, 0, 0, 0 };
            List<int> xu = new List<int>(coord.Select(x => x).Distinct());
            xu.ForEach(x => Console.WriteLine(x));
            Console.Read();
        }


    }

