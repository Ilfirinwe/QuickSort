using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public static class QuickSortAL
    {
        private static PivotType PivotSettings;
        public enum PivotType
        {
            AlwaysFirst,
            AlwaysLast,
            MedianOfThree
        }
        public static Int64 SortAndCountComparisons(Int32[] Data, PivotType PivotSetting)
        {
            PivotSettings = PivotSetting;
            return SortAndCountComparisons(Data, 0, Data.Length);
        }

        private static Int64 SortAndCountComparisons(Int32[] Data, Int32 StartingIndex, Int32 Length)
        {
            if (Length <= 1) return 0;
            Int32 Pivot = ChoosePivot(Data, StartingIndex, Length);
            Console.WriteLine("Pivot index = " + Pivot);
            Swap(Data, Pivot, StartingIndex);
            Int32 RightBoundary = StartingIndex + 1;
            Int32 LeftBoundary = StartingIndex + 1;
            for (RightBoundary = StartingIndex + 1; RightBoundary < StartingIndex + Length; RightBoundary++)
            {
                if (Data[RightBoundary] < Data[Pivot])
                {
                    Swap(Data, LeftBoundary, RightBoundary);
                    LeftBoundary++;
                }
                if (LeftBoundary == Pivot)
                {
                    LeftBoundary++;
                }
            }
            Swap(Data, Pivot, LeftBoundary - 1);

            Int32 LeftSubArrayLength = LeftBoundary - StartingIndex - 1;
            Int64 LeftComparisons = 0;

            if (LeftSubArrayLength > 0) LeftComparisons = SortAndCountComparisons(Data, StartingIndex, LeftSubArrayLength);

            Int32 RightSubArrayLength = RightBoundary - LeftBoundary;
            Int64 RightComparisons = 0;

            if (RightSubArrayLength > 0) RightComparisons = SortAndCountComparisons(Data, LeftBoundary, RightSubArrayLength);

            Int64 ComparisonsCount = Length - 1 + RightComparisons + LeftComparisons;

            Console.WriteLine("Количество сравнений на массиве данных со стартовым индексом " + StartingIndex + " и длиной " + Length + ": " + ComparisonsCount);
            return ComparisonsCount;
        }

        private static Int32 ChoosePivot(Int32[] Data, Int32 StartingIndex, Int32 Length)
        {
            if (PivotSettings == PivotType.AlwaysFirst)
                return StartingIndex;
            else if (PivotSettings == PivotType.AlwaysLast)
                return StartingIndex + Length - 1;
            else return StartingIndex;
        }

        private static void Swap(Int32[] Data, Int32 FirstIndex, Int32 SecondIndex)
        {
            Int32 Interchange = Data[FirstIndex];
            Data[FirstIndex] = Data[SecondIndex];
            Data[SecondIndex] = Interchange;
        }
    }
}
