using System;
public class QuestWordAlphabet {
    InfoAlphabet infoAlphabet = new InfoAlphabet();
    string result = "";
    int[] lengthName;

    public string GetWordAlphabet(string name)
    {
        result = "";
        Random random = new Random();
        for (int i=0;i<name.Length;i++)
        {
            switch (random.Next(0,2))
            {
                case 0 :
                result+=name[i];
                break;
                case 1 :
                result+=infoAlphabet.GetChars()[random.Next(0,infoAlphabet.GetChars().Length)].ToString().ToUpper()+""+name[i];
                break;
            }
        }
        return result;
    }
}