using UnityEngine;

public class DropSlot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<DragAndDrop>() != null) 
        {
            DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();
            dragAndDrop._DropSlot = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DragAndDrop>() != null)
        {
            DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();
            dragAndDrop._DropSlot = null;
        }
    }
}