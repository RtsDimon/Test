using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScaler : Unit
{
    public override void UpdateMe()
    {
        float s = Mathf.PingPong(Time.time, 1.0f);
        
        transform.localScale = new Vector3(s, s, s);
        
    }
}
