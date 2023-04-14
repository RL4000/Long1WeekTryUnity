using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int point = 0;
    [SerializeField] private Text textPoint;
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("ItemCollect")){
            Destroy(collider.gameObject);
            point ++;
            textPoint.text = "Point:" + point;
            collectSound.Play();
        }
    }
}
