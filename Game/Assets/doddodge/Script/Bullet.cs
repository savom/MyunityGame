using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * speed;

        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag == "Player")
        {
            PlayerController playerContoller = other.GetComponent<PlayerController>();
            if (playerContoller != null)
            {
                playerContoller.Die();
            }
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
