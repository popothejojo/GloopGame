using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject controller, explosion;
    //public AudioSource aSource;
    [SerializeField]public float velX = 0f;
    [SerializeField]float velY = 0f;
    Rigidbody2D rb;
    [SerializeField]float delayTimer = 3.0f;
    public bool isEnemy, isLeft;

    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
        // GameController check
        // if (controller == null)
        //     controller = GameObject.FindGameObjectWithTag("GameController");

        // Audio Check
        // if (aSource == null)
        //     aSource = GetComponent<AudioSource>();

        // Despawn after 3 seconds
        Destroy(gameObject,delayTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2 (velX, velY);
    }


}
