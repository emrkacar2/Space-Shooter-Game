using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoater : MonoBehaviour
{
    Rigidbody physic;
    public int speed;
    void Start()
    {
        physic = GetComponent < Rigidbody>();
        physic.angularVelocity = Random.insideUnitSphere * speed;
    }

   
    void Update()
    {
        
    }
}
