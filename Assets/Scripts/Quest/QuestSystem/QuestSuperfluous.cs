using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSuperfluous : MonoBehaviour
{
    string InfoQuest = "В этом задании в текст вставляются лишние символы (значки, цифры, английские буквы, заглавные буквы)";
    QuestWordNumber questWordNumber = new QuestWordNumber();
    QuestWordAlphabet questWordAlphabet = new QuestWordAlphabet();

    public QuestWordNumber QuestWordNumber { get => questWordNumber;}
    public QuestWordAlphabet QuestWordAlphabet { get => questWordAlphabet;}
    public string GetinfoQuest { get => InfoQuest; }
}
