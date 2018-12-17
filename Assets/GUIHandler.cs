using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIHandler : MonoBehaviour {
    public Button Play;
    public Button Sound;
    public Button About;
    public Button Settings;
    public Button Exit;


	// Use this for initialization
	void Start () {
        Play.onClick.AddListener(() => SceneSwitcher(3));
        Settings.onClick.AddListener(() => SceneSwitcher(2));
        Exit.onClick.AddListener(Application.Quit);
	}

    static public void SceneSwitcher(int sceneId)
    {
        SceneManager.LoadScene(sceneId, LoadSceneMode.Single);
    }
    static public void QualityChanger(float value)
    {
        QualitySettings.SetQualityLevel(Convert.ToInt32(value), false);
    }
    public static void ScaleChange(float value)
    {
        EventHandler.scale *= value;
        GameObject game = GameObject.Find("GameObject");
        if(game!=null)
            game.GetComponent<Transform>().localScale = new Vector3(1f * EventHandler.scale, 1f * EventHandler.scale, 1f * EventHandler.scale);
    }

	// Update is called once per frame
	void Update () {
        
	}
}
