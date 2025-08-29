using System.Collections.Generic;
using UnityEngine;
public enum StatType
{
    None,
    Level,
    Exp,
    NextExp,
    HP,
    MAXHP,
    MP,
    MAXMP,
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
    public ControllerType? controller;
    public int Basic;
    public int Add1;
    public int Add2;
}

[CreateAssetMenu(fileName = "NewStatComponent", menuName = "Equipment Definition")]
public class EquipmentStatus : ScriptableObject
{
    public Status ATK;
    public Status DEF;
    public Status STR;
    public Status INT;
    public Status LUK;
    public Status CRIT;
    public Sprite SpriteImage;
    public List<Status> Statuses
    {
        get
        {
            return new List<Status> { ATK, DEF, STR, INT, LUK, CRIT };
        }
    }
    public string EquipmentName;
    public string SubName;
    public string Description;
}

