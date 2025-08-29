using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class CharacterStatusComponent : MonoBehaviour
{
    [SerializeField] private List<Status> statTypes;
    private Dictionary<StatType, Status> statuses;
    public string name;
    public string description;

    private void Awake()
    {
        statuses = new Dictionary<StatType, Status>();
        for (int i = 0; i < statTypes.Count; i++)
        {
            statuses.Add(statTypes[i].type, statTypes[i]);
        }
    }
    public void SetStatus(StatType type, Status status)
    {
        if (statuses.ContainsKey(type))
        {
            statuses[type] = status;
        }
        else
        {
            statuses.Add(type, status);
        }
    }

    public Status GetStatus(StatType type)
    {
        if (statuses.ContainsKey(type))
        {
            return statuses[type];
        }
        else
        {
            return null;
        }
    }
    
    public void UpdateStatus()
    {
        EquipmentStatus equipment = Inventory.Instance.EquippedDirectory.GetComponent<Slot>().Equipment;
        statuses[StatType.ATK].Add1 = equipment.ATK.Add1;
        statuses[StatType.DEF].Add1 = equipment.DEF.Add1;
        statuses[StatType.STR].Add1 = equipment.STR.Add1;
        statuses[StatType.INT].Add1 = equipment.INT.Add1;
        statuses[StatType.LUK].Add1 = equipment.LUK.Add1;
        statuses[StatType.CRIT].Add1 = equipment.CRIT.Add1;
        statuses[StatType.ATK].Add2 = equipment.ATK.Add2;
        statuses[StatType.DEF].Add2 = equipment.DEF.Add2;
        statuses[StatType.STR].Add2 = equipment.STR.Add2;
        statuses[StatType.INT].Add2 = equipment.INT.Add2;
        statuses[StatType.LUK].Add2 = equipment.LUK.Add2;
        statuses[StatType.CRIT].Add2 = equipment.CRIT.Add2;
    }
}