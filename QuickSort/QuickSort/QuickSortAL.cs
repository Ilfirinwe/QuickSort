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
            return SortAndCountComparisons(Data, 0, Data.Length - 1);
        }

        private static Int64 SortAndCountComparisons(Int32[] Data, Int32 StartIndex, Int32 EndIndex)
        {
            if (StartIndex >= EndIndex) return 0;
            Int32 Pivot = ChoosePivot(Data, StartIndex, EndIndex);
            Swap(Data, Pivot, StartIndex);
            Int32 LeftBoundary = StartIndex + 1;
            Int32 RightBoundary;
            for (RightBoundary = StartIndex + 1; RightBoundary <= EndIndex; RightBoundary++)
            {
                if (Data[RightBoundary] < Data[StartIndex])
                {
                    Swap(Data, LeftBoundary, RightBoundary);
                    LeftBoundary++;
                }
            }
            Swap(Data, StartIndex, LeftBoundary - 1);
            Int64 LeftComparisons = SortAndCountComparisons(Data, StartIndex, LeftBoundary - 2);
            Int64 RightComparisons = SortAndCountComparisons(Data, LeftBoundary, EndIndex);

            Int64 ComparisonsCount = EndIndex - StartIndex + RightComparisons + LeftComparisons;
            
            return ComparisonsCount;
        }

        private static Int32 ChoosePivot(Int32[] Data, Int32 StartIndex, Int32 EndIndex)
        {
            if (PivotSettings == PivotType.AlwaysFirst)
                return StartIndex;
            else if (PivotSettings == PivotType.AlwaysLast)
                return EndIndex;
            else
            {
                Int32 Length = EndIndex - StartIndex;
                Int32 MiddleIndex = StartIndex + Length / 2;
                if (Math.Max(Math.Max(Data[StartIndex], Data[MiddleIndex]), Data[EndIndex]) != Data[StartIndex]
                    && Math.Min(Math.Min(Data[StartIndex], Data[MiddleIndex]), Data[EndIndex]) != Data[StartIndex])
                    return StartIndex;

                else if (Math.Max(Math.Max(Data[StartIndex], Data[MiddleIndex]), Data[EndIndex]) != Data[MiddleIndex]
                    && Math.Min(Math.Min(Data[StartIndex], Data[MiddleIndex]), Data[EndIndex]) != Data[MiddleIndex])
                    return MiddleIndex;
                else return EndIndex;
            }
        }

        private static void Swap(Int32[] Data, Int32 FirstIndex, Int32 SecondIndex)
        {
            Int32 Interchange = Data[FirstIndex];
            Data[FirstIndex] = Data[SecondIndex];
            Data[SecondIndex] = Interchange;
        }
    }
}
