using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button NewGameButton;
    [SerializeField] Button LoadGameButton;
    [SerializeField] Button OutGameButton;

    private void Awake()
    {
        if (!SaveLoad.Instance.HavingSave())
        {
            Color currentColor = LoadGameButton.GetComponent<Image>().color;
            currentColor.a = 0.3f;
            LoadGameButton.GetComponent<Image>().color = currentColor;
            LoadGameButton.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            LoadGameButton.transform.GetChild(1).gameObject.SetActive(true);
            LoadGameButton.onClick.AddListener(LoadOldGame);
        }
        OutGameButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        NewGameButton.onClick.AddListener(PlayNewGame);

    }
    void PlayNewGame()
    {
        GetComponent<MainMenu>().enabled = false;
        GlobalVariable.IsLoad = true;
        SceneManager.LoadScene("lever1");
    }
    void LoadOldGame()
    {
        GlobalVariable.IsLoad = false;
        GetComponent<MainMenu>().enabled = false;
        SceneManager.LoadScene("lever1");
    }
}
