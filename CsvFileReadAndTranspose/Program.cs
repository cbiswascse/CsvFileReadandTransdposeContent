using System;

namespace CsvFileReadAndTranspose
{
    class Program
    {
        public static void Main(string[] args)
        {
            /// Creating an object of FileOperation class.
            FileOperation fileOperation = new FileOperation();

            Console.WriteLine("Please enter the location of the file.");
            string dirPath = "" + Console.ReadLine();
            Console.WriteLine("Please Enter the file name.");
            string fileName = Console.ReadLine();

            string getFilePath = fileOperation.GetPath(dirPath,fileName);

            string readContent = fileOperation.ReadFile(getFilePath);

            /// Creating an object of Transposed class.
            Transpose transpose = new Transpose();

            string[,] transposedData = transpose.TransposeData(readContent);

            string transposedFileName = fileOperation.FilePathToSave(getFilePath);

            fileOperation.SaveTransposedContent(transposedFileName,transposedData);
        }
    }
}
