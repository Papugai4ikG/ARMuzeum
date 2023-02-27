
using System;
public class QuestWordNumber  
{
    string result;
    int[] lengthName;

    public string GetWordNumber(string name)
    {
        lengthName = new int[name.Length];
        Random random = new Random();
        for (int i=0;i<lengthName.Length;i++)
        {
            lengthName[i]=random.Next(0,2);
            switch (lengthName[i])
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