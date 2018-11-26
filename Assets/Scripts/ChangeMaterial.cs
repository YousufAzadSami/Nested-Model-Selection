using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    public Material mMaterial;

    private Color originalColor;
    private Color highlightColor;

    // Use this for initialization
    void Start () {
        mMaterial = GetComponent<Renderer>().material;

        originalColor = mMaterial.color;
        highlightColor = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DoSomeHighlightStuff();
        }
	}

    public void DoSomeHighlightStuff()
    {
        Debug.Log("In DoSomeHighlightStuff()");

        if (mMaterial.color == originalColor)
        {
            mMaterial.color = highlightColor;
        }
        else
        {
            mMaterial.color = originalColor;
        }

    }
}
