using System.ComponentModel.DataAnnotations;
using System;

public class QuestBrouler
{
    string infoQuest= "Cпособ знакового кодирования, в котором буквы алфавита, цифры, знаки препинания и другие символы представляются в виде последовательностей коротких и длинных сигналов, называемых точками и тире[1]";
    string result ="";
    InfoMorse morse = new InfoMorse();
    public string GetMorze(string name)
    {
        result ="";
        foreach (var item in name)
        {
            result+=morse.getMorse()[item.ToString()].ToString()+"|";
        }
        return result;
    }
    public string GetinfoQuest { get => infoQuest; }
}
