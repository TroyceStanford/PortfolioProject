using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public Item _Item;
    public Money _Money;
    public SwapCameras _SwapCameras;
    public bool _Dragging = false;
    public bool _Slotted = false;
    public Vector3 _MousePos;
    public DropSlot _DropSlot = null;
    public Rigidbody _Rigidbody;
    public Camera _Camera;
    public Tools _Tools;
    private float _Z;
    
    private void Start()
    {
        _Money = FindFirstObjectByType<Money>();
        _Tools = FindFirstObjectByType<Tools>();
        _SwapCameras = FindFirstObjectByType<SwapCameras>();
        _Rigidbody = this.gameObject.GetComponent<Rigidbody>();
        _Item = Instantiate(_Item);
        _Z = 0;
    }

    public void Update()
    {
        if(_Camera != _SwapCameras._Cameras[_SwapCameras._ActiveCamera]._Camera) 
        {
            _Camera = _SwapCameras._Cameras[_SwapCameras._ActiveCamera]._Camera.GetComponent<Camera>();
        }

        if(_Dragging == true && _Tools._Hand == false)
        {
            _Dragging = false;

            _Rigidbody.useGravity = true;
            _Rigidbody.linearVelocity = Vector3.zero;
            _Rigidbody.angularVelocity = Vector3.zero;
        }
    }

    public Vector3 GetMousePos()
    {
        return _Camera.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        if(_Tools._Hand == true)
        {
            Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;

            if (_DropSlot != null)
            {
                _DropSlot._DragAndDrop = null;
                _DropSlot = null;
            }

            _DropSlot = null;

            if (_Item._InShop == true)
            {
                if (_Item._Value <= _Money._Money)
                {
                    _Money.Buy(_Item);
                    _Dragging = true;
                    _Slotted = false;
                    _Rigidbody.useGravity = false;
                    _MousePos = Input.mousePosition - GetMousePos();
                }
                else
                {
                    StartCoroutine(_Money.CanNotAfford());
                }
            }
            else
            {
                _Dragging = true;
                _Slotted = false;
                _Rigidbody.useGravity = false;
                _MousePos = Input.mousePosition - GetMousePos();
            }
        }
        else if(_Tools._Hammer == true && _DropSlot.gameObject.name == "Anvil")
        {
            if(this.gameObject.GetComponent<Smithing>() != null)
            {
                Smithing smithing = this.gameObject.GetComponent<Smithing>();
                smithing.Hit();
            }
        }
    }

    private void OnMouseDrag()
    {
        if(_Dragging == true)
        {
            _Z += Input.GetAxis("Mouse ScrollWheel");
            //float speed = 50;
            //Vector3 pos = _Camera.ScreenToWorldPoint(Input.mousePosition - _MousePos);
            //Vector3 target = new Vector3(pos.x, pos.y, pos.z + _Z);
            //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //_Rigidbody.linearVelocity = pos;
            //_Rigidbody.MovePosition(target);

            Vector3 pos = _Camera.ScreenToWorldPoint(Input.mousePosition - _MousePos);
            pos.z += _Z;
            _Rigidbody.linearVelocity = (pos - transform.position) * 20;
        }
    }

    private void OnMouseUp() 
    {
        if(_Dragging == true)
        {
            _Dragging = false;

            if (_DropSlot != null)
            {
                SlotIn();
            }
            else
            {
                _Rigidbody.useGravity = true;
                _Rigidbody.linearVelocity = Vector3.zero;
                _Rigidbody.angularVelocity = Vector3.zero;
            }
        }
    }

    public void SlotIn()
    {
        _DropSlot._DragAndDrop = this;
        _Slotted = true;
        _Rigidbody.useGravity = false;
        _Rigidbody.linearVelocity = Vector3.zero;
        _Rigidbody.angularVelocity = Vector3.zero;
        transform.position = _DropSlot.gameObject.transform.position;
        transform.rotation = _DropSlot.gameObject.transform.rotation;
        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
}