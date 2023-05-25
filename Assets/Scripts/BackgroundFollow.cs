using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField]
    float yIncrement = 10.05f;
    [SerializeReference]
    Transform background;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 newPos = new Vector3(background.position.x, background.position.y + yIncrement, background.position.z);
            background.position = newPos;
        }
    }
}
