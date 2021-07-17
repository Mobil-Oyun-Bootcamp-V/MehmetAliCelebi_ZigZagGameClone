using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject _platformPrefab;

    void Start()
    {
        CreateTile(15);
    }


    //Platform creator method
    public void CreateTile(int tileCount)
    {
        for (int i = 0; i < tileCount; i++)
        {

            Vector3 dir;
            if (Random.Range(0, 2) == 0)
            {
                dir = Vector3.forward * 3;
            }
            else
            {
                dir = Vector3.left * 3;
            }
            _platformPrefab = Instantiate(_platformPrefab, _platformPrefab.transform.position + dir, _platformPrefab.transform.rotation);
        }
    }

}
