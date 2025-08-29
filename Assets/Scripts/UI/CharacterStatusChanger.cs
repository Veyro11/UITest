using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Data;

class CharacterStatusChanger : MonoBehaviour
{
    [SerializeField] private CharacterStatusComponent Character;

    private void Start()
    {
        Initiation();
    }
    private void OnEnable()
    {
        WriteStatus();
    }
    public void Initiation()
    {
        if (Character != null)
        {
            TextEditor.Instance.ChangeText(transform.GetChild(0).GetComponent<TextMeshPro>(), 
                $"{Character.name}\n<size=8> </size>\n<size=85>LV {Character.GetStatus(StatType.Level)}/300</size>");
            WriteStatus();
        }
    }
    
    public void WriteStatus()
    {
        if (Character != null)
        {
            //level
            TextEditor.Instance.ChangeSlashText(transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.Exp).Basic,Character.GetStatus(StatType.NextExp).Basic);
            transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(300 * ((float)Character.GetStatus(StatType.Exp).Basic / Character.GetStatus(StatType.NextExp).Basic), 10);
            //HP, MP
            transform.GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(300 * ((float)Character.GetStatus(StatType.HP).Basic / Character.GetStatus(StatType.MAXHP).Basic), 40);
            TextEditor.Instance.ChangeSlashText(transform.GetChild(1).GetChild(2).GetChild(0).GetChild(1).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.HP).Basic, Character.GetStatus(StatType.MAXHP).Basic);
            transform.GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(300 * ((float)Character.GetStatus(StatType.HP).Basic / Character.GetStatus(StatType.MAXHP).Basic), 40);
            TextEditor.Instance.ChangeSlashText(transform.GetChild(1).GetChild(3).GetChild(0).GetChild(1).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.HP).Basic, Character.GetStatus(StatType.MAXHP).Basic);
            // Other Status
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(1).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.ATK));
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(2).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.DEF));    
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(3).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.STR));
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(4).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.DEX));
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(5).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.INT));
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(6).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.LUK));
            TextEditor.Instance.ChangeStatusText(transform.GetChild(2).GetChild(7).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.CRIT));
        }
    }
}