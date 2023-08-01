
public class QuestCode
{
    QuestBrouler morse = new QuestBrouler();
    //
    QuestAlphabet questAlphabet=new QuestAlphabet();
    //
    QuestClaviature questClaviature= new QuestClaviature();
    //
    QuestCalendare questCalendare = new QuestCalendare();
    //
    QuestCaesar questCaesar = new QuestCaesar();

    public QuestAlphabet QuestAlphabet { get => questAlphabet; }
    public QuestClaviature QuestClaviature { get => questClaviature; }
    public QuestCalendare QuestCalendare { get => questCalendare; }
    public QuestCaesar QuestCaesar { get => questCaesar; }
    public QuestBrouler QuestBrouler{get=>morse;}
}