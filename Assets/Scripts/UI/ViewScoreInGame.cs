using UnityEngine;
using TMPro;

public class ViewScoreInGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreInGame;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChange;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChange;
    }

    private void OnScoreChange(int score)
    {
        _scoreInGame.text = score.ToString();
    }
}