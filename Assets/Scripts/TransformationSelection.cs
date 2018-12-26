using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationSelection : MonoBehaviour {

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
		// The button/s should be visible only when an object is selected
		// And if an object is selelcted, then this condition should be true
		// In other words, this condition should always be true
		if(mouseClickSelection.GetSelectedGameObject())
		{
			mouseClickSelection.GetSelectedGameObject().GetComponent<TransformationAndHighlight>().ChangeModes(true, false, false);
		}
		else 
		{
			Debug.LogError("Something is wrong, check comment", mouseClickSelection.GetSelectedGameObject());
		}
	}
}
