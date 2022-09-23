using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTree : MyPlant
{
    // maximum total size achievable as compared to prefab
    private float maxGrowth;
    private float curGrowth;

    private void Start()
    {
        maxGrowth = Random.Range(1f, 4f);
        curGrowth = (maxGrowth - 1) / 2;
    }

    public override string CommonName
    {
        get { return "Tree"; }
    }

    public override void grow()
    {
        transform.localScale += Vector3.one * curGrowth;
        curGrowth /= 2;
    }
    
    public void grow(int stages)
    {
        for (int i = 0; i < stages; i++)
        {
            grow();
        }
    }
}
