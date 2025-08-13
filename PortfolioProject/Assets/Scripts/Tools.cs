using UnityEngine;

public class Tools : MonoBehaviour
{
    public bool _Hand;
    public GameObject _EmptyHand;
    public bool _Hammer;
    public GameObject _HammerHand;
    public DragAndDrop _DragAndDrop;
    
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _Hand = false;
            //_EmptyHand.SetActive(false);
            _Hammer = true;
            //_HammerHand.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _Hammer = false;
            //_HammerHand.SetActive(false);
            _Hand = true;
            //_EmptyHand.SetActive(true);
        }
    }
}
