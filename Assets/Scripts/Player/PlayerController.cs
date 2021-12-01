using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private float _axisInput;
    private bool _isJumpPressed = true;

    private BoxCollider2D _boxCollider2D;

    [SerializeField] private LayerMask _jumpableGround;
    
    [SerializeField] private int _jumpForce = 600;
    [SerializeField] private int _moveSpeed = 10;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }
        
        _axisInput = Input.GetAxisRaw("Horizontal");
        if (_axisInput > 0)
        {
            _renderer.flipX = false;
        }
        else if (_axisInput < 0)
        {
            _renderer.flipX = true;
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        PlayerState playerState;
        if (!IsGrounded())
        {
            playerState = PlayerState.jumping;
        }
        else if (_rb.velocity.x == 0)
        {
            playerState = PlayerState.idle;
        }
        else
        {
            playerState = PlayerState.running;
        }

        _animator.SetInteger("state", (int) playerState);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_axisInput * _moveSpeed, _rb.velocity.y);

        if (_isJumpPressed && IsGrounded())
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJumpPressed = false;
        }
    }

    private bool IsGrounded()
    {
        var bounds = _boxCollider2D.bounds;
        var raycastHit2D = Physics2D.BoxCast(bounds.center, bounds.size  - new Vector3(0.1f, 0f, 0f), 0, Vector2.down, .1f, _jumpableGround);
        return raycastHit2D;
    }
}