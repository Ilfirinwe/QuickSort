using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace QuickSort.Tests
{
    [TestClass]
    public class Pivot_First
    {
        [TestMethod]
        public void First_ElementsCount_10()
        {
            #region ARRANGE
            var Data = new Int32[10];
            using (var Reader = new StreamReader("Data.txt"))
                for (Int32 Iterator = 0; Iterator < 10; Iterator++)
                    Data[Iterator] = Int32.Parse(Reader.ReadLine());
            #endregion

            #region ACT
            Int64 ComparisonsCount = QuickSortAL.SortAndCountComparisons(Data, QuickSortAL.PivotType.AlwaysFirst);
            #endregion

            #region ASSERT
            Assert.AreEqual(ComparisonsCount, 25);
            #endregion
        }
        [TestMethod]
        public void First_ElementsCount_100()
        {
            #region ARRANGE
            var Data = new Int32[100];
            using (var Reader = new StreamReader("Data.txt"))
                for (Int32 Iterator = 0; Iterator < 100; Iterator++)
                    Data[Iterator] = Int32.Parse(Reader.ReadLine());
            #endregion

            #region ACT
            Int64 ComparisonsCount = QuickSortAL.SortAndCountComparisons(Data, QuickSortAL.PivotType.AlwaysFirst);
            #endregion

            #region ASSERT
            Assert.AreEqual(ComparisonsCount, 620);
            #endregion
        }
        [TestMethod]
        public void First_ElementsCount_1000()
        {
            #region ARRANGE
            var Data = new Int32[1000];
            using (var Reader = new StreamReader("Data.txt"))
                for (Int32 Iterator = 0; Iterator < 1000; Iterator++)
                    Data[Iterator] = Int32.Parse(Reader.ReadLine());
            #endregion

            #region ACT
            Int64 ComparisonsCount = QuickSortAL.SortAndCountComparisons(Data, QuickSortAL.PivotType.AlwaysFirst);
            #endregion

            #region ASSERT
            Assert.AreEqual(ComparisonsCount, 11175);
            #endregion
        }
    }
}
