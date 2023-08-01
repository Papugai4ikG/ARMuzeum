
public class InfoClaviature{
    private string alphabetKlav = "йцукенгшщзхъфывапролджэячсмитьбю";
    private string alphabetENG = "qwertyuiop[]asdfghjkl;'zxcvbnm,.";
    private string[][] alphabetNum = new string[3][];
    private char[] alphabetChar = new char[32];
    private char[] alphabetENGChar = new char[32];

    public InfoClaviature()
    {
        alphabetChar = alphabetKlav.ToCharArray();
        alphabetENGChar = alphabetENG.ToCharArray();
        alphabetNum[0] = new string[12];
        alphabetNum[1] = new string[11];
        alphabetNum[2] = new string[9];
        for (int i = 0; i < alphabetNum.Length; i++)
        {
            for (int k = 0; k < alphabetNum[i].Length; k++)
            {
                alphabetNum[i][k] = (i+1)+"-"+(k+1);
            }
        }
    }
    public string[][] GetNum()=>alphabetNum;
    public char[] GetChar()=>alphabetChar;
    public char[] GetENGChar()=>alphabetENGChar;
}