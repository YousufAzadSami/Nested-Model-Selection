using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationSelection : MonoBehaviour {

	public GameObject selectedObject;
	public MouseClickDetection mouseClickSelection;

	void Awake () {
		// not the best of soulution, but will go with the adhoc approach for now
		mouseClickSelection = FindObjectOfType<MouseClickDetection>();

		if(mouseClickSelection == null)
		{
			Debug.LogError("mouseClickSelection NOT FOUND!!!");
		}
	}

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
		selectedObject = inSelectedObject;
	}
}
