using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameObject _baseObject;
    public float parallaxAmount = 0.1f;

    private Vector2 _startBasePos;
    private Vector2 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _baseObject = PlayerUtil.instance.gameObject;
        _startBasePos = _baseObject.transform.position;
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = (Vector2) _baseObject.transform.position - _startBasePos;
        delta.y = 0;
        delta *= parallaxAmount;
        Vector2 newPos = _startPos + delta;
        transform.position = newPos;
    }
}
