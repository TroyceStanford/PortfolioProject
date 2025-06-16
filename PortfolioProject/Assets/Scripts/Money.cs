using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float _Money;
    public TMPro.TMP_Text _MoneyText;
    public TMPro.TMP_Text _PopUpText;
    public static Money instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        _MoneyText.text = $"{_Money}";
    }

    public void Buy(Item item)
    {
        if(item._Value <= _Money)
        {
            _Money -= item._Value;
            item._InShop = false;
        }
        else
        {
            StartCoroutine(CanNotAfford());
        }
    }

    public IEnumerator CanNotAfford()
    {
        _PopUpText.text = $"You Do Not Have Enough Money";
        yield return new WaitForSeconds(1);
        _PopUpText.text = $"";
    }
}
