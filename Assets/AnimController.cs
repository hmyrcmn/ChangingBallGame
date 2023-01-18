using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
   
    Animator myAnimator;

void Start() {
    myAnimator = GetComponent<Animator>();
}

void Update() {
    myAnimator.Play("PlayerFireAnim", -1, 0f);
}

  
}
