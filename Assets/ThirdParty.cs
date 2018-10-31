using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdParty : MonoBehaviour {

    public MouseDownTest mVar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");

            if(mVar)
            {
                mVar.DisplayName();
            }
        }
	}
}
