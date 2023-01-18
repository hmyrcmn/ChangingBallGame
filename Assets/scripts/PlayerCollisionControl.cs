using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionControl : MonoBehaviour
{
    #region Variables
    
    //Sounds
    [Header("Sounds")]
    [SerializeField] AudioClip bangClip;
    [SerializeField] AudioClip gainClip;
    [SerializeField] AudioClip BackSource;

    AudioSource audioSource;

    //Animations
    Animator animator;

    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //BackSource = GetComponent<AudioSource>();
        
    }
    

    #region Collision

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "blok":
                animator.SetTrigger("bang");
                PlayAudioClip(bangClip);
                break;
            
            case "ball":
               animator.SetTrigger("gain");
                PlayAudioClip(gainClip);
                break;
        } 
    }
    #endregion

    void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    } 
}
