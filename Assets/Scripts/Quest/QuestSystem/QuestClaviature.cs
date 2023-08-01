public class QuestClaviature
{
    string infoQuest="Заменяет каждую анлийскую букву на русскую, расположенную с ней на одной клавише или на месторасположение этой клавиши на клавиатуре (ряд и порядковый номер в ряду).";
    string result ="";
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
        result = "";
        var count = SearchOption(name);
        foreach (var item in count)
        {
            result +=info.GetENGChar()[item];
        }
        return result;
    }
    public string ClaviatureNum(string name)
    {
        result = "";
        var count = SearchOption(name);
        foreach (var item in count)
        {
            int num = 0;
            for (int k = 0; k < info.GetNum().Length; k++)
            {
                int n = item-(info.GetNum()[k].Length);
                num +=info.GetNum()[k].Length;
                if (k!=0)
                {
                    n = item-(num);
                }
                if(n<=0)//19-(12+11)=-4
                {
                    result+=info.GetNum()[k][((info.GetNum()[k].Length+n))]+" ";//11-3-1=7
                    break;
                }
            }
        }
        return result;
    }
}