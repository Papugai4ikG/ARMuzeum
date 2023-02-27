public class QuestClaviature
{
    string infoQuest="Заменяет каждую русскую букву на английскую, расположенную с ней на одной клавише или на месторасположение этой клавиши на клавиатуре (ряд и порядковый номер в ряду).";
    string result;
    InfoClaviature info = new InfoClaviature();

    public string InfoQuest { get => infoQuest; }

    int[] SearchOption(string name)
    {
        int[] count = new int[name.Length];
        for (int i = 0; i < count.Length; i++)
        {
            for (int k = 0; k < info.GetChar().Length; k++)
            {
                if(name[i] == info.GetChar()[k])
                {
                    count[i] = k;
                    break;
                }
            }
        }
        return count;
    }
    public string ClaviatureENG(string name)
    {
        var count = SearchOption(name);
        foreach (var item in count)
        {
            result +=info.GetENGChar()[item];
        }
        return result;
    }
    public string ClaviatureNum(string name)
    {
        var count = SearchOption(name);
        foreach (var item in count)
        {
            var num=0;
            for (int k = 0; k < info.GetNum().Length; k++)
            {
                if(item-(info.GetNum()[k].Length+num)<0)
                {
                    result+=info.GetNum()[k][item-(num+k)]+" ";//19-11+1=7
                    break;
                }else
                {
                    num+=info.GetNum()[k].Length-1;
                }
            }
        }
        return result;
    }
}