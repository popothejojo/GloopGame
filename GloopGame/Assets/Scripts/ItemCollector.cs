using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.gameObject.CompareTag("Banana"))
    {
        Destroy(collision.gameObject);
    }
}


}
