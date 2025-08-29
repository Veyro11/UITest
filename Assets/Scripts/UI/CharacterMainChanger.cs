using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterMainChanger : MonoBehaviour
{
    [SerializeField] private CharacterStatusComponent Character;
    public void WriteStatus()
    {
        if (Character != null)
        {
            //name, level
            TextEditor.Instance.ChangeText(transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>(),
                $"{Character.name}\n<size=20> </size>\n<size=70>LV {Character.GetStatus(StatType.Level)}/300</size>");
            TextEditor.Instance.ChangeText(transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>(),Character.description);
            
            //HP, MP
            transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(300 * ((float)Character.GetStatus(StatType.HP).Basic / Character.GetStatus(StatType.MAXHP).Basic), 50);
            TextEditor.Instance.ChangeSlashText(transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.HP).Basic, Character.GetStatus(StatType.MAXHP).Basic);
            transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(300 * ((float)Character.GetStatus(StatType.HP).Basic / Character.GetStatus(StatType.MAXHP).Basic), 50);
            TextEditor.Instance.ChangeSlashText(transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.HP).Basic, Character.GetStatus(StatType.MAXHP).Basic);
            // level
            transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>().GetComponent<RectTransform>().sizeDelta = new Vector2(300 * ((float)Character.GetStatus(StatType.Exp).Basic / Character.GetStatus(StatType.NextExp).Basic), 10);
            TextEditor.Instance.ChangeSlashText(transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<TextMeshPro>(), Character.GetStatus(StatType.Exp).Basic, Character.GetStatus(StatType.NextExp).Basic);
        }
    }

}