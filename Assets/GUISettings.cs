using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUISettings : MonoBehaviour {
    public Slider Volume;
    public Slider Quality;
    public Slider Scale;
    public Button Back;

	// Use this for initialization
	void Start () {
        Back.onClick.AddListener(() => GUIHandler.SceneSwitcher(0));
        Quality.onValueChanged.AddListener(QualityChanger);
        Scale.onValueChanged.AddListener(GUIHandler.ScaleChange);
	}
	
	// Update is called once per frame
    public void QualityChanger(float value)
    {
        QualitySettings.SetQualityLevel(Convert.ToInt32(value), false);
    }
}
