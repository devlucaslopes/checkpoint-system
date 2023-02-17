using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject TextUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TextUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TextUI.SetActive(false);
        }
    }
}
