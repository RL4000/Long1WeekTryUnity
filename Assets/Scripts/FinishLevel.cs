using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private AudioSource finishLLevelSound;
    private bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player" && isFinish == false){
            finishLLevelSound.Play();
            isFinish = true;
            Invoke("CompleteLevel", 1f);
        }

    }

    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
