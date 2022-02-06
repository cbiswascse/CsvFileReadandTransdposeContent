using System;

namespace CsvFileReadAndTranspose
{
    public class Transpose
    {
        /// <summary>
        /// Method for Transposing the data of the file.
        /// </summary>
        /// <param name="readContent">The content of the file.</param>
        /// <returns>The array of transposed data.</returns>
        public string[,] TransposeData(string readContent)
        {
            string[] lines = readContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] words = lines[0].Split(new string[] { ";" }, StringSplitOptions.None);

            //Initializing the height and width of a new 2-D array.
            int row = (words.Length) - 1;
            int column = (lines.Length) - 1;

            //Initializing the array to store with transposed data.
            string[,] comboined = new string[row, column];
            try
            {
                //Iteration through the array "lines"
                for (int i = 0; i < column; i++)
                {
                    words = lines[i].Split(new string[] { ";" }, StringSplitOptions.None);
                    int row_count = words.Length;
                    // Iteration through the array "words" to get all the row values of the array "lines".
                    for (int j = 0; j < row_count - 1; j++)
                    {
                        comboined[j, i] = words[j] + ";";
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"The length of the all columns are not equal: '{e}'");
                throw;
            }
            return comboined;
        }
    }
}
