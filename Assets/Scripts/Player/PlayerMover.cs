using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private AudioSource _jumpSound;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
         _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _groundLayer);

        Move();

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        Jump();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        _jumpSound.Play();

        _rigidbody2D.velocity = Vector2.up * _jumpForce * Time.deltaTime;
    }
}