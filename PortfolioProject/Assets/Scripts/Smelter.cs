using UnityEngine;

public class Smelter : MonoBehaviour
{
    public DropSlot _CrusableSlot;
    public SmelterFire _SmelterFire;
    public int _StoredOre;
    public bool _Smelting;
    public float _SmeltTime;
    public float _SmeltCap;
    public float _SmeltPoint;
    public bool _Done;

    void Start()
    {
        _Done = false;
        _Smelting = false;
    }

    void Update()
    {
        _SmeltCap = (_SmeltPoint / 20) * _StoredOre;

        if (_CrusableSlot._DragAndDrop != null && _CrusableSlot._DragAndDrop._Slotted == true)
        {
            _StoredOre += 1;
            Destroy(_CrusableSlot._DragAndDrop.gameObject);
            _CrusableSlot._DragAndDrop = null;
        }

        if (_Smelting == true)
        {
            if (_SmeltTime > _SmeltCap)
            {
                _SmeltTime = _SmeltCap;
            }
            else
            {
                _SmeltTime += Time.deltaTime;
            }

            if (_SmeltTime >= _SmeltPoint )
            {
                _Smelting = false; 
                _Done = true;
            }
        }
    }


}
