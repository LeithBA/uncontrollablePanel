using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CraftingLegends.Framework
{
	public class DepthSortingDynamic : DepthSortingStatic
	{
		protected void Update()
		{
			if (_transform.position != _lastPosition)
			{
				Vector3 pos = new Vector3(_transform.position.x, _transform.position.y, _transform.position.y * DEPTH_SCALE + offset * DEPTH_SCALE);
				_transform.position = pos;
				_lastPosition = pos;
			}
		}
	}
}