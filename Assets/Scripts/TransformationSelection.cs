using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationSelection : MonoBehaviour {

	enum TransformationMode 
	{
		Translate,
		Rotate,
		Scale
	}

	private MouseClickDetection mouseClickDetection;

	void Awake () {
		// not the best of soulution, but will go with the adhoc approach for now
		mouseClickDetection = FindObjectOfType<MouseClickDetection>();

		if(mouseClickDetection == null)
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

	public void ChangeTranformationMode(int inTransformationMode)
	{
		bool translate, rotate, scale;
		SetTransformationModeFlags(inTransformationMode, out translate, out rotate, out scale);
		// set the boolen values for transformation mode 

		// The button/s should be visible only when an object is selected
		// And if an object is selelcted, then this condition should be true
		// In other words, this condition should always be true
		if(mouseClickDetection.GetSelectedGameObject())
		{
			// all selectable GameObjects should have the same transformation mode. 
			// If the user selects the translate button for one object then, 
			// selects another object user would expect it to tranlate as well
			TransformationAndHighlight[] allSelectableGameObjects = mouseClickDetection.FindAllSelectableGameObjects();
			foreach(TransformationAndHighlight selectableGameObject in allSelectableGameObjects)
			{
				selectableGameObject.ChangeModes(translate, rotate, scale);
			}
		}
		else 
		{
			Debug.LogError("Something is wrong, check comment", mouseClickDetection.GetSelectedGameObject());
		}
	}

	private void SetTransformationModeFlags(
		int inTransformationMode, out bool inTranslate, out bool inRotate, out bool inScale)
	{
		inTranslate = inRotate = inScale = false;

		if (inTransformationMode == (int)TransformationMode.Translate)
        {
            inTranslate = true;
        }
        else if (inTransformationMode == (int)TransformationMode.Rotate)
        {
			inRotate = true;
        }
        else if (inTransformationMode == (int)TransformationMode.Scale)
        {
			inScale = true;
        }
		else 
		{
			Debug.LogError("Invalid state");
		}
	}
}
