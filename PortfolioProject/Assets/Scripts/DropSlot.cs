using System.Collections.Generic;
using UnityEngine;

public class DropSlot : MonoBehaviour
{
    public DragAndDrop _DragAndDrop;
    public List<Item> _AcceptedItems = new List<Item>();
    private bool _Accepted;

    public void Awake()
    {
        _Accepted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();

        foreach (var item in _AcceptedItems)
        {
            if(item._Name == dragAndDrop._Item._Name)
            {
                _Accepted = true;
            }
        }

        if(other.GetComponent<DragAndDrop>() != null && _DragAndDrop == null && _Accepted == true) 
        {
            dragAndDrop._DropSlot = this;
            _DragAndDrop = dragAndDrop;
            _Accepted = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DragAndDrop>() != null)
        {
            DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();
            if(dragAndDrop._DropSlot == this)
            {
                dragAndDrop._DropSlot = null;
            }

            if(_DragAndDrop == dragAndDrop)
            {
                _DragAndDrop = null;
            }
        }
    }
}