using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        IJunior.TypedScenes.MainMenu.Load();
    }
}