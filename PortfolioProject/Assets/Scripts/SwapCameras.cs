using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class _CameraRooms
{
    public GameObject _Camera;
    public int _RoomUp;
    public int _RoomDown;
    public int _RoomLeft;
    public int _RoomRight;
}

public class SwapCameras : MonoBehaviour
{
    public List<_CameraRooms> _Cameras = new List<_CameraRooms>();
    public int _ActiveCamera;
    public int _Shop = 0;
    public int _Storage = 1;
    public Storage _StorageBox;

    void Start()
    {
        foreach (var cam in _Cameras)
        {
            cam._Camera.SetActive(false);
        }
        _ActiveCamera = 0;
        _Cameras[_ActiveCamera]._Camera.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Switch(_Cameras[_ActiveCamera]._RoomUp);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Switch(_Cameras[_ActiveCamera]._RoomDown);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Switch(_Cameras[_ActiveCamera]._RoomLeft);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Switch(_Cameras[_ActiveCamera]._RoomRight);
        }
    }

    public void RightButton()
    {
        Switch(1);
    }

    public void Switch(int i)
    {
        if (i == _Storage)
        {
            _StorageBox.gameObject.transform.position = _StorageBox._StoragePos.transform.position;
            _StorageBox.Closed();
            _StorageBox.Empty();
        }
        else if(i == _Shop)
        {
            _StorageBox.gameObject.transform.position = _StorageBox._ShopPos.transform.position;
            _StorageBox.Open();
        }

        if (i >= 0)
        {
            int n = _ActiveCamera;
            _ActiveCamera = i;
            _Cameras[_ActiveCamera]._Camera.SetActive(true);
            _Cameras[n]._Camera.SetActive(false);
        }
    }
}
