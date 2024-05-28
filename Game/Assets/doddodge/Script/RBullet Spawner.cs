using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBulletSpawner : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 2f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

        // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<AxisMovement2>().transform;


    }

        // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject Rbullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rbullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
