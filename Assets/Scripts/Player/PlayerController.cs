using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private bool _isDisabled;
    
    private float _axisInput;
    private bool _isJumpPressed;

    private BoxCollider2D _boxCollider2D;

    [SerializeField] private LayerMask jumpableGround;
    
    [SerializeField] private int jumpForce = 600;
    [SerializeField] private int moveSpeed = 10;
    private SoundManager _soundManager;
    private static readonly int State = Animator.StringToHash("state");

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (_isDisabled) return;
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
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
        if (_rb.velocity.y > 0.01f || _rb.velocity.y < -0.01f)
        {
            playerState = PlayerState.jumping;
        }
        else if (_rb.velocity.x < 0.01f && _rb.velocity.x > -0.01f)
        {
            playerState = PlayerState.idle;
        }
        else
        {
            playerState = PlayerState.running;
        }

        _animator.SetInteger(State, (int) playerState);
    }

    private void FixedUpdate()
    {
        if (_isDisabled) return;

        _rb.velocity = new Vector2(_axisInput * moveSpeed, _rb.velocity.y);

        if (_isJumpPressed && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0f); //reset jump velocity to avoid current jump/fall speed affecting next jump
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isJumpPressed = false;
            _soundManager.PlayJumpSound();
        }
    }

    private bool IsGrounded()
    {
        var bounds = _boxCollider2D.bounds;
        var raycastHit2D = Physics2D.BoxCast(bounds.center, bounds.size  - new Vector3(0.1f, 0f, 0f), 0, Vector2.down, .1f, jumpableGround);
        return raycastHit2D;
    }

    public void Disable()
    {
        _isDisabled = true;
    }

    public void Enable()
    {
        _isDisabled = false;
    }

    public void StopPlayerXVelocity()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }
}