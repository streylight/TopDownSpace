using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    //Remove this when we have stuff
    private Font _logoFont;
    private GUIStyle _logoStyle;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI ()
    {        
        //GUI.skin.font = _logoFont;
        _logoStyle.fontSize = Screen.width / 20;
        _logoStyle.alignment = TextAnchor.MiddleCenter;        

        GUILayout.BeginArea(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - 100, Screen.width / 2, 200));
            GUILayout.Label("TopDownSpace",_logoStyle);

            GUILayout.Space(15);

            //Create a button that returns true or false
            if (GUILayout.Button("Start"))
            {
                //Open a new scene
                Application.LoadLevel("MenuScreen");
            }
        GUILayout.EndArea();
    }
}
