using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMovement : MonoBehaviour
{
    public float speed;
    public string loseScene;
    private float _time;
    private float _startX;

    private void Start()
    {
        _time = 0;
        _startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        Vector2 newPos = transform.position;
        newPos.x = _startX + _time * speed;
        newPos.y = PlayerMovement.instance.transform.position.y;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(loseScene);
    }
}
