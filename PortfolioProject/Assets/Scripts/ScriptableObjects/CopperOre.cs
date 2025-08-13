using UnityEngine;

[CreateAssetMenu(menuName = "Item/Copper/CopperOre", fileName = "CopperOre.asset")]
public class CopperOre : Item
{
    private void Awake()
    {
        _Name = "Copper Ore";

        _Type = Type.Ore;

        _InShop = true;

        _Value = 50;
    }
}