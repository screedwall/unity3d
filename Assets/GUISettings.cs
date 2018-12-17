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
        Volume.onValueChanged.AddListener(VolumeChanger);
        Quality.onValueChanged.AddListener(GUIHandler.QualityChanger);
        Scale.onValueChanged.AddListener(GUIHandler.ScaleChange);
	}

    public void VolumeChanger(float value)
    {
        Volume.GetComponent<AudioSource>().volume = value;
    }
	// Update is called once per frame
    
    
}
