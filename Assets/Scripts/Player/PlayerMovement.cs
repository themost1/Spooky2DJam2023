using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Animator _animator;

    public float speed,
        jumpStrength;
    private List<GameObject> _feetTouching = new();
    private Rigidbody2D _rb;
    private float jumpDelay = 0,
        maxJumpDelay = 0.02f;
    private float _speedBoostTimeSecs = 0.0f;
    private float _flightTimeSecs = 0.0f;

    public bool IsGrounded
    {
        get { return _feetTouching.Count != 0; }
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
        float translateAmount;
        bool isJumping = false;
        if (Input.touchCount > 0)
        {
            Touch first_finger = Input.GetTouch(0);
            if (first_finger.position.x > Camera.main.pixelWidth / 2)
            {
                translateAmount = 1;
            }
            else
            {
                translateAmount = -1;
            }
            if (Input.touchCount > 1)
            {
                isJumping = true;
            }
        }
        else
        {
            translateAmount = Input.GetAxis("Horizontal");
            isJumping = Input.GetButton("Jump");
        }
        
        transform.Translate(
            Vector2.right
                * translateAmount
                * speed
                * (_speedBoostTimeSecs > 0 ? 1.6f : 1)
        );
        isJumping = isJumping && (IsGrounded || _flightTimeSecs > 0) && jumpDelay <= 0;
        if (isJumping)
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
        _flightTimeSecs -= Time.deltaTime;
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
            return;
        }
        else
        {
            _speedBoostTimeSecs += secs;
        }
    }

    public void AddFlightTime(float secs)
    {
        if (_flightTimeSecs < 0)
        {
            _flightTimeSecs = secs;
            return;
        }
        else
        {
            _flightTimeSecs += secs;
        }
    }
}
