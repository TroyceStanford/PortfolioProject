using UnityEngine;

public class Smelter : MonoBehaviour
{
    public DropSlot _FuelSlot;
    public DropSlot _CrusableSlot;
    public GameObject _Fire;

    void Start()
    {
        _Fire.SetActive(false);
    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(_FuelSlot != null)
        {
            _Fire.SetActive(true);
            Destroy(_FuelSlot._DragAndDrop.gameObject);
            _FuelSlot._DragAndDrop = null;

            if(_CrusableSlot != null)
            {
                
            }
        }
    }
}
