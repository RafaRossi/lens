using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Usable Item", menuName = "Usable Item")]
public class UsableItem : BaseItem
{
    public override ItemType ItemType => ItemType.Usable;
    public Equipable EquipablePrefab;
}
