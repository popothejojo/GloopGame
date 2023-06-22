using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSound;
  

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.CompareTag("Trap"))
    {
        Die();
    }
  }

  private void Die()
  {
    rb.bodyType = RigidbodyType2D.Static; 
    anim.SetTrigger("death");
    deathSound.Play();
  }

  private void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
