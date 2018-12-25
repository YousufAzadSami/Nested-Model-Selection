using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickDetection : MonoBehaviour {

    private Camera cam;
    private Ray ray;

    // UI references. When an object is selected, show them
    // Currently going with adhoc approach
    public Button translate;
    public Button rotate;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit rayCastHit;


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out rayCastHit))
            {
                // Debug.Log(rayCastHit.transform.name);
                
                /*
                // for the script "ChangeMaterial"
                ChangeMaterial _changeMaterial = rayCastHit.transform.GetComponent<ChangeMaterial>();
                if (_changeMaterial)
                {
                    _changeMaterial.DoSomeHighlightStuff();
                }
                else
                {
                    Debug.Log("Change Material not found");
                }
                */

                // for the newly made script "TransformationAndHighlight"; does the same thing as above block of code
                GameObject selectedGameObject = rayCastHit.transform.gameObject;
                TransformationAndHighlight _transformationAndHighlightScript = rayCastHit.transform.GetComponent<TransformationAndHighlight>();
                if (_transformationAndHighlightScript)
                {
                    // if the object is already selected, then we just need to unselect it
                    // no need to go unselect every object in the scene
                    if(_transformationAndHighlightScript.SelectedStatus() == false)
                    {
                        // unselect all, then select the object so that only
                        // one object is selected at a time
                        UnSelectAll();
                    }
                    
                    // then select the current object
                    _transformationAndHighlightScript.ChangeSelectedStatus();

                    // if any GameObject is selected, enable the related UIs as well and vice versa
                    SetActiveUI(_transformationAndHighlightScript.SelectedStatus());

                    // if the object is selected, then let the Translate & Rotate button
                    // know which object was selected
                    if(_transformationAndHighlightScript.SelectedStatus())
                    {
                        SetSelectedGameObjectInButtions(selectedGameObject);
                    }
                }
                else
                {
                    Debug.Log("TransformationAndHighlight script not found");
                }
            }
        }
    }

    public void UnSelectAll()
    {
        // this is not the optimal way of doing things, need optimization later (like tagging objects)
        TransformationAndHighlight[] _allSelectableObjects = FindObjectsOfType<TransformationAndHighlight>();
        
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

    private void SetSelectedGameObjectInButtions(GameObject inGameObject)
    {
        translate.GetComponent<TransformationSelection>().SetSelectedObject(inGameObject);
        // rotate.GetComponent<TransformationSelection>().SetSelectedObject(inGameObject);
    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
}
