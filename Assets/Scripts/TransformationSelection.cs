using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationSelection : MonoBehaviour {

	public GameObject selectedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeTranformationMode()
	{
		selectedObject.GetComponent<TransformationAndHighlight>().ChangeModes(true, false, false);
	}

	public void SetSelectedObject(GameObject inSelectedObject)
	{
		Debug.Log("InSelectedObject: " + inSelectedObject.name);
		// Debug.Log("SelectedObject: " + selectedObject.name);
		selectedObject = inSelectedObject;
		Debug.Log("InSelectedObject: " + inSelectedObject.name);
		Debug.Log("SelectedObject: " + selectedObject.name);
	}
}
