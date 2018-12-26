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
			// all selectable GameObjects should have the same transformation mode. 
			// If the user selects the translate button for one object then, 
			// selects another object user would expect it to tranlate as well
			TransformationAndHighlight[] allSelectableGameObjects = mouseClickSelection.FindAllSelectableGameObjects();
			foreach(TransformationAndHighlight selectableGameObject in allSelectableGameObjects)
			{
				selectableGameObject.ChangeModes(true, false, false);
			}
		}
		else 
		{
			Debug.LogError("Something is wrong, check comment", mouseClickSelection.GetSelectedGameObject());
		}
	}
}
