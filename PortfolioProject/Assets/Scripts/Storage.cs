using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public List<GameObject> _StoredItems = new List<GameObject>();
    public DropSlot _DropSlot;
    public GameObject _ShopPos;
    public GameObject _StoragePos;
    public GameObject _DropPos;
    public Inventory _Inventory;

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
            DragAndDrop dragAndDrop = item.GetComponent<DragAndDrop>();
            if(dragAndDrop._Item._Name == "Copper Ore")
            {
                if(_Inventory._CopperOres.Count == 0)
                {
                    _Inventory._CopperOres.Add(item);
                    Vector3 pos = new Vector3(_Inventory._CopperBox.transform.position.x, _Inventory._CopperBox.transform.position.y + 0.5f, _Inventory._CopperBox.transform.position.z);
                    _Inventory._CopperOres[0].transform.position = pos;
                    _Inventory._CopperOres[0].SetActive(true);
                }
                else
                {
                    _Inventory._CopperOres.Add(item);
                }
            }
            //item.transform.position = _DropPos.transform.position;
            //item.SetActive(true);
        }
        _StoredItems.Clear();
    }
}
