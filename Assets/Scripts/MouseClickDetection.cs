using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickDetection : MonoBehaviour
{

    private Camera camera;
    private Ray ray;
    private RaycastHit rayCastHit;

    // UI references. When an object is selected, show them
    // Currently going with adhoc approach
    public Button translate;
    public Button rotate;

    private GameObject selectedGameObject;

    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out rayCastHit))
            {
                // Debug.Log(rayCastHit.transform.name);

                // ChangeMaterialRelatedStuff();


                // for the newly made script "TransformationAndHighlight"; does the same thing as above block of code
                selectedGameObject = rayCastHit.transform.gameObject;
                TransformationAndHighlight _transformationAndHighlightScript = rayCastHit.transform.GetComponent<TransformationAndHighlight>();
                if (_transformationAndHighlightScript)
                {
                    SelectObjectRelatedStuff(_transformationAndHighlightScript);

                    // if any GameObject is selected, enable the related UIs as well and vice versa
                    SetActiveUI(_transformationAndHighlightScript.SelectedStatus());
                }
                else
                {
                    Debug.Log("TransformationAndHighlight script not found");
                }
            }
        }
    }

    // Unselect all other GameObject, Select the GameObject
    // Or just unselect the already clicked selected GameObject
    private void SelectObjectRelatedStuff(TransformationAndHighlight inTransformationAndHighlightScript)
    {
        // if the object is already selected, then we just need to unselect it
        // no need to go unselect every object in the scene
        if (inTransformationAndHighlightScript.SelectedStatus() == false)
        {
            // unselect all, then select the object so that only
            // one object is selected at a time
            UnSelectAll();
        }

        // then select/unselect the current object
        inTransformationAndHighlightScript.ChangeSelectedStatus();

        // if the object is selected, then set it to variable selectedGameObject
        // if unselected, set it to null
        if (inTransformationAndHighlightScript.SelectedStatus())
        {
            // it was already set at the start
        }
        else
        {
            selectedGameObject = null;
        }
    }

    public void UnSelectAll()
    {
        // this is not the optimal way of doing things, need optimization later (like tagging objects)
        TransformationAndHighlight[] _allSelectableObjects = FindAllSelectableGameObjects();

        foreach (TransformationAndHighlight _selectableObject in _allSelectableObjects)
        {
            // Debug.Log("Name : " + _selectableObject.transform.name);
            _selectableObject.Unselect();
        }
    }

    private void SetActiveUI(bool inActive)
    {
        translate.gameObject.SetActive(inActive);
        rotate.gameObject.SetActive(inActive);
    }

    public GameObject GetSelectedGameObject()
    {
        return selectedGameObject;
    }

    // Returns all the TransformationAndHighlight component of the selectable objects
    // TODO : Return the whole gameobject for more flexibility
    public TransformationAndHighlight[] FindAllSelectableGameObjects()
    {
        return FindObjectsOfType<TransformationAndHighlight>();
    }

    // for the script "ChangeMaterial", currently obsolete
    private void ChangeMaterialRelatedStuff()
    {
        ChangeMaterial _changeMaterial = rayCastHit.transform.GetComponent<ChangeMaterial>();
        if (_changeMaterial)
        {
            _changeMaterial.DoSomeHighlightStuff();
        }
        else
        {
            Debug.Log("Change Material not found");
        }
    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = camera.pixelHeight - currentEvent.mousePosition.y;

        point = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + camera.pixelWidth + ":" + camera.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
}