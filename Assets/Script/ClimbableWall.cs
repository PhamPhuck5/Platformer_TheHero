using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableWall : MonoBehaviour
{
    private GameObject ThisPlayer;
    private void Start()
    {
        ThisPlayer = Player.Instance.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("CLimb");
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerClimb temp = ThisPlayer.GetComponent<PlayerClimb>();
            temp.enabled = true;
            temp.Init();
            ThisPlayer.GetComponent<PlayerControl>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        ThisPlayer.GetComponent<PlayerControl>().enabled = true;
        ThisPlayer.GetComponent<PlayerClimb>().enabled = false;
    }

}
