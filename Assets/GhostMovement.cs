using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMovement : MonoBehaviour
{
    public float baseSpeed;
    public float increaseRate;
    public string loseScene;

    private float _blockedX = Mathf.Infinity;

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x = newPos.x + Time.deltaTime * GetSpeed();
        if (newPos.x > _blockedX)
        {
            newPos.x = _blockedX;
        }
        newPos.y = PlayerMovement.instance.transform.position.y;
        transform.position = newPos;
    }

    private float GetSpeed()
    {
        float playerX = PlayerMovement.instance.transform.position.x;
        float currX = transform.position.x;
        return (playerX - currX) * increaseRate + baseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(loseScene);
    }

    public void Block(float barrierX)
    {
        _blockedX = barrierX;
    }
}
