using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CraftingLegends.ExtendedFramework
{
	/// <summary>
	/// sets the Animator to a random speed value
	/// </summary>
	public class RandomAnimationSpeed : MonoBehaviour
	{
		[SerializeField]
		private float _fromSpeed = 0.9f;

		[SerializeField]
		private float _toSpeed = 1.1f;

		// ================================================================================
		//  unity methods
		// --------------------------------------------------------------------------------

		private void Start()
		{
			Animator animator = GetComponent<Animator>();
			if (animator != null)
			{
				if (!animator.isInitialized)
				{
					animator.Rebind();
				}

				animator.speed = UnityEngine.Random.Range(_fromSpeed, _toSpeed);
			}
		}
	}
}