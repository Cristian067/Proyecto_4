using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private Rigidbody rb;

    [SerializeField] private float speed;

    private GameObject player;

    private SpawnManager spawnManager;


    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

        spawnManager = FindAnyObjectByType<SpawnManager>();

        player = GameObject.Find("Player");

        spawnManager.enemyCount++;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = (player.transform.position - transform.position).normalized;

        rb.AddForce(direction * speed);

        if(transform.position.y <-1)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnDestroy()
    {
        spawnManager.enemyCount--;
    }


}
