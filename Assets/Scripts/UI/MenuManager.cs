using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private void OnBackMainMenuButton()
    {
        MainMenu.Load();
    }
}