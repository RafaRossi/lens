using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "New Lens Item", menuName = "Lens Item")]
public class Lens : BaseItem
{
    public override ItemType ItemType => ItemType.Lens;
    public VolumeProfile profile;
}
