using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sort_Methods.App_Code
{
    class FileClass
    {
        public List<string> lstProvinces = new List<string>();
        public static List<string> lstCitizens = new List<string>();

        public void loadFile()
        {
            String[] fileName;
            String[] filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Archivos txt|*.txt";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Cargar Archivo";
            openFileDialog.ShowDialog();

            filePath = openFileDialog.FileNames;
            fileName = openFileDialog.SafeFileNames;
            
            if (fileName.Length > 0)
            {
                StreamReader strBuffer; 
                string rowText;
                
                for(int i=0; i < filePath.Length; i++) 
                {
                    strBuffer = new StreamReader(filePath[i], Encoding.UTF8);
                    while ((rowText = strBuffer.ReadLine()) != null)
                    {
                        if (fileName[i].Equals("Distelec.txt"))
                            lstProvinces.Add(rowText);
                        else if (fileName[i].Equals("PADRON_COMPLETO.txt"))
                            lstCitizens.Add(rowText);
                    }
                    strBuffer.Close();
                }
            }
        }

        /// <summary>
        /// Guarda archivos de texto en el explorador
        /// </summary>
        /// <param name="_sTexto">texto que se va a guardar en el archivo</param>
        public void saveFile(List<String> lstResult)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos txt|*.txt";
            saveFileDialog.Title = "Guardar Archivo";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                StringBuilder text = new StringBuilder();
                try
                {
                    for (int i = 0; i < lstResult.Count; i++)
                    {
                        text.AppendLine(lstResult[i]);
                    }

                    StreamWriter sw = new StreamWriter(saveFileDialog.OpenFile());
                    sw.WriteLine(text);
                    sw.Close();
                }
                catch (Exception e) { }
            }
        }
    }
}
