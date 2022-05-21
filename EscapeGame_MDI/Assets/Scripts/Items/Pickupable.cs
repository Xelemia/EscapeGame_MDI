﻿using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {
	[SerializeField] private Vector3 DOF = new Vector3(1,1,1);
	[SerializeField] private float maxDist;
	private bool pickedUp;
	private Transform cam;
	// Use this for initialization
	void Start () {
		pickedUp = false;
		cam = GameObject.FindWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public Vector3 getDOF()
    {
		return DOF;
    }

	public bool isCloseEnough(Vector3 pos)
    {

		return (Vector3.Distance(transform.position, pos)<=maxDist);
    }

	public void isPickedUp(bool b)
    {
		pickedUp = b;
    }

    private void OnMouseOver()
    {
		if (GetComponent<Outline>() != null)
		{
			if (pickedUp)
			{
				GetComponent<Outline>().enabled = false;
			}
			else if ((Vector3.Distance(transform.position, cam.position) <= maxDist) && GetComponent<Outline>().enabled == false)
			{
				GetComponent<Outline>().enabled = true;
			}
			else if (GetComponent<Outline>().enabled == true && (Vector3.Distance(transform.position, cam.position) > maxDist))
			{
				GetComponent<Outline>().enabled = false;
			}
		}
	}

    private void OnMouseExit()
    {
		if (GetComponent<Outline>() != null)
		{
			if (pickedUp)
			{
				GetComponent<Outline>().enabled = false;
			}
			else if (GetComponent<Outline>().enabled == true)
			{
				GetComponent<Outline>().enabled = false;
			}
		}
	}
}
