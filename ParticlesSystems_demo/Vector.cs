using System;
using System.Globalization;



namespace Particles
{
	/// <summary>
	/// Summary description for Vector.
	/// </summary>
	public class Vector
	{
		#region Private members
		/// <summary>
		/// X Coorination of the vector
		/// </summary>
		private float m_Xcoord;
		/// <summary>
		/// Y Coorination of the vector
		/// </summary>
		private float m_Ycoord;
		/// <summary>
		/// Z Coorination of the vector
		/// </summary>
		private float m_Zcoord;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor. Initiate vector at the (0,0,0) location
		/// </summary>
		public Vector()
		{}

		/// <summary>
		/// Initiate vector with given parameters
		/// </summary>
		/// <param name="inX">X coordination of vector</param>
		/// <param name="inY">Y coordination of vector</param>
		/// <param name="inZ">Z coordination of vector</param>
		public Vector(float inX, float inY, float inZ)
		{
			m_Xcoord = inX;
			m_Ycoord = inY;
			m_Zcoord = inZ;
		}

		/// <summary>
		/// Initiate vector with given parameters
		/// </summary>
		/// <param name="coordination">Vector's coordinations as an array</param>
		public Vector(float[] coordination)
		{
			m_Xcoord = coordination[0];
			m_Ycoord = coordination[1];
			m_Zcoord = coordination[2];
		}

		/// <summary>
		/// Initiate vector with same values as given Vector
		/// </summary>
		/// <param name="v">Vector to copy coordinations</param>
		public Vector(Vector vector)
		{
			m_Xcoord = vector.X;
			m_Ycoord = vector.Y;
			m_Zcoord = vector.Z;
		}
		#endregion

		#region Public properties
		/// <summary>
		/// X Coordination of vector
		/// </summary>
		public float X
		{
			get { return m_Xcoord; }
			set { m_Xcoord = value; }
		}
		/// <summary>
		/// Y Coordination of vector
		/// </summary>
		public float Y
		{
			get { return m_Ycoord; }
			set { m_Ycoord = value; }
		}
		/// <summary>
		/// Z Coordination of vector
		/// </summary>
		public float Z
		{
			get { return m_Zcoord; }
			set { m_Zcoord = value; }
		}
		#endregion

		#region Methods

		/// <summary>
		/// Add 2 vectors and create a new one.
		/// </summary>
		/// <param name="vector1">First vector</param>
		/// <param name="vector2">Second vector</param>
		/// <returns>New vector that is the sum of the 2 vectors</returns>
		public static Vector Add(Vector vector1, Vector vector2)
		{
			if (((Object)vector1 == null) || ((Object)vector2 ==null))
				return null;
			return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
		}
		/// <summary>
		/// Substract 2 vectors and create a new one.
		/// </summary>
		/// <param name="vector1">First vector</param>
		/// <param name="vector2">Second vector</param>
		/// <returns>New vector that is the difference of the 2 vectors</returns>
		public static Vector Subtract(Vector vector1, Vector vector2)
		{
			if (((Object)vector1 == null) || ((Object)vector2 ==null))
				return null;
			return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
		}
		/// <summary>
		/// Return a new vector with negative values.
		/// </summary>
		/// <param name="v">Original vector</param>
		/// <returns>New vector that is the inversion of the original vector</returns>
		public static Vector Neg(Vector vector)
		{
			if ((Object)vector == null)
				return null;
			return new Vector(-vector.X, -vector.Y, -vector.Z);
		}
		/// <summary>
		/// Multiply a vector with a scalar
		/// </summary>
		/// <param name="vector">Vector to be multiplied</param>
		/// <param name="val">Scalar to multiply vector</param>
		/// <returns>New vector that is the multiplication of the vector with the scalar</returns>
		public static Vector Multiply(Vector vector, float val)
		{
			if ((Object)vector == null)
				return null;
			return new Vector(vector.X * val, vector.Y * val, vector.Z * val);
		}
		#endregion

		#region Operators

		/// <summary>
		/// Check equality of two vectors
		/// </summary>
		/// <param name="vector1">First vector</param>
		/// <param name="vector2">Second vector</param>
		/// <returns>True - if he 2 vectors are equal.
		/// False - otherwise</returns>
		public static bool operator ==(Vector vector1, Vector vector2)
		{
			if (((Object)vector1 == null) || ((Object)vector2 ==null))
				return false;
			return ((vector1.X.Equals(vector2.X))
				&& (vector1.Y.Equals(vector2.Y))
				&& (vector1.Z.Equals(vector2.Z)));
		}

