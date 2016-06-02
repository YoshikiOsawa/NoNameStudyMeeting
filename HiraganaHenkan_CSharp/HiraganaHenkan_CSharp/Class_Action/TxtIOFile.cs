using System.IO;
using System.Text;

public class TxtIOFile
{
    public string readTxtFile(string fileName)
    {
        StreamReader streamReader = new StreamReader(fileName, Encoding.GetEncoding("Shift_JIS"));
        var srText = streamReader.ReadToEnd();
        streamReader.Close();

        return srText;
    }

    public void writeTxtFile(string filePass, string writeText)
    {
        Encoding sjisString = Encoding.GetEncoding("Shift-JIS");
        StreamWriter streamWriter = new StreamWriter(filePass, true, sjisString);
        streamWriter.WriteLine(writeText);
        streamWriter.Close();
    }

}
