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

    public string m_color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
