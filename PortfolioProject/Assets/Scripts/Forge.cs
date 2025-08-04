using UnityEngine;

public class Forge : MonoBehaviour
{
    public bool _Heated;
    public DropSlot _DropSlot;

    void Start()
    {
        _Heated = false;
    }


    void Update()
    {
        if(_Heated == false && _DropSlot._DragAndDrop != null)
        {
            Smithing smithing = _DropSlot._DragAndDrop.GetComponent<Smithing>();
            smithing.Heat();
            _Heated = true;
        }

        if(_Heated == true &&  _DropSlot._DragAndDrop == null)
        {
            _Heated = false;
        }
    }
}
