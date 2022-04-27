using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAnim : MonoBehaviour
{

    public Animator Store_Idle;
    public Animator animator; 
    void Awake()
    {
       Store_Idle = gameObject.GetComponent<Animator>();
    }

    
}
