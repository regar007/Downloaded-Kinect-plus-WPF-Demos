using System;
using System.Drawing;

namespace Particles
{
	/// <summary>
	/// Summary description for Particle.
	/// </summary>
	public class Particle
	{
		// Position of the particle
		private Vector m_Position;
		// Direction and speed the particle is moving
		private Vector m_Velocity;
		// Age of the particle
		private int m_Life;
		// Color of the particle
		private Color m_Color;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Particle() : this(Vector.Zero, Vector.Zero, Color.Black, 0)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Position <see cref="Vector"/> of newly created particle</param>
		/// <param name="velocity">Velocity <see cref="Vector"/> of newly created particle</param>
		/// <param name="col">Color of newly created particle</param>
		/// <param name="life">Starting age of newly created particle</param>
		public Particle(Vector pos, Vector velocity, Color col, int life)
		{
			// Create particle at given position
			m_Position = pos;
			// Set particle's speed to given speed
			m_Velocity = velocity;
			// Set particle's color to given color
			m_Color = col;
			// Make sure starting age is valid
			if (life > 0) 
				m_Life = life;
		}

		/// <summary>
		/// Update position, velocity and age of particle
		/// </summary>
		/// <returns>False - if particle is too old and should be killed
		/// True - otherwise</returns>
		public virtual void Update()
		{
			// Update particle's movement according to environment
			m_Velocity = m_Velocity - Environment.GetInstance().Gravity
									+ Environment.GetInstance().Wind;
			// Update particle's position according to movement
			m_Position = m_Position + m_Velocity;
			// Update particle's age
			m_Life++;
		}
		#region Accesors

		/// <summary>
		/// Read Only - Position <see cref="Vector"/> of the particle
		/// </summary>
		public Vector Position
		{
			get { return m_Position; }
		}
		/// <summary>
		/// Read Only - Velocity <see cref="Vector"/> of the particle
		/// </summary>
		public Vector Velocity
		{
			get { return m_Velocity; }
		}
		/// <summary>
		/// Read Only - Age of the particle
		/// </summary>
		public int Life
		{
			get { return m_Life; }
		}
		/// <summary>
		/// Read Only - Color of the particle
		/// </summary>
		public Color Color
		{
			get { return m_Color; }
		}
		#endregion Accessors
	}
}
