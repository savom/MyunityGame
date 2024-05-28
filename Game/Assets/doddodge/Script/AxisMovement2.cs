using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMovement2 : MonoBehaviour
{
    public float speed = 8.0f;
    public string horizontalAxis = "Horizontal2";
    public string verticalAxis = "Vertical2";
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
    }


    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
