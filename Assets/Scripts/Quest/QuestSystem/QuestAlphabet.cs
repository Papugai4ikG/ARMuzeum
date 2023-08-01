
public class QuestAlphabet
{
    string infoQuest = "Заменяет буквы алфавита их порядковыми номерами: А - 1, Б - 2, В - 3 и так далее.";
    string result = "";
    InfoAlphabet info = new InfoAlphabet();

    public string InfoQuest { get => infoQuest;}

    public string alphabetNum(string name)
    {
      result = "";
      for (int i = 0; i < name.Length; i++)
        {
            for (int k = 0; k < info.GetChars().Length; k++)
            {
                if(name[i] == info.GetChars()[k])
                {
                    result += (k+1)+" ";
                    break;
                }
            }
        }
        return result;
    }
}