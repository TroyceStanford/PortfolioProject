using UnityEngine;

public class Smithing : MonoBehaviour
{
    public float _Heat;
    public Item _Item;
    public Mesh _Mesh1;
    public Mesh _Mesh2;
    public Mesh _Mesh3;
    public GameObject _Finished;
    public int _Stage;

    void Start()
    {

    }


    void Update()
    {
        _Heat -= Time.deltaTime;
    }

    //make this on click and check for hammer variable?
    public void Hit()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        if (_Heat > 0)
        {
            switch (_Stage)
            {
                case 0:
                    mesh = _Mesh1;
                    _Stage++;
                    break;
                case 1:
                    mesh = _Mesh2;
                    _Stage++;
                    break;
                case 2:
                    mesh = _Mesh3;
                    _Stage++;
                    break;
                case 3:
                    GameObject finished = Instantiate(_Finished);
                    finished.transform.position = this.transform.position;
                    finished.transform.rotation = this.transform.rotation;
                    Destroy(this.gameObject);
                    break;
            }
        }
    }


    public void Heat()
    {
        _Heat += 10;
    }
}
