
using System;
public class QuestWordNumber  
{
    string result = "";
    int[] lengthName;

    public string GetWordNumber(string name)
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
                result+=random.Next(0,100)+""+name[i];
                break;
            }
        }
        return result;
    }
}