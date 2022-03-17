using System.Collections;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _backMainMenuButton;

    [SerializeField] private Button _creatorButton;
    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private Button _iJuniorUrlButton;

    private Animator _animator;
    private const string _isButtonPress = "IsButtonPressed";

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _creatorButton.onClick.AddListener(OnCreatorButtomClick);
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
        _creatorButton.onClick.RemoveListener(OnCreatorButtomClick);
        _backMainMenuButton.onClick.AddListener(OnBackMainMenuButton);
        _iJuniorUrlButton.onClick.RemoveListener(OnIJuniorButtonClick);
    }

    private void OnBackMainMenuButton()
    {
        _animator.SetBool(_isButtonPress, false);
    }

    private void OnPlayButtonClick()
    {
        StartCoroutine(DelayStart());
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnIJuniorButtonClick()
    {
        Application.OpenURL("https://ijunior.ru/");
    }

    private void OnCreatorButtomClick()
    {
        _animator.SetBool(_isButtonPress, true);
    }

    private IEnumerator DelayStart()
    {
        _buttonClickSound.Play();

        while (_buttonClickSound.isPlaying)
            yield return null;

        Level_1.Load();
    }
}
