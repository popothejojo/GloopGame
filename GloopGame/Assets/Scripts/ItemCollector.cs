using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bananas = 0;
    [SerializeField] private Text bananasText;

private void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.gameObject.CompareTag("Banana"))
    {
        Destroy(collision.gameObject);
        bananas++;
        bananasText.text= "Bananas: " + bananas;

    }
}


}
