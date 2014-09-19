using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Sort_Methods.App_Code
{
    class QuickSort
    {
        public String quickSortTime(FileClass insFile, bool order, bool execution) 
        {
            List<String> lstCitizens = FileClass.lstCitizens;
            var clock = Stopwatch.StartNew();
            if (execution)
            {
                sequentialQuicksort(lstCitizens, 0, lstCitizens.Count - 1, order);
            }
            else 
            {
                parallelQuicksort(lstCitizens, 0, lstCitizens.Count - 1, Environment.ProcessorCount, order);
            }
            clock.Stop();

            insFile.saveFile(lstCitizens);
            return Convert.ToString(clock.ElapsedMilliseconds)+" ms";
        }

        private void sequentialQuicksort(List<String> vector, int left, int right, bool order)
        {
            int i = left;
            int j = right;
            String pivot = vector[(left + right) / 2];

            while (i <= j)
            {
                if (order)
                {
                    while (getProvince(vector[i]).CompareTo(getProvince(pivot)) < 0)
                    {
                        i++;
                    }

                    while (getProvince(vector[j]).CompareTo(getProvince(pivot)) > 0)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        String tmp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = tmp;
                        i++;
                        j--;
                    }
                }
                else 
                {
                    while (getProvince(vector[i]).CompareTo(getProvince(pivot)) > 0)
                    {
                        i++;
                    }

                    while (getProvince(vector[j]).CompareTo(getProvince(pivot)) < 0)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        String tmp = vector[j];
                        vector[j] = vector[i];
                        vector[i] = tmp;
                        i++;
                        j--;
                    }
                }
            }

            if (left < j)
            {
                sequentialQuicksort(vector, left, j, order);
            }

            if (i < right)
            {
                sequentialQuicksort(vector, i, right, order);
            }
        }

        private void parallelQuicksort(List<String> vector, int left, int right, int cores, bool order)
        {
            int i = left;
            int j = right;
            String pivot = vector[(left + right) / 2];

            while (i <= j)
            {
                if (order)
                {
                    while (getProvince(vector[i]).CompareTo(getProvince(pivot)) < 0)
                    {
                        i++;
                    }

                    while (getProvince(vector[j]).CompareTo(getProvince(pivot)) > 0)
                    {
                        j--;
                    }
                     
                    if (i <= j)
                    {
                        String tmp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = tmp;
                        i++;
                        j--;
                    }
                }
                else
                {
                    while (getProvince(vector[i]).CompareTo(getProvince(pivot)) > 0)
                    {
                        i++;
                    }

                    while (getProvince(vector[j]).CompareTo(getProvince(pivot)) < 0)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        String tmp = vector[j];
                        vector[j] = vector[i];
                        vector[i] = tmp;
                        i++;
                        j--;
                    }
                }
            }
            
            if (cores > 0)
            {
                Parallel.Invoke(
                    () => parallelQuicksort(vector, left, j, cores - 1, order),
                    () => parallelQuicksort(vector, i, right, cores - 1, order));
            }
            else
            {
                if (left < j)
                    parallelQuicksort(vector, left, j, 0, order);
                if (i < right)
                    parallelQuicksort(vector, i, right, 0, order);
            }
        }

        private String getProvince(String line) 
        {
            String[] values = line.Split(',');
            return values[1];
        }
    }
}
