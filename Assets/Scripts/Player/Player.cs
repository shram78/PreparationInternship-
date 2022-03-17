using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _coinKeepSound;

    public event UnityAction <int> ScoreChanged;

    public int _score;

    public void AddScore()
    {
        _coinKeepSound.Play(); 

        _score++;

        ScoreChanged?.Invoke(_score);
    }
}
