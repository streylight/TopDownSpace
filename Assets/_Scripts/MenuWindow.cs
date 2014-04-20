using UnityEngine;
using System.Collections;

public class MenuWindow : MonoBehaviour {
    private bool openMenu = false;
    public Rect menuWindow;
    private int windowWidth = 200;
    private int windowHeight = 200;

    private Vector3 screenPosition;
	// Use this for initialization
	void Start () {
        menuWindow = new Rect(Screen.width / 2 - windowWidth / 2, Screen.height / 2 - windowHeight / 2, windowWidth, windowHeight);
	}
	
	// Update is called once per frame
    void Update()
    {
        openMenu = Input.GetMouseButton(1);
    }

    void OnGUI ()
    {
        if(openMenu){
            menuWindow = GUILayout.Window(0,menuWindow,DoOpenMenu,"");
        }
    }

    void DoOpenMenu(int windowID)
    {
        if (GUILayout.Button("Play Game"))
        {
            Application.LoadLevel("GameScreen");
        }
        if (GUILayout.Button("Options"))
        {

        }
    }
}
