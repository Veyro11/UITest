using UnityEngine;
using TMPro;

public class WeaponStatusChanger: MonoBehaviour
{
    [SerializeField] private WeaponStatusComponent Status;

    private void Start()
    {
        Status = Inventory.Weapons
    }
}