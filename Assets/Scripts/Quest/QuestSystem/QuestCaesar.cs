using System;
public class QuestCaesar
{
    string infoQuest="Каждую букву текста заменяет на другую букву, находящуюся правее от неё на некотором числе позиций в алфавите. Количество таких позиций (сдвигов=5) является ключом к шифру. Например, при ключе 1 буква А становится буквой Б, а буква Б - буквой В, и так далее.";
    string result;
    InfoAlphabet alphabet = new InfoAlphabet();

    public string InfoQuest { get => infoQuest; }

    public string getCaesar(string name)
    {
        int shift = 5;
        var count =0;
        for (int i = 0; i < name.Length; i++)
        {
            for (int k = 0; k < alphabet.GetChars().Length; k++)
            {
                if(name[i] == alphabet.GetChars()[k])
                {
                    if(k+shift>alphabet.GetChars().Length-1)
                    {
                        count=(k-alphabet.GetChars().Length)+shift;
                    }else
                    {
                        count=(k+shift);
                    }
                    result +=alphabet.GetChars()[count];
                    break;
                }
            }
        }
        return result;
    }
}