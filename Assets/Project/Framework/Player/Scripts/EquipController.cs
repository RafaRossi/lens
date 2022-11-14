using UnityEngine;

public class EquipController : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    
    [SerializeField] private Transform playerEquipHolder;

    private int _currentEquipIndex = 0;
    
    private void OnEnable()
    {
        PlayerInventory.OnCollectedItem += CollectItem;
    }

    private void OnDisable()
    {
        PlayerInventory.OnCollectedItem -= CollectItem;
    }
    
    private void Update()
    {
        if(playerInventory.usableItems.Count <= 0) return;
        
        var scrollAmount = Input.GetAxisRaw("Mouse ScrollWheel") * 10;

        if (scrollAmount == 0) return;
        
        _currentEquipIndex += (int)scrollAmount;

        if (_currentEquipIndex >= playerInventory.usableItems.Count)
        {
            _currentEquipIndex = playerInventory.usableItems.Count - 1;
        }
        else if (_currentEquipIndex < 0)
        {
            _currentEquipIndex = 0;
        }

        EquipItem(_currentEquipIndex);
    }

    private void CollectItem(UsableItem item)
    {
        if (playerInventory.currentEquippedItem != null)
        {
            foreach (Transform equip in playerEquipHolder.transform)
            {
                equip.gameObject.SetActive(false);
            }
        }

        playerInventory.currentEquippedItem = Instantiate(item.EquipablePrefab, playerEquipHolder);
        
        EquipItem(playerEquipHolder.childCount - 1);
    }
    
    private void EquipItem(int index)
    {
        foreach (Transform equip in playerEquipHolder.transform)
        {
            equip.gameObject.SetActive(false);
        }
        
        var equipment = playerEquipHolder.GetChild(index).GetComponent<Equipable>();
        equipment.gameObject.SetActive(true);

        playerInventory.currentEquippedItem = equipment;
    }
}
