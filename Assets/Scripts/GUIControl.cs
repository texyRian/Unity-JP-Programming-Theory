using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GUIControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject curSpawnPlant;
    private GameObject curSelectedPlant;
    private bool mouseOnGUI = false;

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
    [SerializeField]
    private GameObject selectorPrefab;
    [SerializeField]
    private TMPro.TMP_InputField growStagesInput;
    [SerializeField]
    private GameObject plantPanel;

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
        if (!mouseOnGUI)
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                MyPlant plant = hit.collider.GetComponentInParent<MyPlant>();
                GameObject selectedObject = hit.collider.gameObject;
                // Debug.Log(hit.collider.gameObject.name);

                if (plant != null)
                {
                    // plant hit
                    // update selector location and scale
                    updateSelector(selectedObject);
                    curSelectedPlant = selectedObject;
                    // open plant GUI

                    plantPanel.SetActive(true);
                    TMPro.TMP_Text selectedText = plantPanel.transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
                    selectedText.text = "Selected: " + curSelectedPlant.name.Replace("(Clone)","");

                    if (selectedObject.name.StartsWith("Tree"))
                    {
                        plantPanel.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    else
                    {
                        plantPanel.transform.GetChild(3).gameObject.SetActive(false);
                    }
                }
                else
                {
                    // deselect
                    // remove selector
                    selectorPrefab.SetActive(false);
                    curSelectedPlant = null;
                    // close plant GUI
                }
            }      
        }
    }

    // right mouse button for planting
    private void rightClick()
    {
        if (!mouseOnGUI)
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
    }

    private void updateSelector(GameObject selected)
    {
        if (selected.name.StartsWith("Tree"))
        {
            Vector3 newScale = new Vector3();
            newScale.x = selected.transform.GetChild(0).localScale.x + 1;
            newScale.y = 0.1f;
            newScale.z = selected.transform.GetChild(0).localScale.z + 1;
            selectorPrefab.transform.localScale = newScale;
        }
        else
        {
            selectorPrefab.transform.localScale = new Vector3(1, 0.1f, 1);
        }
        selectorPrefab.transform.position = selected.transform.position;
        selectorPrefab.SetActive(true);
    }

    public void selectTree()
    {
        curSpawnPlant = treePrefab;
    }

    public void selectFlower()
    {
        curSpawnPlant = flowerPrefab;
        // TODO: make color selection
    }

    public void selectGrass()
    {
        curSpawnPlant = grassPrefab;
    }

    private void spawnPlant(Vector3 spawnPoint)
    {
        if (curSpawnPlant != null)
        {
            GameObject instantiatedPlant = Instantiate(curSpawnPlant, spawnPoint, curSpawnPlant.transform.rotation);

            // change flower color if applicable
            if (curSpawnPlant.name.Equals("Flower"))
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

    public void killPlant()
    {
        if (curSelectedPlant != null)
        {
            curSelectedPlant.GetComponent<MyPlant>().kill();
        }
    }

    public void growPlant()
    {
        if (curSelectedPlant != null)
        {
            if (curSelectedPlant.name.StartsWith("Tree")) 
            {
                if (growStagesInput.text != null && growStagesInput.text != "")
                {
                    int stages = int.Parse(growStagesInput.text);
                    curSelectedPlant.GetComponent<MyTree>().grow(stages);
                    return;
                }
            }
            curSelectedPlant.GetComponent<MyPlant>().grow();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOnGUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOnGUI = false;
    }
}
