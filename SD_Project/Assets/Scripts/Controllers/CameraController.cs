using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;

    void Start()
    {
        
    }

    void Update()
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude,LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude *0.8f;
                transform.position = _player.transform.position + Vector3.up * 0.7f + _delta.normalized * dist;
                transform.LookAt(transform.position);
            }
            else
            {
                transform.position = _player.transform.position+Vector3.up*0.5f + _delta;
                transform.LookAt(_player.transform);
            }
            

        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
