using UnityEngine;

public class CoalBag : MonoBehaviour
{
    public GameObject _Coal;
    public GameObject _CoalPrefab;
    public GameObject _Spawnpoint;

    void Start()
    {
        
    }

    void Update()
    {
        if(_Coal == null)
        {
            _Coal = Instantiate(_CoalPrefab);
            _Coal.transform.position = _Spawnpoint.transform.position;
            _Coal.transform.rotation = _Spawnpoint.transform.rotation;
        }
    }
}
