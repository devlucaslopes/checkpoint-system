using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    public static GameManager Instance;

    void Start()
    {
        Instance = this;

        player = GameObject.FindObjectOfType<Player>();
    }

    public void SaveCheckpoint(Vector3 position)
    {
        if (position != Vector3.zero)
        {
            PlayerPrefs.SetFloat("checkpointX", position.x);
            PlayerPrefs.SetFloat("checkpointY", position.y);
        }
    }

    public void RespawnPlayer()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        Vector3 respawnPosition = new Vector3(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"), 0);
        player.transform.position = respawnPosition;
    }
}
