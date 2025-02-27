﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnim : MonoBehaviour {
	public float amplitude = 0.5f;
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	// Use this for initialization
	void Start () {
		posOffset = transform.position;
	}

	// Update is called once per frame
	void Update () {
		tempPos = posOffset;
		tempPos.y += Mathf.Sin (Time.time * Mathf.PI) * amplitude;
		transform.position = tempPos;
	}
}
