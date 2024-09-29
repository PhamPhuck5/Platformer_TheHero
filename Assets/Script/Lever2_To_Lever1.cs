using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lever2_To_Lever1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SaveLoad.Instance.SaveInventory();
        SceneManager.LoadScene("lever1");
        GlobalVariable.IsLoad = true;
    }
}
