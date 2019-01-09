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

	// Child object
	Transform axisControl;

	private MouseClickDetection mouseClickDetection;

	void Awake () {
		// not the best of soulution, but will go with the adhoc approach for now
		mouseClickDetection = FindObjectOfType<MouseClickDetection>();

		if(mouseClickDetection == null)
		{
			Debug.LogError("mouseClickSelection NOT FOUND!!!");
		}

		// set the child gameobject with the name "AxisControl"
		axisControl = transform.Find("AxisControl");
		if(axisControl == null)
		{
			Debug.LogError("Child(AxisControl) not found");
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
		// disable all other transformation related UI when one is selected
		// for example, if "Translate" mode is selected, disable "Rotate" and "Scale"
		DisableOtherTransformationUI();

		SetTransformationModeInGameobjects(inTransformationMode);

		// sets the child(AxisControl) uis active 
		axisControl.gameObject.SetActive(true);
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

	private void SetTransformationModeInGameobjects(int inTransformationMode)
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

	private void DisableOtherTransformationUI()
	{
		Transform parent = this.transform.parent;
		
		// iterating over all the children of the parent 
		// in other words, iterating over all the siblings in this case 
		// since it's run from the sibilings GameObject
		for(int i = 0; i < parent.childCount; i++)
		{
			GameObject child = parent.GetChild(i).gameObject;
			if(child.GetInstanceID() != this.gameObject.GetInstanceID())
			{
				child.SetActive(false);
			}
		}
	}

	public void SetUpUiUponObjectSelection()
	{
		this.gameObject.SetActive(true);
		axisControl.gameObject.SetActive(false);
	}
}
