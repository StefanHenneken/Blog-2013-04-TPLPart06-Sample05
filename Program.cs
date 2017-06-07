using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Console.WriteLine("Start Run");

            double result01 = 0;
            for (int i = 1; i < 10000; i++)
                result01 += DoSomeWork(i);
            Console.WriteLine("Result: {0}", result01);

            double result02 = 0;
            result02 = ParallelEnumerable.Range(0, 10000).Sum(i => DoSomeWork(i));
            Console.WriteLine("Result: {0}", result02);

            double result03 = 0;
            result03 = (from x in ParallelEnumerable.Range(0, 10000).AsParallel()
                        select x).Sum(i => DoSomeWork(i));
            Console.WriteLine("Result: {0}", result03);

            Console.WriteLine("End Run");
            Console.ReadLine();
        }
        private double DoSomeWork(int index)
        {
            return Math.Sin(index) + Math.Sqrt(index) * Math.Pow(index, 0.14);
        }
    }
}
