using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float maxInteractionDistance = 4f;

    [SerializeField] private LayerMask interactableLayerMasks;

    [SerializeField] private PlayerInventory playerInventory;

    [SerializeField] private PlayerHUD playerHUD;

    [SerializeField] private Color onInteractRangeColor;

    private RaycastHit _raycastHit;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        CheckHits();
    }

    private void CheckHits()
    {
        if (Physics.Raycast(_camera.ScreenPointToRay(playerHUD.AimIndicator.rectTransform.position), out _raycastHit, maxInteractionDistance, interactableLayerMasks))
        {
            playerHUD.AimIndicator.color = onInteractRangeColor;
        }
        else
        {
            playerHUD.AimIndicator.color = Color.white;
        }
    }

    public void Interact()
    {
        if (_raycastHit.collider == null) return;
        
        var interactable = _raycastHit.collider.GetComponent<IInteractableComponent>();
        interactable?.Interact(this);
    }

    public Equipable GetCurrentEquippedItem => playerInventory.currentEquippedItem;
    
    public void UseItem()
    {
        if (playerInventory.currentEquippedItem != null)
        {
            playerInventory.currentEquippedItem.Use();
        }
    }
}
