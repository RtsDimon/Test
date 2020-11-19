using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRotator : Unit
{
    float speed;
    [SerializeField] float maxSpeed = 100.0f;
    [SerializeField] float minSpeed = 40.0f;

    public override void OnInit()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
    public override void UpdateMe()
    {
        
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        
    }
}
