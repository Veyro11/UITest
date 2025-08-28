using UnityEngine;
using TMPro;

public class WeaponStatusChanger: MonoBehaviour
{
    [SerializeField] private EquipmentStatus Equipment;

    private void Start()
    {
        if (Inventory.Weapons != null)
            if (Inventory.Weapons.Count > 0)
                Equipment = Inventory.Weapons[0];
    }

    public void ChangeStatus(EquipmentStatus newStatus)
    {
        Equipment = newStatus;
    }

    public void WriteStatus()
    {
        if (Equipment != null)
        {
            TextEditor.Instance.ChangeText(transform.GetChild(0).GetComponent<TextMeshPro>(), Equipment.name);
            TextEditor.Instance.ChangeText(transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>(), Equipment.SubName);
            int voidIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Equipment.Statuses[i] == null)
                {
                    voidIndex++;
                    continue;
                }
                var status = Equipment.Statuses[i];
                var textComponent = transform.GetChild(1).GetChild(1).GetChild(i-voidIndex).GetComponent<TextMeshPro>();
                TextEditor.Instance.ChangeStatusText(textComponent, status);
            }
            TextEditor.Instance.ChangeText(transform.GetChild(2).GetChild(0).GetComponent<TextMeshPro>(), Equipment.Description);
        }
    }
}