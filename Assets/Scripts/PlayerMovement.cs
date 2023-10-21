using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Animator _animator;

    public float speed, jumpStrength;
    private List<GameObject> _feetTouching = new();
    private Rigidbody2D _rb;
    private float jumpDelay = 0, maxJumpDelay = 0.1f;
    private float _speedBoostTimeSecs = 0.0f;

    public bool IsGrounded
    {
        get
        {
            return _feetTouching.Count != 0;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float translateAmount = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * translateAmount * speed * (_speedBoostTimeSecs > 0 ? 1.4f : 1));
        if (Input.GetButton("Jump") && IsGrounded && jumpDelay <= 0)
        {
            _rb.velocity = new Vector3(0, jumpStrength, 0);
            jumpDelay = maxJumpDelay;
        }
        _animator.SetInteger("walking_dir", Mathf.RoundToInt(translateAmount));
    }

    void Update()
    {
        jumpDelay -= Time.deltaTime;
        _speedBoostTimeSecs -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_feetTouching.Contains(collision.gameObject) && collision.gameObject.tag != "Pickup")
        {
            _feetTouching.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_feetTouching.Contains(collision.gameObject) && collision.gameObject.tag != "Pickup")
        {
            _feetTouching.Remove(collision.gameObject);
        }
    }

    public void AddSpeedBoostTime(float secs)
    {
        if (_speedBoostTimeSecs < 0)
        {
            _speedBoostTimeSecs = secs;
        }
        _speedBoostTimeSecs += secs;
    }
}
