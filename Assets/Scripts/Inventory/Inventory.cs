using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : SingletonMono<Inventory>
{
    // Inventory system implementation goes here.
    public static List<EquipmentStatus> Weapons;
    public int MaxInventorySize = 21;
    public int curInventorySize = 0;

    public void AddInventory(EquipmentStatus Weapon)
    {
        if (Weapon != null && Weapons != null)
        {
            if(curInventorySize < MaxInventorySize)
                Weapons.Add(Weapon);
            else
                Debug.Log("Inventory Full");
        }
    }

    public void RemoveInventory(int index)
    {
        if (Weapons != null && index >= 0 && index < Weapons.Count)
        {
            Weapons.RemoveAt(index);
        }
    }

    public void UpdateInventory()
    {
        if (Weapons == null) return;
        for(int i=0; i < Weapons.Count; i++)
        {
            Image icon = transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>();
            if (icon != null)
                icon.sprite = Weapons[i].SpriteImage;
        }
    }
}