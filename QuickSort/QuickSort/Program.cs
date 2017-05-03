using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var Data = new Int32[10];
            using (var Reader = new StreamReader("Data.txt"))
                for (Int32 Iterator = 0; Iterator < 10; Iterator++)
                    Data[Iterator] = Int32.Parse(Reader.ReadLine());

            Int64 ComparisonsCount = QuickSortAL.SortAndCountComparisons(Data, QuickSortAL.PivotType.AlwaysLast);
            Thread thread = new Thread(() => Clipboard.SetText(ComparisonsCount.ToString()));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();

            Console.ReadKey();
        }
    }
}
