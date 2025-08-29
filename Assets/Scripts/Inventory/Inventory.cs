using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : SingletonMono<Inventory>
{
    // Inventory system implementation goes here.
    public static List<Slot> Weapons;
    public int MaxInventorySize = 21;
    public int curInventorySize = 0;
    public GameObject SlotPrefab;

    public Transform EquippedDirectory;

    public void AddInventory(Slot Weapon)
    {
        if (Weapon != null && Weapons != null)
        {
            if (curInventorySize < MaxInventorySize)
            {
                curInventorySize++;
                Weapons.Add(Weapon);
                GameObject slot = Instantiate(SlotPrefab, transform);
                slot.GetComponentInChildren<Image>().sprite = Weapon.Equipment.SpriteImage;
            }
            else
                Debug.Log("Inventory Full");
        }
    }

    public void RemoveInventory(int index)
    {
        if (Weapons != null && index >= 0 && index < Weapons.Count)
        {
            Weapons.RemoveAt(index);
            curInventorySize--;
            Destroy(transform.GetChild(1).GetChild(0).GetChild(0).GetChild(index));
        }
    }

    public void ChangeEquipStatus(int index)
    {
        if (index >= curInventorySize)
        {
            return;
        }
        EquippedDirectory.GetChild(0).GetChild(0).gameObject.SetActive(false);
        EquippedDirectory = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(index);
        EquippedDirectory.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    public void AddWeapon()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                AddInventory(new Slot(ItemDB.Instance.Equipments[0], curInventorySize));
                break;
            case 1:
                AddInventory(new Slot(ItemDB.Instance.Equipments[1], curInventorySize));
                break;
            case 2:
                AddInventory(new Slot(ItemDB.Instance.Equipments[2], curInventorySize));
                break;
            default:
                break;
        }

    }   
}