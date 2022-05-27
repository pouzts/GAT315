using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffector : MonoBehaviour
{
	[SerializeField][Range(-10, 10)] float strength = 5;
	public Water water = null;

	void Update()
	{
		if (Input.GetButton("Fire1"))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			water.Touch(ray, strength);
		}
	}
}
