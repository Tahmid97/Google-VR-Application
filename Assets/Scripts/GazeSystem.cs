using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystem : MonoBehaviour {

	public GameObject reticle;

	public Color inactiveColor = Color.gray;

	public Color activeColor = Color.green;

	private GazeableObjects currentGazeObject;

	private GazeableObjects currentSelectedObject;

	private RaycastHit lastHit;

	// Use this for initialization
	void Start () {
			ChangeColor(inactiveColor);
	}

	// Update is called once per frame
	void Update () {
		ProcessGaze();
		CheckForInput(lastHit);
	}

  public void ProcessGaze()
	{
		/*A ray is an infinite line starting at origin and going in
			some direction.
			It has two properties:
			1. origin
			2. direction
			*/
			// Create a ray from the transform position along the transform's z-axis
		Ray rayCastRay = new Ray(transform.position, transform.forward);
		//Structure used to get information back from a raycast.
		RaycastHit hitInfo;

		/*
			DrawRay(start, direction & length);
		*/
		Debug.DrawRay(rayCastRay.origin, rayCastRay.direction * 100);

		if (Physics.Raycast(rayCastRay, out hitInfo))
		{
				//1.do something to the object
				//2.check if that object is interactable
				//3.Get the game Object from the hitInfo
				GameObject hitObj = hitInfo.collider.gameObject;
				//4.Get the gameObject from the hit info
				GazeableObjects gazeObj = hitObj.GetComponentInParent<GazeableObjects>();
				//5.Object has gazeable Component
				if (gazeObj != null)
				{
						//Object we are looking at is different
						if(gazeObj != currentGazeObject)
						{
								ClearCurrentObject();
								currentGazeObject = gazeObj;
								currentGazeObject.OnGazeEnter(hitInfo);
								ChangeColor(activeColor);
						} //end if
						else
						{
								currentGazeObject.OnGaze(hitInfo);
						}
				} //end outer if
				else {
					ClearCurrentObject();
				} //end outer else

						lastHit = hitInfo;
		} //end if

		else {
			ClearCurrentObject();
		}
	} //end ProcessGaze

	private void ChangeColor(Color reticleColor)
	{
		//public void SetColor(string name, Color value);
		reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
	} //end ChangeColor

	private void CheckForInput(RaycastHit hitInfo)
	{
		//check when pressed
		if(Input.GetMouseButtonDown(0) && currentGazeObject != null)
		{
			currentSelectedObject = currentGazeObject;
			currentSelectedObject.OnPress(hitInfo);
		} //end if

		//check when held
		else if (Input.GetMouseButton(0) && currentSelectedObject != null)
		{
			currentSelectedObject.OnHold(hitInfo);
		}
		//check when released
		else if (Input.GetMouseButtonUp(0) && currentSelectedObject != null)
		{
			currentSelectedObject.OnRelease(hitInfo);
			currentSelectedObject = null;
		}

	} //end CheckForInput

	private void ClearCurrentObject()
	{
		if(currentGazeObject != null)
		{
			currentGazeObject.OnGazeExit();
			ChangeColor(inactiveColor);
			currentGazeObject = null;
		} //end if
	} //end ClearCurrentObject

} //end GazeSystem
