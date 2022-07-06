using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Extentions
{
    internal static class ObservableCollectionExtentions
    {
        public static void AddRange<T>(this ObservableCollection<T> thisCollection, IList<T> toAddCollection)
        {
            foreach (var item in toAddCollection)
                thisCollection.Add(item);
        }
        public static void RemoveRange<T>(this ObservableCollection<T> thisCollection, Func<T, bool> condition)
        {
            for (int i = thisCollection.Count - 1; i >= 0; i--)
            {
                if (condition(thisCollection[i]))
                {
                    thisCollection.RemoveAt(i);
                }
            }
        }
    }
}
