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
        /// <summary>
        /// Funcion principal, la cual se encarga de tomar el tiempo de ejecucion de los 
        /// metodos paralelo y secuencial
        /// </summary>
        /// <param name="insFile">Instancia de la clase de archivos</param>
        /// <param name="order">Orden en que se va ordenar el vector</param>
        /// <param name="execution">Indica si la ejecución va a ser de forma paralela o secuencial</param>
        /// <returns>Retorna el tiempo de ejecución</returns>
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

        /// <summary>
        /// Función secuencial del metodo MergeSort
        /// </summary>
        /// <param name="vector">Vector de datos que se quiere ordenar</param>
        /// <param name="left">Inicio del vector</param>
        /// <param name="right">Final del vector</param>
        /// <param name="order">Orden en que se va ordenar el vector</param>
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
        
        /// <summary>
        /// Función paralela del metodo MergeSort
        /// </summary>
        /// <param name="vector">Vector de datos que se quiere ordenar</param>
        /// <param name="left">Inicio del vector</param>
        /// <param name="right">Final del vector</param>
        /// <param name="cores">Cantidad de nucleos de la computadora</param>
        /// <param name="order">Orden en que se va ordenar el vector</param>
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

        /// <summary>
        /// Función encargada de unir los vectores de forma que los elementos queden ordenados
        /// </summary>
        /// <param name="vector">Vector de datos que se quiere ordenar</param>
        /// <param name="left">Inicio del vector</param>
        /// <param name="pivot">Centro del vector</param>
        /// <param name="right">Final del vector</param>
        /// <param name="order">Orden en que se va ordenar el vector</param>
        private void mergeVector(List<String> vector, int left,int pivot, int right, bool order)
        {
            List<String> temp = new List<String>();
            int i = left;
            int j = pivot + 1;
            int k = 0;

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

            while(i <= pivot)
            {
                temp.Add(vector[i]);
                i++;
            }

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
