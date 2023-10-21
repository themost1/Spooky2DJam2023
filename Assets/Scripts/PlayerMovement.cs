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

    void FixedUpdate()
    {
        float translateAmount = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * translateAmount * speed * Time.deltaTime);
        if (Input.GetButton("Jump") && IsGrounded)
        {
            _rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
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
