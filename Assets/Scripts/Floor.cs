using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : GazeableObjects {

	public override void OnPress(RaycastHit hitInfo)
	{
		base.OnPress(hitInfo);

		if (Player.instance.activeMode == InputMode.TELEPORT)
		{
			Vector3 destLocation = hitInfo.point;
			destLocation.y = Player.instance.transform.position.y;
			Player.instance.transform.position = destLocation;
		} //end if

		else if (Player.instance.activeMode == InputMode.FURNITURE) {
			//create the FURNITURE
			GameObject placedFurniture = GameObject.Instantiate(Player.instance.activeFurniturePrefab) as GameObject;
			//place the furniture
			placedFurniture.transform.position = hitInfo.point;
		} //end else if

	} //OnPress
} //Floor