		/// <summary>
		/// Check inequality of two vectors
		/// </summary>
		/// <param name="vector1">First vector</param>
		/// <param name="vector2">Second vector</param>
		/// <returns>True - if he 2 vectors are not equal.
		/// False - otherwise</returns>
		public static bool operator !=(Vector vector1, Vector vector2)
		{
			if (((Object)vector1 == null) || ((Object)vector2 ==null))
				return false;
			return ((!vector1.X.Equals(vector2.X)) 
				&& (!vector1.Y.Equals(vector2.Y))
				&& (!vector1.Z.Equals(vector2.Z)));
		}

		/// <summary>
		/// Calculate the sum of 2 vectors.
		/// </summary>
		/// <param name="vector1">First vector</param>
		/// <param name="vector2">Second vector</param>
		/// <returns>New vector that is the sum of the 2 vectors</returns>
		public static Vector operator+(Vector vector1, Vector vector2)
		{
			if (((Object)vector1 == null) || ((Object)vector2 ==null))
				return null;
			return Vector.Add(vector1, vector2);
		}
		/// <summary>
		/// Calculate the substraction of 2 vectors
		/// </summary>
		/// <param name="vector1">First vector</param>
		/// <param name="vector2">Second vector</param>
		/// <returns>New vector that is the difference of the 2 vectors</returns>
		public static Vector operator-(Vector vector1, Vector vector2)
		{
			if (((Object)vector1 == null) || ((Object)vector2 ==null))
				return null;
			return Vector.Subtract(vector1, vector2);
		}
		/// <summary>
		/// Calculate the negative (inverted) vector
		/// </summary>
		/// <param name="v">Original vector</param>
		/// <returns>New vector that is the invertion of the original vector</returns>
		public static Vector operator-(Vector vector)
		{
			if ((Object)vector == null)
				return null;
			return Vector.Neg(vector);
		}
		/// <summary>
		/// Calculate the multiplication of a vector with a scalar
		/// </summary>
		/// <param name="vector">Vector to be multiplied</param>
		/// <param name="val">Scalar to multiply vector</param>
		/// <returns>New vector that is the multiplication of the vector and the scalar</returns>
		public static Vector operator*(Vector vector, float val)
		{
			if ((Object)vector == null)
				return null;
			return Vector.Multiply(vector, val);
		}
		/// <summary>
		/// Calculate the multiplication of a vector with a scalar
		/// </summary>
		/// <param name="val">Scalar to multiply vecto</param>
		/// <param name="vector">Vector to be multiplied</param>
		/// <returns>New vector that is the multiplication of the vector and the scalar</returns>
		public static Vector operator*(float val, Vector vector)
		{
			if ((Object)vector == null)
				return null;
			return Vector.Multiply(vector, val);
		}

		#endregion

		#region Constants
		/// <summary>
		/// Standard (0,0,0) vector
		/// </summary>
		public static Vector Zero 
		{
			get { return new Vector(0.0f, 0.0f, 0.0f); }
		}
		/// <summary>
		/// Standard (1,0,0) vector
		/// </summary>
		public static Vector XAxis 
		{
			get { return new Vector(1.0f, 0.0f, 0.0f); }
		}
		/// <summary>
		/// Standard (0,1,0) vector
		/// </summary>
		public static Vector YAxis 
		{
			get { return new Vector(0.0f, 1.0f, 0.0f); }
		}
		/// <summary>
		/// Standard (0,0,1) vector
		/// </summary>
		public static Vector ZAxis 
		{
			get { return new Vector(0.0f, 0.0f, 1.0f); }
		}
		#endregion

		#region Overides
		public override bool Equals(object obj)
		{
			Vector vector = obj as Vector;
			if ((Object)vector != null)
				return (m_Xcoord.Equals(vector.X)) 
					&& (m_Ycoord.Equals(vector.Y))
					&& (m_Zcoord.Equals(vector.Z));
			return false;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "({0}, {1}, {2})", m_Xcoord, m_Ycoord, m_Zcoord);
		}
		public override int GetHashCode()
		{
			return m_Xcoord.GetHashCode() ^ m_Ycoord.GetHashCode() ^ m_Zcoord.GetHashCode();
		}
		#endregion
	}
}
