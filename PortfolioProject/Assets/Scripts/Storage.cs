using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public List<GameObject> _StoredItems = new List<GameObject>();
    public DropSlot _DropSlot;

    void Start()
    {
        
    }

    void Update()
    {
        if(_DropSlot._DragAndDrop != null && _DropSlot._DragAndDrop._Slotted == true)
        {
            _StoredItems.Add(_DropSlot._DragAndDrop.gameObject);
            _DropSlot._DragAndDrop.gameObject.SetActive(false);
            _DropSlot._DragAndDrop = null;
        }
    }
}
