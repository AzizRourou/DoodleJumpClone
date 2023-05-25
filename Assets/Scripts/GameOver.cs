using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeReference]
    PlayerController playerController;
    [SerializeReference]
    BoxCollider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCollider.enabled = false;
            playerController.moveSpeed = 0;
        }
    }
}
