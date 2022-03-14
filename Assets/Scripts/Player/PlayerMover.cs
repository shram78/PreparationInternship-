using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
   // [SerializeField] private float _inertionX;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _playerDie;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private Animator _animator;
    private const string IsJumping = "IsJumping";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move1();
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, 0.1f, _groundLayer);

        _animator.SetBool(IsJumping, false);

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                //Move1();
                Jump1();

        //    if (_isGrounded)
          //      Jump1();
    }

    private void Move1()
    {
        _animator.SetBool(IsJumping, true);

        transform.Translate(Vector2.right * _speed * Time.deltaTime);

      //  _rigidbody2D.AddForce(new Vector2(_inertionX, 0) * Time.deltaTime, ForceMode2D.Force);
    }

    private void Jump1()
    {
        _jumpSound.Play();

        _rigidbody2D.velocity = Vector2.up * _jumpForce * Time.deltaTime;
    }
}