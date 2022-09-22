using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFlower : MyPlant
{
    private int growthAttempts = 0;

    public override string CommonName
    {
        get { return "Flower"; }
    }

    public override void grow()
    {
        growthAttempts++;
        if (growthAttempts >= 3)
        {
            kill();
        }
    }
}
