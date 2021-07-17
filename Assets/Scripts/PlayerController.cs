using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static bool _gameOver;

    Vector3 dir;
    [SerializeField] int count = 0;
    [SerializeField] float _moveSpeed;

    [SerializeField] Text _scoreText;

    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _scorePanel;
    [SerializeField] Text _finalScore;
    PlatformSpawner _platformSpawner;

    // Start is called before the first frame update
    void Start()
    {
        _gameOver = false;
        dir = Vector3.forward;
        _platformSpawner = GameObject.FindObjectOfType(typeof(PlatformSpawner)) as PlatformSpawner;
    }

    // Update is called once per frame
    void Update()
    {
        //Game over control
        if (transform.position.y < 1)
        {
            _gameOver = true;
            _finalScore.text = count.ToString();
            _gameOverPanel.active = true;
            _scorePanel.active = false;
            return;
        }




        //Direction changes with touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (dir == Vector3.forward)
                {
                    dir = Vector3.left;
                }
                else
                {
                    dir = Vector3.forward;
                }

            }

        }

        //Movement
        transform.position += dir * Time.deltaTime * _moveSpeed;

        //Score Update
        _scoreText.text = count.ToString();




    }



    void OnCollisionExit(Collision other)
    {
        count++;
        StartCoroutine(DestroyPlatform(other.gameObject));
        //Creating new 5 platform after 5 of them passed
        if (count % 5 == 0)
        {
            _platformSpawner.CreateTile(5);
        }
    }




    IEnumerator DestroyPlatform(GameObject platform)
    {
        yield return new WaitForSeconds(0.3f);
        platform.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.8f);
        Destroy(platform);
    }
}
