using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvas : MonoBehaviour {

	public GazeableButton currentButton;

	public Color unselectColor = Color.white;
	public Color selectColor = Color.green;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetActiveButton(GazeableButton activeButton)
	{
		//If there was a previous active button, disable it
		if (currentButton != null)
		{
			currentButton.SetButtonColor(unselectColor);
		}

		//If a new button is selected, make it current button
		if (currentButton != activeButton && activeButton != null)
		{
			currentButton = activeButton;
			currentButton.SetButtonColor(selectColor);
		}

		else
		{
			Debug.Log("Resetting");
			currentButton = null;
			Player.instance.activeMode = InputMode.NONE;
		}

	} //end SetActiveButton

}
