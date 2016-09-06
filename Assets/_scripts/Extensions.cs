// <copyright file="Extensions.cs"  company="David A. Mann">
//     Copyright (c) David A. Mann. All rights reserved.
// </copyright>

using System;
using UnityEngine;

/// <summary>
/// Extensions for OctreeWalker.
/// </summary>
public static class Extensions
{
	/// <summary>
	/// Calculate the Diagonals the length of this bounds.
	/// </summary>
	/// <returns>The length.</returns>
	/// <param name="bounds">Bounds.</param>
	public static float DiagonalLength (this Bounds bounds)
	{
		return Mathf.Sqrt (
			(Mathf.Pow (bounds.size.x, 2)) +
			(Mathf.Pow (bounds.size.y, 2)) +
			(Mathf.Pow (bounds.size.z, 2)));
	}

	/// <summary>
	/// Determines if this bounds encapsulates another.
	/// </summary>
	/// <param name="bounds">Bounds.</param>
	/// <param name="other">Other.</param>
	public static bool Encapsulates (this Bounds bounds, Bounds other)
	{
		return (bounds.Contains (other.min) && bounds.Contains (other.max));
	}

	public static bool ExclusiveIntersects (this Bounds bounds, Bounds other)
	{
		var cond1 = bounds.min.x >= other.max.x;
		var cond2 = bounds.min.y >= other.max.y;
		var cond3 = bounds.min.z >= other.max.z;
		var cond4 = bounds.max.x <= other.min.x;
		var cond5 = bounds.max.y <= other.min.y;
		var cond6 = bounds.max.z <= other.min.z;

		return !(cond1 || cond2 || cond3 || cond4 || cond5 || cond6);
	}
}

