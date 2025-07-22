using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> _CopperOres = new List<GameObject>();
    public GameObject _CopperBox;

    
    void Start()
    {
        
    }

    void Update()
    {
        if (_CopperOres.Count >= 1 && _CopperOres[0]==null)
        {
            _CopperOres.RemoveAt(0);
            if(_CopperOres.Count > 0)
            {
                Vector3 pos = new Vector3(_CopperBox.transform.position.x, _CopperBox.transform.position.y + 0.5f, _CopperBox.transform.position.z);
                _CopperOres[0].transform.position = pos;
                _CopperOres[0].SetActive(true);
            }
        }
    }
}
