using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyPlant : MonoBehaviour
{
    public abstract string CommonName { get; }
    [SerializeField]
    protected Material decaying;

    public abstract void grow();
    public void kill()
    {
        // set new color for all child-objects
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().material = decaying;
        }
        /*
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = m_decaying;
        }*/
        StartCoroutine(die(5));
    }

    private IEnumerator die(int secs)
    {
        yield return new WaitForSeconds(secs);
        GameObject.Destroy(gameObject);
    }
}
