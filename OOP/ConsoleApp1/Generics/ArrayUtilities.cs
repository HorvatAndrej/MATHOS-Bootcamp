using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public static class ArrayUtilities
    {
 public static int FindLargestIndex<T>(T[] array) where T : IComparable<T>
    {
         int largest = 0;
         for (int i = 1; i < array.Length; i++)
             {
             if (array[i].CompareTo(array[largest]) == 1)
                 {
                 largest = i;
                 }
             }
         return largest;
    }
 }

}
