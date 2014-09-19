using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sort_Methods.App_Code
{
    class MergeSort
    {
        public String mergeSortTime(FileClass insFile, bool order, bool execution)
        {
            List<String> lstCitizens = FileClass.lstCitizens;

            var clock = Stopwatch.StartNew();
            if (execution)
            {
                sequentialMergesort(lstCitizens, 0, lstCitizens.Count - 1, order);
            }
            else
            {
                parallelMergesort(lstCitizens, 0, lstCitizens.Count - 1, Environment.ProcessorCount, order);
            }
            clock.Stop();

            insFile.saveFile(lstCitizens);

            return Convert.ToString(clock.ElapsedMilliseconds) + " ms";
        }

        private void sequentialMergesort(List<String> vector, int left, int right, bool order)
        {
            if (left < right)
            {
                int pivot = (right + left) / 2;
                sequentialMergesort(vector, left, pivot, order);
                sequentialMergesort(vector, pivot + 1, right, order);
                mergeVector(vector, left, pivot, right, order);
            }
        }

        private void parallelMergesort(List<String> vector, int left, int right, int cores, bool order)
        {
            if (left < right)
            {
                int pivot = (right + left) / 2;
                if (cores > 0)
                {
                    Parallel.Invoke(
                    () => parallelMergesort(vector, left, pivot, cores - 1, order),
                    () => parallelMergesort(vector, pivot + 1, right, cores - 1, order));
                }
                else 
                {
                    parallelMergesort(vector, left, pivot, cores - 1, order);
                    parallelMergesort(vector, pivot + 1, right, cores - 1, order);
                }
                
                mergeVector(vector, left, pivot, right, order);
            }
        }


        /* Procedure for merging two sorted array. 
        *Note that both array are part of single array. arr1[start.....mid] and arr2[mid+1 ... end]*/
        private void mergeVector(List<String> vector, int left,int pivot, int right, bool order)
        {
            /* Create a temporary array for stroing merged array (Length of temp array will be 
             * sum of size of both array to be merged)*/

            List<String> temp = new List<String>();
            int i = left;
            int j = pivot + 1;
            int k = 0;

            // Now traverse both array simultaniously and store the smallest element of both to temp array
            while (i <= pivot && j <= right)
            {
                if (order)
                {
                    if (getProvince(vector[i]).CompareTo(getProvince(vector[j])) < 0)
                    {
                        temp.Add(vector[i]);
                        i++;
                    }
                    else
                    {
                        temp.Add(vector[j]);
                        j++;
                    }
                }
                else 
                {
                    if (getProvince(vector[i]).CompareTo(getProvince(vector[j])) > 0)
                    {
                        temp.Add(vector[i]);
                        i++;
                    }
                    else
                    {
                        temp.Add(vector[j]);
                        j++;
                    }
                }
                
            }
            // If there is any element remain in first array then add it to temp array
            while(i <= pivot)
            {
                temp.Add(vector[i]);
                i++;
            }

            // If any element remain in second array then add it to temp array
            while (j <= right)
            {
                temp.Add(vector[j]);
                j++;
            }
 
            i=left;
            while (k < temp.Count && i <= right)
            {
                vector[i] = temp[k];
                i++;
                k++;
            }
        }

        private String getProvince(String line)
        {
            String[] values = line.Split(',');
            return values[1];
        }
    }
}
