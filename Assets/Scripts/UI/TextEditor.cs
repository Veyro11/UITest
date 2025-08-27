using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TextEditor : SingletonMono<TextEditor>
{
    [SerializeField] TMP_FontAsset[] fontAssets;

    // TODO: Add methods to change font color and text itself.
    // for this stat, I'll consider expandancy heavier than complexity.
    // so, let's make it just a simple method that can be called with parameters.
    // ...isn't actually that the same as before?


    public void ChangeStatusText(TextMeshPro Text, Status status)
    {
        // hexacode: <color=#7EFFD3>+6</color> : add1
        // hexacode: <color=#BB2F50>-6</color> : minus
        // hexacode: <color=#F9C2FF>+8</color> : add2
        if (Text != null && status != null)
        {
            if (status.Add1.HasValue && status.Add2.HasValue)
            {
                Text.text = $"{status.Basic}" +
                    $"{((status.Add1 < 0) ? ("<color=#BB2F50>-" + status.Add1 + "</color>") : ("<color=#7effd3>" + status.Add1 + "</color>"))}" +
                $" {((status.Add2 < 0) ? ("<color=#BB2F50>-" + status.Add2 + "</color>") : ("<color=#F9C2FF>" + status.Add2 + "</color>)"))}";
            }
            else if (status.Add1.HasValue)
            {
                Text.text = $"{status.Basic}" +
                    $"{((status.Add1 < 0) ? ("<color=#BB2F50>-" + status.Add1 + "</color>") : ("<color=#7effd3>" + status.Add1 + "</color>"))}";
            }
            else if (status.Add2.HasValue)
            {
                Text.text = $"{status.Basic}" +
                    $" {((status.Add2 < 0) ? ("<color=#BB2F50>-" + status.Add2 + "</color>") : ("<color=#F9C2FF>" + status.Add2 + "</color>)"))}";
            }
            else
            {
                Text.text = $"{status.Basic}";
            }
        }
    }

    public void ChangeText(TextMeshPro Text, String text)
    {
        if (Text != null)
        {
            Text.text = text;
        }
    }

    public void ChangeLevelText(TextMeshPro Text, string name, int Level, int spacing)
        {
        if (Text != null)
        {
            Text.text = $"{name}\n<size={spacing}> </size>\nLv {Level}/50";
        }
    }
    public void ChangeSlashText(TextMeshPro Text, int cur, int max, bool middlewhite = false)
    {
        if (Text != null)
        {
            Text.text = $"{cur}/{max}";
            if (middlewhite)
            {
                Text.text = $"{cur}<color=#ffffff>/</color>{max}";
            }
        }
        
    }
}