using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObjects : MonoBehaviour {


	public bool isTransformable = false;
	/**
	* Behaviour when gaze System falls on object
	**/
	// Virtual means this methods can be overriden by a child
	public virtual void OnGazeEnter(RaycastHit hitInfo)
  {
		Debug.Log("Gaze entered on " + gameObject.name);
	} //end OnGazeEnter

	/**
	* Behaviour when gaze system is held on gameObject
	**/
	public virtual void OnGaze(RaycastHit hitInfo)
	{
		Debug.Log("Gaze hold on " + gameObject.name);
	} //end OnGaze

	/**
	* Behaviour when gaze system leaves gameObject
	**/
	public virtual void OnGazeExit()
	{
		Debug.Log("Gaze exited on " + gameObject.name);
	} //end OnGazeExit

	/**
	* When mouse is pressed
	**/
	public virtual void OnPress(RaycastHit hitInfo)
	{
		Debug.Log("Button Pressed");
	} //end OnPress

	/**
	* When mouse is on Hold
	**/
	public virtual void OnHold(RaycastHit hitInfo)
	{
		Debug.Log("Button held");

		if (isTransformable)
		{
			GazeTransform(hitInfo);
		}
	} //end OnHold

	/**
	* when mouse is released
	**/
	public virtual void OnRelease(RaycastHit hitInfo)
	{
		Debug.Log(" Button Released ");
	} //end OnRelease

	public virtual void GazeTransform(RaycastHit hitInfo)
	{
		//call the correct transformation function
		switch(Player.instance.activeMode)
		{
			case InputMode.TRANSLATE:
				GazeTranslate(hitInfo);
				break;

			case InputMode.ROTATE:
				GazeRotate(hitInfo);
				break;

			case InputMode.SCALE:
			 	GazeScale(hitInfo);
				break;
		} //end switch
	} //end GazeTransform

	/**
	*
	*/
	public virtual void GazeTranslate(RaycastHit hitInfo)
	{
		//move the object (position)
		if (hitInfo.collider != null && hitInfo.collider.GetComponent<Floor>())
		{
			transform.position = hitInfo.point;
		} //end if
	}

	public virtual void GazeRotate(RaycastHit hitInfo)
	{
		//change the objects orientation
	}

	public virtual void GazeScale(RaycastHit hitInfo)
	{
		//Make the object bigger/smaller (Scale)
	}

} //end GazeableObjects
