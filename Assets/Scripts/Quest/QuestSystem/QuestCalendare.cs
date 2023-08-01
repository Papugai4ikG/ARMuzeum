using System.Globalization;
using System;

public class QuestCalendare 
{
    string infoQuest="Заменяет каждую букву текста на день недели какого-либо месяца, согласно порядковому номеру этой буквы в алфавите. Соответствующий месяц в году и является ключом к ответу.";
    string result = "";
    int count =0;
    InfoAlphabet info = new InfoAlphabet();

    public string InfoQuest { get => infoQuest; }

    public string GetCalendare(string name) 
    {
        result = "";
        DateTime date = DateTime.Now;
        DateTime date2 = new DateTime(date.Year,date.Month,date.Day);
        int dateCount = DateTime.DaysInMonth(date.Year,date.Month);
        for (int i = 0; i < name.Length; i++)
        {
            for (int k = 0; k < info.GetChars().Length; k++)
            {
                if(name[i] == info.GetChars()[k])
                {
                    if((k+1)>dateCount)
                    {
                        date2 = new DateTime(date.Year,date.Month+1,(k+1)-dateCount);
                    }
                    else
                    {
                        date2 = new DateTime(date.Year,date.Month,k+1);
                    }
                        int first = (int)new DateTime(date2.Year,1, 1).DayOfWeek;
                        var one = Math.Round((date2.DayOfYear + first) / 7.0);
                        var duo = (new DateTime(date.Year,date.Month,1).DayOfYear+first)/7;
                        count=(int)one-duo;
                    result+=string.Format("{2}.{0:ddd}-{1} ",
                        date2,count,(i+1),
                        CultureInfo.CreateSpecificCulture("ru-RU"));
                    break;
                }
            }
        }
        return result;
    }
}