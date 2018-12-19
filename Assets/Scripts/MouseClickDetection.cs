using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickDetection : MonoBehaviour {

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        RaycastHit rayCastHit;


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out rayCastHit))
            {
                Debug.Log(rayCastHit.transform.name);

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

                // for the newly made script "TransformationAndHighlight"; does the same thing as above block of code
                TransformationAndHighlight _transformationAndHighlightScript = rayCastHit.transform.GetComponent<TransformationAndHighlight>();
                if (_transformationAndHighlightScript)
                {
                    _transformationAndHighlightScript.ChangeSelectedStatus();
                }
                else
                {
                    Debug.Log("TransformationAndHighlight script not found");
                }
            }
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
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
}
