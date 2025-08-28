using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using TMPro;

class CharacterStatusChanger : MonoBehaviour
{
    [SerializeField] private CharacterStatusComponent Character;

    public void WriteStatus()
    {
        if (Character != null)
        {
            TextEditor.Instance.ChangeText(transform.GetChild(0).GetComponent<TextMeshPro>(), Character.name);
            int voidIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                var status = Character.GetStatus((StatType)i);
                if (status == null)
                {
                    voidIndex++;
                    continue;
                }
                var textComponent = transform.GetChild(1).GetChild(1).GetChild(i - voidIndex).GetComponent<TextMeshPro>();
                TextEditor.Instance.ChangeStatusText(textComponent, status);
            }
        }
    }
}