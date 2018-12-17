using Assets.SeaBattle.Scripts.Utils;
using Assets.SeaBattle.Scripts.Utils.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHolderManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Messenger.Subscribe<GridCreationMessage>(OnRequestCreation);
	}

    private void OnRequestCreation(GridCreationMessage message)
    {
        throw new NotImplementedException();
    }
}
