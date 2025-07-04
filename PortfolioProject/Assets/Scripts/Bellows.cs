using UnityEngine;

public class Bellows : MonoBehaviour
{
    public SmelterFire _SmelterFire;
    public Smelter _Smelter;
    public GameObject _Fire;

    void Start()
    {
        _Fire.SetActive(false);
    }

    void Update()
    {
        if(_Smelter._Smelting == true && _SmelterFire._Fuel <= 0)
        {
            _Fire.SetActive(false);
            _Smelter._Smelting = false;
        }
    }

    private void OnMouseDown()
    {
        if(_SmelterFire._Fuel > 0)
        {
            _Fire.SetActive(true);
            _Smelter._Smelting = true;
        }
    }
}
