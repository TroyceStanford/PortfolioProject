using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public List<GameObject> _StoredItems = new List<GameObject>();
    public DropSlot _DropSlot;
    public GameObject _ShopPos;
    public GameObject _StoragePos;
    public GameObject _DropPos;

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

    public void Open()
    {
        _DropSlot.enabled = true;
    }

    public void Closed()
    {
        _DropSlot.enabled = false;
    }

    public void Empty()
    {
        foreach(var item in _StoredItems)
        {
            item.transform.position = _DropPos.transform.position;
            item.SetActive(true);
        }
        _StoredItems.Clear();
    }
}
