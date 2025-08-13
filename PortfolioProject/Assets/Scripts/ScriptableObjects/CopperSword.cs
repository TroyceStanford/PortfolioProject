using UnityEngine;

[CreateAssetMenu(menuName = "Item/Copper/CopperSword", fileName = "CopperSword.asset")]
public class CopperSword : Item
{
    private void Awake()
    {
        _Name = "Copper Sword";

        _Type = Type.Sword;

        _InShop = false;

        _Value = 1000;
    }
}