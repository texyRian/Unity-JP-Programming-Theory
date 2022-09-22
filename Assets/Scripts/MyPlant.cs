using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyPlant : MonoBehaviour
{
    public abstract string CommonName { get; }
    [SerializeField]
    protected Material m_decaying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void grow();
    public void kill()
    {
        // set new color for all child-objects
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = m_decaying;
        }
        StartCoroutine(die(5));
    }

    private IEnumerator die(int secs)
    {
        yield return new WaitForSeconds(secs);
        GameObject.Destroy(gameObject);
    }
}
