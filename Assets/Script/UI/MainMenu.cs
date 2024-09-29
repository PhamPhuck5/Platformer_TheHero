using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button NewGame;
    [SerializeField] Button LoadGame;
    [SerializeField] Button OutGameButton;

    private void Awake()
    {
        NewGame.onClick.AddListener(PlayNewGame);
        if (!SaveLoad.Instance.HavingSave())
        {
            Color currentColor = LoadGame.GetComponent<Image>().color;
            currentColor.a = 0.3f;
            LoadGame.GetComponent<Image>().color = currentColor;
        }
        else
        {
            LoadGame.onClick.AddListener(LoadOldGame);
        }
        OutGameButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    void PlayNewGame()
    {
        SceneManager.LoadScene("lever1");
        GetComponent<MainMenu>().enabled = false;
    }
    void LoadOldGame()
    {
        SceneManager.LoadScene("lever1");
        GlobalVariable.IsLoad = true;
        GetComponent<MainMenu>().enabled = false;
    }
}
