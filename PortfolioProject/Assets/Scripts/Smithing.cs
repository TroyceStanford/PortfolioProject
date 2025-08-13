using UnityEngine;

public class Smithing : MonoBehaviour
{
    public float _Heat;
    public GameObject _Finished;
    public int _Stage;
    public bool _Heating;

    void Start()
    {
        _Heating = false;
    }


    void Update()
    {
        if(_Heating == false && _Heat > 0)
        {
            _Heat -= Time.deltaTime;
        }

        if(_Heat > 0)
        {
            Material material = this.gameObject.GetComponent<MeshRenderer>().material;
            //material.EnableKeyword("_EMISSION");
            //material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            material.SetVector("_EmissionColor", new Vector4(191, 19, 0) * _Heat);
        }
        else
        {
            Material material = this.gameObject.GetComponent<MeshRenderer>().material;
            material.SetVector("_EmissionColor", new Vector4(191, 19, 0) * 0);
            //material.DisableKeyword("_EMISSION");
            //material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        }


    }

    public void Hit()
    {
        if (_Heat > 0)
        {
            switch (_Stage)
            {
                case 0:
                    transform.localScale = new Vector3(1, 0.5f, 1);
                    _Stage++;
                    break;
                case 1:
                    transform.localScale = new Vector3(1, 0.5f, 0.5f);
                    _Stage++;
                    break;
                case 2:
                    transform.localScale = new Vector3(1, 0.1f, 0.5f);
                    _Stage++;
                    break;
                case 3:
                    GameObject finished = Instantiate(_Finished);
                    finished.transform.position = this.transform.position;
                    finished.transform.rotation = this.transform.rotation;

                    Material material = this.gameObject.GetComponent<MeshRenderer>().material;
                    material.SetVector("_EmissionColor", new Vector4(191, 19, 0) * 0);
                    //material.DisableKeyword("_EMISSION");
                    //material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

                    Destroy(this.gameObject);
                    break;
            }
        }
    }


    public void Heat()
    {
        _Heat += Time.deltaTime;
    }
}
