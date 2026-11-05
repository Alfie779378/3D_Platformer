using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryText : MonoBehaviour
{
    public GameObject WinText;





    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("win");

            WinText.SetActive(true);

        }
    }
}
