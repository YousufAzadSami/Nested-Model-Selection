using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    public Material mMaterial;

	// Use this for initialization
	void Start () {
        mMaterial = GetComponent<Renderer>().material;
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


    }
}
