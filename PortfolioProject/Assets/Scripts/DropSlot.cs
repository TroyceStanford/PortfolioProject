using UnityEngine;

public class DropSlot : MonoBehaviour
{
    public DragAndDrop _DragAndDrop;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DragAndDrop>() != null && _DragAndDrop == null) 
        {
            DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();
            dragAndDrop._DropSlot = this;
            _DragAndDrop = dragAndDrop; 
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