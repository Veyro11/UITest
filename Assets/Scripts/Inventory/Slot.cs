using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // Inventory system implementation goes here.
    public EquipmentStatus Equipment;
    public int SlotID;
    public Transform SlotDirectory;

    public Slot(EquipmentStatus equipment, int id)
    {
        Equipment = equipment;
        SlotID = id;
        this.SlotDirectory = transform;
    }

}