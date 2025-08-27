using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StatType
{
    None,
    HP,
    MP,
    ATK,
    DEF,
    STR,
    DEX,
    INT,
    LUK,
    CRIT
}

public enum ControllerType
{
    Player,
    Equipables
}

[CreateAssetMenu(fileName = "NewStatDefinition", menuName = "Stats/Stat Definition")]
public class Status : ScriptableObject
{
    public StatType type;
    public ControllerType controller;
    public int Basic;
    public int? Add1;
    public int? Add2;
}