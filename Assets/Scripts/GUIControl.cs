using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    private GameObject curSelectedPlant;
    // TODO: implement color selection
    [SerializeField]
    private Material curSelectedColor;
    [SerializeField]
    private Camera gameCamera;

    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private GameObject flowerPrefab;
    [SerializeField]
    private GameObject grassPrefab;

    //[SerializeField]
    //private Plane groundPlane;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
           
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            leftClick();
        } else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rightClick();
        }
    }

    // left mouse button for selecting existing plant
    private void leftClick()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            MyPlant plant = hit.collider.GetComponentInParent<MyPlant>();
            // Debug.Log(hit.collider.gameObject.name);

            if (plant != null)
            {
                // plant hit
                // open gui 
                Debug.Log("Plant hit!");
                plant.grow();
            } else
            {
                Debug.Log("No plant hit!");
            }
        }
        // get intersection with mouse ray and gameobject
    }

    // right mouse button for planting
    private void rightClick()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name.Equals("Ground"))
            {
                spawnPlant(hit.point);
            }
        }
    }

    public void selectTree()
    {
        curSelectedPlant = treePrefab;
    }

    public void selectFlower()
    {
        curSelectedPlant = flowerPrefab;
        // TODO: make color selection
    }

    public void selectGrass()
    {
        curSelectedPlant = grassPrefab;
    }

    private void spawnPlant(Vector3 spawnPoint)
    {
        if (curSelectedPlant != null)
        {
            GameObject instantiatedPlant = Instantiate(curSelectedPlant, spawnPoint, curSelectedPlant.transform.rotation);

            // change flower color if applicable
            if (curSelectedPlant.name.Equals("Flower"))
            {
                foreach (Transform child in instantiatedPlant.transform)
                {
                    if (child.gameObject.name.StartsWith("Flower"))
                    {
                        child.GetComponent<Renderer>().material = curSelectedColor;
                    }
                }
            }
        }
    }
}
