using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTree : MyPlant
{
    private readonly float maxGrowth = 10;
    private float curGrowth = 1;
    private readonly float growthSpeed = 1.5f;

    public override string CommonName
    {
        get { return "Tree"; }
    }

    public override void grow()
    {
        if (curGrowth < maxGrowth)
        {
            curGrowth++;
            transform.localScale *= growthSpeed;
        } else
        {
            Debug.Log("Can't grow further!");
        }
    }
    
    public void grow(int stages)
    {
        if (curGrowth + stages < maxGrowth)
        {
            curGrowth += stages;
            transform.localPosition *= (stages * growthSpeed);
        } else
        {
            Debug.Log("Can't grow that many stages!");
        }
    }
}
