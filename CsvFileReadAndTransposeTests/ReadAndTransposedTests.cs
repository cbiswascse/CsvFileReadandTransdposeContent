using System;
using Xunit;
using CsvFileReadAndTranspose;

namespace CsvFileReadAndTransposeTests
{
    /// <summary>
    /// Test class to test the components of CsvFileReadAndTranspose
    /// </summary>
    public class ReadAndTransposedTests
    {
        FileOperation fileOperation = new FileOperation();
        Transpose transpose = new Transpose();

        /// <summary>
        /// Test case to test the located file directory is created properly.
        /// </summary>
        [Fact]
        public void GetPathShouldReturnCorrectPath()
        {
            //Arrange
            string dirPath = "D:\\TestCsvProject";
            string fileName = "TestInputFile.csv";

            //Act
            string expected = "D:\\TestCsvProject\\TestInputFile.csv";
            string actual = fileOperation.GetPath(dirPath, fileName);

            //Assert
            Assert.Equal(expected,actual);
        }

        /// <summary>
        /// Test class to test the "ReadFile" method can read all the data inside the file.
        /// </summary
        [Fact]
        public void ReadFileShouldReturnContents()
        {
            //Arrange
            string filePath = "D:\\TestCsvProject\\TestInputFile.csv";
            //Known data in the file.
            string expected = "1;"+"2;"+"3;"+ "4;"+"5;"+"6;"+"7;"+"8;"+"\r\n"+
                              "B;"+ "B;"+"B;"+"B;"+"B;"+ "B;"+ "B;"+ "B;" +"\r\n"                              
                              ;

            //Act
            string actual = fileOperation.ReadFile(filePath);

            //Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Test class to test the data in the file are transposed properly.
        /// </summary
        [Fact]
        public void TransposedShouldReturnTwoDArray()
        {
            //Arrange
            string filePath = "D:\\TestCsvProject\\TestInputFile.csv";
            //Known data in the file.
            string[,] expected = new string[1, 2]{
                                {"1;","B;"}
                                };
            //Intialize a array with expected legth of the output.
            string[,] expectedLength = new string[8, 2];

            //Act            
            string readContent = fileOperation.ReadFile(filePath);
            string[,] actual = transpose.TransposeData(readContent);
                        
            //Assert
            //Testing the expected output data and actual output data are equal.
            Assert.Equal(expected[0,0],actual[0,0]);

            //Testing the Length of expected output data and actual output data are equal.
            Assert.Equal(expectedLength.Length, actual.Length);
        }

        /// <summary>
        /// Test case to test the new file is created with 
        /// the same input file name with additional "_Transposed".
        /// </summary>
        [Fact]
        public void FilePathToSaveShouldReturnCorrectPath()
        {
            //Arrange
            string filePath = "D:\\TestCsvProject\\TestInputFile.csv";

            //Act
            String expected = "D:\\TestCsvProject\\TestInputFile_Transposed.csv";
            String actual = fileOperation.FilePathToSave(filePath);

            //Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Test class to test the transposed data are Saving correctly to the new file.
        /// </summary>
        [Fact]
        public void SaveTransposedContentShouldSaveContent()
        {
            //Arrange.
            string filePath = "D:\\TestCsvProject\\test.csv";

            //Intialize an array with some data to save in a file.
            string[,] contentToSave = new string[5, 2]{
                                {"Fruit:","Vagetables:"},{"Orange","Pumpkin"},
                                {"Banana","Tomato" },{"Grape","Cabage"},
                                {"Apple","Carrots"}
                                };

            string expected = "Fruit:" + "Vagetables:" + "\r\n" + "Orange" + "Pumpkin" + "\r\n" +
                              "Banana" + "Tomato" + "\r\n" + "Grape" + "Cabage" + "\r\n" +
                                "Apple" + "Carrots" + "\r\n";
            //Act            
            fileOperation.SaveTransposedContent(filePath, contentToSave);
            //Read the content from the file.
            string actual = fileOperation.ReadFile(filePath);

            //Assert
            //Testing the expected data and the output data after writing into the file are equal.
            Assert.Equal(expected, actual);
        }

    }
}
