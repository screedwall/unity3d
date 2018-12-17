using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIGame : MonoBehaviour
{
    public Button Settings;
    public Button Back;

    // Use this for initialization
    void Start()
    {
        Back.onClick.AddListener(() => GUIHandler.SceneSwitcher(0));
        Settings.onClick.AddListener(() => GUIHandler.SceneSwitcher(2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
