using UnityEngine;

[CreateAssetMenu(menuName = "Item/Copper/CopperBar", fileName = "CopperBar.asset")]
public class CopperBar : Item
{
    private void Awake()
    {
        _Name = "Copper Bar";

        _Type = Type.Metal;

        _InShop = false;

        _Value = 500;
    }
}