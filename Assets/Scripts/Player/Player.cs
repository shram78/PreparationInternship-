using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _coinKeepSound;

    private int _score;

    public void AddScore()
    {
        _coinKeepSound.Play(); 

        _score++;

        Debug.Log(_score);
    }
}
