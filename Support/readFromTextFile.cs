namespace NewReqnrolTestFRamework.Support
{
    public class readFromTextFile
    {
        public static string ReadFileData(string path) =>
            File.ReadAllText(path);

        public static string FromTextFile()
        {
            return File.ReadAllText("C:\\Users\\joeea\\OneDrive\\Desktop\\NewReqnrolTestFRamework\\Support\\Testdata\\TestEnviromentData.txt");
        }
    }
}
