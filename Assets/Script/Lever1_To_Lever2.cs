using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever1_To_Lever2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SaveLoad.Instance.SaveInventory();
        SceneManager.LoadScene("lever2");
    }
}
