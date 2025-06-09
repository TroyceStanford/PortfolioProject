using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public Vector3 _MousePos;
    public GameObject _DropSlot = null;
    private Rigidbody _Rigidbody;

    private void Start()
    {
        _Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        _Rigidbody.useGravity = true;
        _MousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position =  Camera.main.ScreenToWorldPoint(Input.mousePosition - _MousePos);
    }

    private void OnMouseUp() 
    {
        if(_DropSlot != null) 
        {
            _Rigidbody.useGravity = false;
            _Rigidbody.linearVelocity = Vector3.zero;
            _Rigidbody.angularVelocity = Vector3.zero;
            transform.position = _DropSlot.transform.position;
            transform.rotation = _DropSlot.transform.rotation;
        }
        else
        {
            _Rigidbody.useGravity = true;
        }
    }
}