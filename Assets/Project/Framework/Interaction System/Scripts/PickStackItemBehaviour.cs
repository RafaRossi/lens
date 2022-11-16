using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickStackItemBehaviour : PickItemBehaviour
{
    [SerializeField] private List<GameObject> objectsStack = new List<GameObject>();

    public override bool? Interact(Interactor interactor)
    {
        if (base.Interact(interactor) != true) return false;

        var _object = objectsStack[^1];
        objectsStack.Remove(_object);
        
        _object.SetActive(false);

        if (objectsStack.Count <= 0)
        {
            Destroy(gameObject);
        }

        return true;
    }
}
