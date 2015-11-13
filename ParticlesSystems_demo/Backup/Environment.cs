using System;

namespace Particles
{
	/// <summary>
	/// Summary description for Enviroment.
	/// </summary>
	public class Environment
	{
		/// <summary>
		/// Single instance of the Environment
		/// </summary>
		private static Environment m_Instance = new Environment();

		// Default Gravity vector in our world
		private Vector m_Gravity = Vector.Zero;
		// Default Wind vector in our world
		private Vector m_Wind = Vector.Zero;

		/// <summary>
		/// Protected constructor
		/// </summary>
		protected Environment()
		{
		}

		// Public accessor function to get an instance of the Environment
		public static Environment GetInstance()
		{
			return m_Instance;
		}

		/// <summary>
		/// Accessor for the Gravity Vector
		/// </summary>
		public Vector Gravity
		{
			get { return m_Gravity; }
			set { m_Gravity = value; }
		}
		/// <summary>
		/// Accessor for the Wind Vector
		/// </summary>
		public Vector Wind
		{
			get { return m_Wind; }
			set { m_Wind = value; }
		}
	}
}
