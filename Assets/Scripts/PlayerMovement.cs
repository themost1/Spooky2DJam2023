using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpStrength;

    private List<GameObject> _feetTouching = new();

    private Rigidbody2D _rb;
    public bool IsGrounded
    {
        get
        {
            return _feetTouching.Count != 0;
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float translateAmount = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * translateAmount * speed * Time.deltaTime);
        if (Input.GetButton("Jump"))
        {
            if (IsGrounded)
            {
                Vector2 vel = _rb.velocity;
                vel.y = jumpStrength;
                _rb.velocity = vel;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_feetTouching.Contains(collision.gameObject))
        {
            _feetTouching.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_feetTouching.Contains(collision.gameObject))
        {
            _feetTouching.Remove(collision.gameObject);
        }
    }
}
