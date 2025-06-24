using System.Collections.Generic;
using UnityEngine;

public class SwapCameras : MonoBehaviour
{
    public List<GameObject> _Cameras = new List<GameObject>();
    public int _ActiveCamera;

    void Start()
    {
        foreach (var cam in _Cameras)
        {
            cam.SetActive(false);
        }
        _ActiveCamera = 0;
        _Cameras[_ActiveCamera].SetActive(true);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Switch(1);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Switch(-1);
        }
    }

    public void RightButton()
    {
        Switch(1);
    }

    public void Switch(int i)
    {
        if(_ActiveCamera + i < 0)
        {
            int n = _ActiveCamera;
            _ActiveCamera = _Cameras.Count-1;
            _Cameras[_ActiveCamera].SetActive(true);
            _Cameras[n].SetActive(false);
        }
        else if(_ActiveCamera + i >= _Cameras.Count)
        {
            int n = _ActiveCamera;
            _ActiveCamera = 0;
            _Cameras[_ActiveCamera].SetActive(true);
            _Cameras[n].SetActive(false);
        }
        else
        {
            int n = _ActiveCamera;
            _ActiveCamera += i;
            _Cameras[_ActiveCamera].SetActive(true);
            _Cameras[n].SetActive(false);
        }
    }
}
