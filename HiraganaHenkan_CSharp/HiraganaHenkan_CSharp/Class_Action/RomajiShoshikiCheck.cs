using System.Text.RegularExpressions;

public class RomajiShoshikiCheck
{
    private const string errorMessageShoshiki = "ローマ字を{0}";

    public string ShoshikiCheck(string text)
    {
        var messageText = string.Empty;

        var message = new Message();

        if (string.IsNullOrWhiteSpace(text))
        {
            messageText = string.Format(errorMessageShoshiki, message.minyuuryokuError);
        }
        else if (Regex.IsMatch(text, @"^[A-Z0-9]+$"))
        {
            messageText = string.Format(errorMessageShoshiki, message.notHankakuEisuuError);
        }

        return messageText;
    }

}
