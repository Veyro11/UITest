using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

class CharacterStatusComponent : MonoBehaviour
{
    [SerializeField] private Dictionary<StatType, Status> statuses;
    public string name;
    public string description;
    public int curHP;
    public int curMP;

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
}