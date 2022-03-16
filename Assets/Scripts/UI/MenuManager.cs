using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _buttonClickSound;
    [SerializeField] private Button _openStoreButton;

    private void OnBackMainMenuButton()
    {
        //Time.timeScale = 1;
        MainMenu.Load();
    }
}