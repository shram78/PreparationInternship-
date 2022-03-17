using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _backMainMenuButton;
    [SerializeField] private Button _creatorButton;
    [SerializeField] private Button _iJuniorUrlButton;

    private Animator _animator;
    private const string _isButtonPress = "IsButtonPressed";

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _creatorButton.onClick.AddListener(OnCreatorButtonClick);
        _backMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _iJuniorUrlButton.onClick.AddListener(OnIJuniorButtonClick);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _creatorButton.onClick.RemoveListener(OnCreatorButtonClick);
        _backMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _iJuniorUrlButton.onClick.RemoveListener(OnIJuniorButtonClick);
    }

    private void OnPlayButtonClick()
    {
        Level_1.Load();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnCreatorButtonClick()
    {
        _animator.SetBool(_isButtonPress, true);
    }
    private void OnBackMainMenuButton()
    {
        _animator.SetBool(_isButtonPress, false);
    }
    private void OnIJuniorButtonClick()
    {
        Application.OpenURL("https://ijunior.ru/");
    }
}
