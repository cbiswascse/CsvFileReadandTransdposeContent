using System;
using System.IO;

namespace CsvFileReadAndTranspose
{
    /// <summary>
    /// Class for reading and writing the data of the file  
    /// </summary>
    public class FileOperation
    {
        /// <summary>
        /// Method for getting the path of the file.
        /// </summary>
        /// <param name="dirPath">The directory of the file.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <return>The path of the file.</return> 
        public string GetPath(string dirPath, string fileName)
        {            
            string filePath = dirPath + "\\" + fileName;             
            return filePath; 
        }

        /// <summary>
        /// Method to read the file content.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <return>Content of the file.</return> 
        public string ReadFile(string filePath)
        {
            string content = "";

            try
            {
                content = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
 
            return content;
        }

        /// <summary>
        /// Method to get the path of a new file name with the extention "_Transposed". 
        /// </summary>
        /// <param name = "filePath">The path of the file.</param>
        /// <returns> A new path for the new file.</returns>
        public string FilePathToSave(string filePath)
        {
            string transposedPath;
            string removedCsv = "";

            foreach (char word in filePath)
            {
                if (word == '.')
                {
                    break;
                }
                else
                {
                    removedCsv = removedCsv + word;
                }
            }
            //Generating the path of the new file.
            transposedPath = removedCsv + "_Transposed.csv";
            return transposedPath;
        }

        /// <summary>
        /// Method to save the Transposed the data in a new file.
        /// </summary>
        /// <param name="transposedFileName">A new path for the new file.</param>
        /// <param name="transposedData">The array of transposed data.</param>
        public void SaveTransposedContent(string transposedFileName,string[,] transposedData)
        {        
            //Getting the height and width of the array argument.
            int row = transposedData.GetLength(0);
            int column = transposedData.GetLength(1);
            string contentToSave = "";

            //Iteration through the array.
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    contentToSave = contentToSave + transposedData[i, j];
                }
                contentToSave = contentToSave + Environment.NewLine;
            }
            File.WriteAllText(transposedFileName, contentToSave);
        }
    }
}
