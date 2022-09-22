using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrass : MyPlant
{
    [SerializeField]
    private GameObject grassPrefab;
    private readonly float spawnRange;

    public override string CommonName
    {
        get { return "Grass"; }
    }

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
        float seedlings = Random.Range(0, 5);
        for (int i = 0; i < seedlings; i++)
        {
            float x = transform.position.x + Random.Range(-spawnRange, spawnRange);
            float z = transform.position.z + Random.Range(-spawnRange, spawnRange);
            float rotY = Random.Range(0f, 1f);
            Instantiate(grassPrefab, new Vector3(x, 0, z), Quaternion.Euler(0, rotY, 0));
        }
        
    }
}