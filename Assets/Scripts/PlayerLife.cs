using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource playerDieSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.CompareTag("Trap"))
        {
            PlayerDie();

            
        }
    }

    private void PlayerDie()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("die");
        playerDieSound.Play();
    }

    private void RestartLevel(){
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }
}
