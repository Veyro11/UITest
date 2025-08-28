using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class WeaponStatusComponent : MonoBehaviour
{
    [SerializeField] private Dictionary<StatType, Status> statuses;
    [SerializeField] private string name;

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