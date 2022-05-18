using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay=0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] int count=0;
  
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Ground" && count==0)
        {
            GetComponent<PlayerController>().DisableControl();
            crashEffect.Play();
            Debug.Log("Bonk!");
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            count++;
            Invoke("ReloadScene",delay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
