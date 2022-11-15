using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LensController : MonoBehaviour
{
    [SerializeField] private Volume postProcessVolume;
    [SerializeField] private VolumeProfile initialPostProcessProperties;
    
    [SerializeField] private List<Lens> lens = new List<Lens>();
    private Lens currentLen;
    
    public static Action<Lens> OnLensEquipped = delegate(Lens lens) {  };
    
    private void Update()
    {
        if(lens.Count < 0) return;
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipLen(lens[0]);
        }
    }

    private void OnEnable()
    {
        PlayerInventory.OnCollectedLens += CollectLen;
    }

    private void OnDisable()
    {
        PlayerInventory.OnCollectedLens -= CollectLen;
    }

    private void CollectLen(Lens len)
    {
        lens.Add(len);
    }

    private void EquipLen(Lens lens)
    {
        if (currentLen == lens)
        {
            UnEquipLen(lens);
            
            OnLensEquipped?.Invoke(null);
            return;
        }
        
        UnEquipLen(lens);
        currentLen = lens;

        postProcessVolume.profile = lens.profile;
        
        OnLensEquipped?.Invoke(lens);
    }

    private void UnEquipLen(Lens lens)
    {
        currentLen = null;

        postProcessVolume.profile = initialPostProcessProperties;
    }
}
