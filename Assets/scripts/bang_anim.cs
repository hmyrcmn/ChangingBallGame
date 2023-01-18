using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bang_anim : MonoBehaviour
{
    private AudioSource my_bang_source; 
    private AudioSource  MySuccesSource;
    void Start (){
        my_bang_anim=GetComponent<Animator>();
        my_bang_source =  GetComponent<AudioSource>();
        MySuccesSource = GetComponent<AudioSource>();
    }
    

    

    private Animator my_bang_anim;
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("blok"))
        {
            print("çarptı");
            my_bang_anim.SetBool("bang_true",true);
            my_bang_source.Play();
         
        }        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("blok"))
        {
            this.Wait(1f, ()=>  my_bang_anim.SetBool("bang_true",false) ); 
           print("yokkk");
           // my_bang_anim.SetBool("bang_true",false);
            
        }        
    }
}
