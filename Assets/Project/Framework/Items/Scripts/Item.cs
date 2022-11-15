using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ScriptableObject
{
    public virtual ItemType ItemType
    {
        get => ItemType.Default;
    }
}

[CreateAssetMenu(fileName = "New Default Item", menuName = "Default Item")]
public class Item : BaseItem
{
    public override ItemType ItemType => ItemType.Default;
    public Pickable pickablePrefab;
}

public enum ItemType
{
    Default,
    Usable,
    Lens
}
