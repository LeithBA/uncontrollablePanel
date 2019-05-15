using UnityEngine;
using System.Collections;
using System;

namespace CraftingLegends.Framework
{
	public class DepthSortingStatic : MonoBehaviour
	{
		public const float DEPTH_SCALE = 0.1f;

		// ================================================================================
		//  public
		// --------------------------------------------------------------------------------

		public float offset = 0f;

		// ================================================================================
		//  private
		// --------------------------------------------------------------------------------

		protected Transform _transform;

		private bool _wasInit = false;

		protected Vector3 _lastPosition;

		// ================================================================================
		//  unity methods
		// --------------------------------------------------------------------------------

		protected virtual void Awake()
		{
			_transform = transform;
		}

		protected void Start()
		{
			Init();
		}

		// ================================================================================
		//  public methods
		// --------------------------------------------------------------------------------

		public void Init()
		{
			if (!_wasInit)
			{
				UpdateNow();
				_wasInit = true;
			}
		}

		public void UpdateNow()
		{			
			if (_transform == null)
			{
				_transform = transform;
			}

			_lastPosition = GetPosition(_transform.position);
			_transform.position = _lastPosition;
		}

		public Vector3 GetPosition(Vector3 current)
		{			
			return new Vector3(current.x, current.y, current.y * DEPTH_SCALE + offset * DEPTH_SCALE);
		}

		// ================================================================================
		//  static helper methods
		// --------------------------------------------------------------------------------

		public static Vector3 GetPositionWithOffset(Vector2 pos, float offset = 0)
		{
			float z = pos.y * DEPTH_SCALE + offset * DEPTH_SCALE;

			return new Vector3(pos.x, pos.y, z);
		}

		public static float GetDepthFromYAndOffset(float y, float offset = 0)
		{
			return y * DEPTH_SCALE + offset * DEPTH_SCALE;
		}

		public static void Update(Transform displayTransform)
		{
			var allComponents = displayTransform.GetComponentsInChildren<DepthSortingStatic>();
			for (int i = 0; i < allComponents.Length; i++)
			{
				allComponents[i].UpdateNow();
			}
		}
	}
}