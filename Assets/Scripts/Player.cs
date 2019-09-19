﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMode
{
	NONE,
	TELEPORT,
	WALK,
	FURNITURE,
	TRANSLATE,
	ROTATE,
	SCALE
}

public class Player : MonoBehaviour {

public static Player instance;
public InputMode activeMode = InputMode.NONE;
public Object activeFurniturePrefab;

[SerializeField]
private float playerSpeed = 2.0f;

public GameObject leftWall;
public GameObject rightWall;
public GameObject forwardWall;
public GameObject backWall;
public GameObject ceiling;
public GameObject floor;

	void Awake() {
		if (instance != null)
		{
			GameObject.Destroy(instance.gameObject);
		}
		instance = this;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		TryWalk();
	}

	public void TryWalk() {
		if (Input.GetMouseButton(0) && activeMode == InputMode.WALK)
		{
				Vector3 forward = Camera.main.transform.forward;

				Vector3 newPosition = transform.position + forward * Time.deltaTime * playerSpeed;

				if (newPosition.x < rightWall.transform.position.x - 1 && newPosition.x > leftWall.transform.position.x + 1 &&
						newPosition.y < ceiling.transform.position.y -1 && newPosition.y > floor.transform.position.y + 1 &&
						newPosition.z > backWall.transform.position.z - 1 && newPosition.z < forwardWall.transform.position.z + 1)
				{
					transform.position = newPosition;
				}
		}
	} //TryWalk
}
