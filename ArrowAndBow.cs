﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBow : MonoBehaviour
{
    private Rigidbody myBody;
    public float speed = 30f;
    public float deactivate_timer = 3f;
    public float damage = 15f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_timer);
    }
   
    public void Launch(Camera mainCamera)
    {
        myBody.velocity = mainCamera.transform.forward * speed;
        transform.LookAt(transform.position + myBody.velocity);
    }
    void DeactivateGameObject()
    {
        if(gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider target)
    {

    }
}
    
