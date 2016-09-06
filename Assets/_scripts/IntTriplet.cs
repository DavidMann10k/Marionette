// <copyright file="IntTriplet.cs"  company="David A. Mann">
//     Copyright (c) David A. Mann. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A triplet of ints for catesian coordinate applications.
/// </summary>
public struct IntTriplet : IEquatable<IntTriplet>, IEqualityComparer<IntTriplet>
{
    /// <summary>
    /// The x.
    /// </summary>
    public int X;
    
    /// <summary>
    /// The y.
    /// </summary>
    public int Y;
    
    /// <summary>
    /// The z.
    /// </summary>
    public int Z;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="IntTriplet"/> struct.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="z">The z coordinate.</param>
    public IntTriplet(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    /// <summary>
    /// Determines whether the specified <see cref="IntVector3"/> is equal to the current <see cref="IntVector3"/>.
    /// </summary>
    /// <param name="other">The <see cref="IntVector3"/> to compare with the current <see cref="IntVector3"/>.</param>
    /// <returns><c>true</c> if the specified <see cref="IntVector3"/> is equal to the current <see cref="IntVector3"/>; otherwise, <c>false</c>.</returns>
	bool IEquatable<IntTriplet>.Equals(IntTriplet other)
    {
        return other.X == this.X && other.Y == this.Y && other.Z == this.Z;
    }
    
    /// <summary>
    /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="IntVector3"/>.
    /// </summary>
    /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="IntVector3"/>.</param>
    /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current <see cref="IntVector3"/>;
    /// otherwise, <c>false</c>.</returns>
    public override bool Equals(object obj)
    {
        return obj is IntTriplet && this.Equals(obj);
    }

	bool IEqualityComparer<IntTriplet>.Equals (IntTriplet a, IntTriplet b)
	{
		return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
	}

	int IEqualityComparer<IntTriplet>.GetHashCode (IntTriplet obj)
	{
		return X ^ Y ^ Z;
	}

	public override int GetHashCode ()
	{
		return X ^ Y ^ Z;
	}

	public Vector3 AsVector()
	{
		return new Vector3(X, Y, Z);
	}
	
	public static IntTriplet operator +(IntTriplet t1, IntTriplet t2)
	{
		t1.X += t2.X;
		t1.Y += t2.Y;
		t1.Z += t2.Z;
		return t1;
	}
	
	public static IntTriplet operator *(IntTriplet t1, IntTriplet t2)
	{
		t1.X *= t2.X;
		t1.Y *= t2.Y;
		t1.Z *= t2.Z;
		return t1;
	}
	
	public static Vector3 operator +(Vector3 v, IntTriplet t)
	{
		v.x += t.X;
		v.y += t.Y;
		v.z += t.Z;
		return v;
    }
    
    public static Vector3 operator *(Vector3 v, IntTriplet t)
    {
        v.x *= t.X;
        v.y *= t.Y;
        v.z *= t.Z;
        return v;
    }
    
    public static Vector3 operator *(float f, IntTriplet t)
    {
        return new Vector3(t.X * f, t.Y * f, t.Z * f);
    }
    
    public static Vector3 operator *(IntTriplet t, float f)
    {
        return new Vector3(t.X * f, t.Y * f, t.Z * f);
    }
	
	public static IntTriplet zero
	{
		get { return new IntTriplet (0, 0, 0); }
	}
	
	public static IntTriplet one
	{
		get { return new IntTriplet (1, 1, 1); }
	}
}