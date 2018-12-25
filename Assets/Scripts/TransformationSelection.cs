using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationSelection : MonoBehaviour {

	private GameObject selectedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setSelectedObject(GameObject inSelectedObject)
	{
		selectedObject = inSelectedObject;
	}
}
