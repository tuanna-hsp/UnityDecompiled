using System;
using UnityEngine.Scripting;

namespace UnityEngine
{
	[UsedByNativeCode]
	public struct RaycastHit2D
	{
		private Vector2 m_Centroid;

		private Vector2 m_Point;

		private Vector2 m_Normal;

		private float m_Distance;

		private float m_Fraction;

		private int m_Collider;

		public Vector2 centroid
		{
			get
			{
				return this.m_Centroid;
			}
			set
			{
				this.m_Centroid = value;
			}
		}

		public Vector2 point
		{
			get
			{
				return this.m_Point;
			}
			set
			{
				this.m_Point = value;
			}
		}

		public Vector2 normal
		{
			get
			{
				return this.m_Normal;
			}
			set
			{
				this.m_Normal = value;
			}
		}

		public float distance
		{
			get
			{
				return this.m_Distance;
			}
			set
			{
				this.m_Distance = value;
			}
		}

		public float fraction
		{
			get
			{
				return this.m_Fraction;
			}
			set
			{
				this.m_Fraction = value;
			}
		}

		public Collider2D collider
		{
			get
			{
				return Object.FindObjectFromInstanceID(this.m_Collider) as Collider2D;
			}
		}

		public Rigidbody2D rigidbody
		{
			get
			{
				return (!(this.collider != null)) ? null : this.collider.attachedRigidbody;
			}
		}

		public Transform transform
		{
			get
			{
				Rigidbody2D rigidbody = this.rigidbody;
				Transform result;
				if (rigidbody != null)
				{
					result = rigidbody.transform;
				}
				else if (this.collider != null)
				{
					result = this.collider.transform;
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		public static implicit operator bool(RaycastHit2D hit)
		{
			return hit.collider != null;
		}

		public int CompareTo(RaycastHit2D other)
		{
			int result;
			if (this.collider == null)
			{
				result = 1;
			}
			else if (other.collider == null)
			{
				result = -1;
			}
			else
			{
				result = this.fraction.CompareTo(other.fraction);
			}
			return result;
		}
	}
}
