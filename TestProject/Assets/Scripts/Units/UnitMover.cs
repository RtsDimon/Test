using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : Unit
{

    [SerializeField] float reTargetDist;
    [SerializeField] float speed;
    Transform target;
    public override void OnInit()
    {
        int r = Random.Range(0, unitManager.units.Count);
        target = unitManager.units[r].transform;
    }
    public override void UpdateMe()
    {

        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed *Time.deltaTime);
        if (target)
        {
            float d = (target.position - transform.position).sqrMagnitude;
            if (d <= reTargetDist * reTargetDist)
            {
                int r = Random.Range(0, unitManager.units.Count);
                target = unitManager.units[r].transform;
                
            }
        }
        
    }
}
