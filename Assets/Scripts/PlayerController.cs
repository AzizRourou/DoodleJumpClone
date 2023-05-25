using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField]
    float edgeOnX = 3.7f;
    [SerializeReference]
    Text scoreText;
    Rigidbody2D rb;
    float moveX = 0f;
    int score = 0;
    float maxY = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        if (transform.position.x < -edgeOnX)
        {
            Vector3 newPos = new Vector3(edgeOnX, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

        if (transform.position.x > edgeOnX)
        {
            Vector3 newPos = new Vector3(-edgeOnX, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

        if (maxY < gameObject.transform.position.y)
        {
            maxY = gameObject.transform.position.y;
            score = (int)(maxY * 10);
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
}
