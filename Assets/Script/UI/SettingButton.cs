using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingButton : Singleton<SettingButton>
{
    [SerializeField] Button TurnOnSettingButton;
    [SerializeField] Button InventoryButton;
    [SerializeField] Button Test;
    [SerializeField] Button FlashButton;

    [SerializeField] Slider SoundBGSlider;
    [SerializeField] Slider SoundEffectSlider;
    [SerializeField] Button EndGameButton;
    [SerializeField] Button BackButton;

    private GameObject FlashButtonGameObject;
    private GameObject FlashOfPlayer;

    [SerializeField] Canvas Inventory;
    public RectTransform CointRT;

    [SerializeField] GameObject SettingBroad;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        TurnOnSettingButton.onClick.AddListener(TurnSetting);
        InventoryButton.onClick.AddListener(TurnOnInventory);
        Test.onClick.AddListener(Test1);
        FlashButton.onClick.AddListener(ClickFlashButton);
        SoundBGSlider.onValueChanged.AddListener((float value) =>
        {
            AudioControler.Instance.ChangeBackgroundVolume(SoundBGSlider.value);
        });
        SoundEffectSlider.onValueChanged.AddListener((float value) =>
        {
            AudioControler.Instance.ChangeEffectVolume(SoundEffectSlider.value);
        });
        BackButton.onClick.AddListener(() =>
        {
            SettingBroad.SetActive(false);
        });
        EndGameButton.onClick.AddListener(ReturnMainMenu);
    }
    private void Start()
    {
        FlashOfPlayer = Player.Instance.transform.GetChild(1).gameObject;
        FlashButtonGameObject = FlashButton.gameObject;
        TurnOnFlashButton();
    }
    public void TurnOnFlashButton()
    {
        if (DataManager.Instance.PlayerStatus.GaveFlash)
        {
            FlashButtonGameObject.SetActive(true);
        }
        else
        {
            FlashButtonGameObject.SetActive(false);
        }
    }
    private void ClickFlashButton()
    {
        FlashOfPlayer.SetActive(!FlashOfPlayer.activeSelf);
    }
    private void TurnSetting()
    {
        SettingBroad.SetActive(true);
    }
    private void TurnOnInventory()
    {
        Inventory.enabled = !Inventory.enabled;
    }
    void Test1()
    {
        InventoryManager.Instance.add(10, 7);
        DataManager.Instance.UsageItem[10]();
    }
    private void ReturnMainMenu()
    {
        Destroy(Player.Instance.gameObject);
        Destroy(InventoryManager.Instance.gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene("Mainmenu");
    }
    private void OnApplicationQuit()
    {
        Destroy(InventoryManager.Instance.gameObject);
    }
}
