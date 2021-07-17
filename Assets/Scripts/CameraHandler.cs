using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
   [SerializeField] Transform _followed;
    Vector3 _distance;
    // Start is called before the first frame update
    void Start()
    {
        _distance = transform.position - _followed.position;
    }


    void LateUpdate()
    {
        if(PlayerController._gameOver==true){
            return;
        }
        transform.position = _followed.position + _distance;
    }
}
