using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private AudioSource _jumpSound;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _isGrounded;
    private const string _isMoving = "IsMoving";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _groundLayer);

        PlayMoveAnimation();

        Move();

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
            Jump();
    }

    private void PlayMoveAnimation()
    {
        if (_rigidbody2D.velocity.x > 0)
            _animator.SetBool(_isMoving, true);
        else
            _animator.SetBool(_isMoving, false);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed * Time.deltaTime, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        _jumpSound.Play();

         _rigidbody2D.velocity = Vector2.up * _jumpForce * Time.deltaTime;
    }
}