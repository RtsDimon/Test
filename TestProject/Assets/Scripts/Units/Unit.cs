using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [HideInInspector] public UnitManager unitManager;
    public void Start()
    {
        unitManager = UnitManager.instance;
        unitManager.units.Add(this);
        OnInit();
    }
    public virtual void OnInit()
    {
        //init
    }
    public virtual void UpdateMe()
    {
        //stuff
    }
}
