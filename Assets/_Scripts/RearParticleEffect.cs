﻿using System;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RearParticleEffect : MonoBehaviour {
	
	// this script controls the jet's exhaust particle system, controlling the
	// size and colour based on the jet's current throttle value.
	
	
	public Color minColour;                             // The base colour for the effect to start at
	
	private ShipController jet;                    // The jet that the particle effect is attached to
	private ParticleSystem system;                      // The particle system that is being controlled
	private float originalStartSize;                    // The original starting size of the particle system
	private float originalLifetime;                     // The original lifetime of the particle system
	private Color originalStartColor;                   // The original starting colout of the particle system
	
	// Use this for initialization
	void Start () {
		
		// get the aeroplane from the object hierarchy
		jet = FindAeroplaneParent();
		
		// get the particle system ( it will be on the object as we have a require component set up
		system = GetComponent<ParticleSystem>();
		
		// set the original properties from the particle system
		originalLifetime = system.startLifetime;
		originalStartSize = system.startSize;
		originalStartColor = system.startColor;
	}
	
	
	// Update is called once per frame
	void Update () {
		if (jet.reverse) {
			// update the particle system based on the jets throttle
			system.startLifetime = Mathf.Lerp (0.0f, originalLifetime, jet.ThrottleInput);
			system.startSize = Mathf.Lerp (originalStartSize * .3f, originalStartSize, jet.ThrottleInput);
			system.startColor = Color.Lerp (minColour, originalStartColor, jet.ThrottleInput);
		} else {
			system.startLifetime = 0.0f;
			system.startSize = 0.0f;
		}
	}
	
	
	ShipController FindAeroplaneParent()
	{
		// get reference to the object transform
		var t = transform;
		
		// traverse the object hierarchy upwards to find the AeroplaneController
		// (since this is placed on a child object)
		while (t != null)
		{
			var aero = t.GetComponent<ShipController>();
			if (aero == null) {
				// try next parent
				t = t.parent;
			} else {
				return aero;
			}
		}
		
		// controller not found!
		throw new Exception(" AeroplaneContoller not found in object hierarchy");
	}
}
