using UnityEngine;

public class SmelterFire : MonoBehaviour
{
    public DropSlot _Dropslot;
    public float _Fuel;

    void Start()
    {
        _Fuel = 0;
    }

    void Update()
    {
        if (_Dropslot._DragAndDrop != null && _Dropslot._DragAndDrop._Slotted == true)
        {
            _Fuel += 10;
            Destroy(_Dropslot._DragAndDrop.gameObject);
            _Dropslot._DragAndDrop = null;
        }
    }
}
