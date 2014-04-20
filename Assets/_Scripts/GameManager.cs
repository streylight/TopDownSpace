using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI ()
    {
        //Create a button that returns true or false
        if (GUI.Button(new Rect (Screen.width/2, Screen.height/2, 100, 100), "Start"))
        {
            //Open a new scene
            Application.LoadLevel("MenuScreen");
        }
    }
}
