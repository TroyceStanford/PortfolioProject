using UnityEngine;

public class Forge : MonoBehaviour
{
    public bool _Heated;
    public DropSlot _DropSlot;
    public Smithing _Smithing;

    void Start()
    {
        _Heated = false;
    }


    void Update()
    {
        if(_Heated == false && _DropSlot._DragAndDrop != null)
        {
            _Smithing = _DropSlot._DragAndDrop.GetComponent<Smithing>();
            _Smithing.Heat();
            _Smithing._Heating = true;

            if(_Smithing._Heat >= 10)
            {
                _Heated = true;
            }
        }

        if(_DropSlot._DragAndDrop == null)
        {
            _Heated = false;
            if(_Smithing != null)
            {
                _Smithing._Heating = false;
                _Smithing = null;
            }
        }
    }
}
