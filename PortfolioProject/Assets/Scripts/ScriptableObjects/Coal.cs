using UnityEngine;

[CreateAssetMenu(menuName = "Item/Coal", fileName = "Coal.asset")]
public class Coal : Item
{
    private void Awake()
    {
        _Name = "Coal";

        _Type = Type.Fuel;

        _InShop = false;

        _Value = 10;
    }
}