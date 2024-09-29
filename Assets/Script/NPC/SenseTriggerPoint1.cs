using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SenseTriggerPoint1 : MonoBehaviour
{
    GameObject TalkBroad;
    [SerializeField] GameObject FlashImage;
    [SerializeField] Text TalkingText;
    [SerializeField] List<string> TalkingContent = new List<string>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DataManager.Instance.PlayerStatus.GaveFlash)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player")&& !DataManager.Instance.PlayerStatus.GaveFlash)
        {
            StartTalking();
        }
    }
    public void StartTalking()
    {
            GameObject Temp = Player.Instance.gameObject;
            Temp.GetComponent<PlayerControl>().enabled=false;
            Temp.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            TalkBroad = transform.GetChild(0).gameObject;
            TalkBroad.SetActive(true);
            StartCoroutine("OnClick");
    }
    IEnumerator OnClick()
    { 
        int i= 0;
        TalkingText.text = TalkingContent[i];
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                i++;
                if (i >= TalkingContent.Count)
                {
                    StartCoroutine("GiveFlash");
                    DataManager.Instance.PlayerStatus.GaveFlash = true;
                    SettingButton.Instance.TurnOnFlashButton();
                    TalkBroad.transform.GetChild(0).gameObject.SetActive(false);
                    Player.Instance.gameObject.GetComponent<PlayerControl>().enabled = true;
                    yield break;
                }
                TalkingText.text = TalkingContent[i];
            }
            yield return null;
        }
    }
    IEnumerator GiveFlash()
    {
        FlashImage.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        yield break;
    }
}
