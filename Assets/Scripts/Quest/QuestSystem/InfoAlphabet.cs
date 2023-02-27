public class InfoAlphabet
{
    private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    char[]alphabetChar = new char[33];
    public InfoAlphabet()
    {
        alphabetChar = alphabet.ToCharArray();
    }

    public char[] GetChars()=>alphabetChar;
}