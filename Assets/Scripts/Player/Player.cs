using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _dieSound;

    private Rigidbody2D _rigidbody2D;

    public event UnityAction BeforeDie;
    public event UnityAction GameOver;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        BeforeDie?.Invoke();
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        _dieSound.Play();

        yield return new WaitWhile(() =>_dieSound.isPlaying);

        GameOver?.Invoke();

        gameObject.SetActive(false);
    }
}