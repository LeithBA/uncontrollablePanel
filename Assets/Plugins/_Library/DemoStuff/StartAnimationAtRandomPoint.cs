using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CraftingLegends.ExtendedFramework
{
	/// <summary>
	/// initializes Mecanim animation to random starting point
	/// </summary>
	public class StartAnimationAtRandomPoint : MonoBehaviour
	{
		// ================================================================================
		//  unity methods
		// --------------------------------------------------------------------------------

		private void Start()
		{
			float scale = Random.Range(0, 1f);

			SetAnimationToPoint(scale);
		}

		// ================================================================================
		//  private methods
		// --------------------------------------------------------------------------------

		private void SetAnimationToPoint(float scale)
		{
			Animator animator = GetComponentInChildren<Animator>();
			if (animator != null)
			{
				if (!animator.isInitialized)
				{
					animator.Rebind();
				}

				// manually update the Animator to a random point in current animation
				if (animator != null)
				{
					var clips = animator.GetCurrentAnimatorClipInfo(0);
					if (clips != null && clips.Length > 0)
					{
						var current = clips[0];

						float randomTime = scale * current.clip.length;

						animator.Update(randomTime);
					}
				}
			}
		}
	}
}