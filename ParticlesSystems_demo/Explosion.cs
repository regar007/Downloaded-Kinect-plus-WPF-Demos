using System;
using System.Drawing;

namespace Particles
{
	/// <summary>
	/// Summary description for Firework.
	/// </summary>
	public class PSExplosion : ParticlesSystem
	{
		private static readonly int DEFAULT_NUM_PARTICLES = 150;

		// Random numbers generator
		private Random m_rand = new Random();

		/// <summary>
		/// Default constructor
		/// </summary>
		public PSExplosion()
		{
			// Start system at the (0,0,0) position
			m_Position = Vector.Zero;
			// Set system color to black
			m_Color = Color.Black;
			// Create all the particles in the system
			for (int i = 0; i < DEFAULT_NUM_PARTICLES; i++)
			{
				// Create particle, and add it to the list of particles
				m_Particles.Add(GenerateParticle());
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Starting position of system</param>
		public PSExplosion(Vector pos)
		{
			// Set system's position at given position
			m_Position = pos;
			// Set system color to black
			m_Color = Color.Black;
			// Create all the particles in the system
			for (int i = 0; i < DEFAULT_NUM_PARTICLES; i++)
			{
				// Create particle, and add it to the list of particles
				m_Particles.Add(GenerateParticle());
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Starting position of system</param>
		/// <param name="col">Color of the particles in the system</param>
		public PSExplosion(Vector pos, Color col)
		{
			// Set system's position at given position
			m_Position = pos;
			// Set system color to given color
			m_Color = col;
			// Create all the particles in the system
			for (int i = 0; i < DEFAULT_NUM_PARTICLES; i++)
			{
				// Create particle, and add it to the list of particles
				m_Particles.Add(GenerateParticle());
			}
		}

		/// <summary>
		/// Update all the particles in the system
		/// </summary>
		/// <returns>False - if there are no more particles in system
		/// True - otherwise</returns>
		public override bool Update()
		{
			Particle part;
			// Get number of particles in the system
			int count = m_Particles.Count;

			// For each particle
			for (int i=0; i<count; i++)
			{
				// Get particle from list
				part = (Particle)m_Particles[i];
				// Update particle and check age
				part.Update();
				if (part.Life > particleMaxLife)
				{
					// Remove old particles
					m_Particles.RemoveAt(i);
					// Update counter and index
					i--;
					count = m_Particles.Count;
				}
			}
			// If there are no more particles in the system
			if (m_Particles.Count <= 0)
				return false;
			return true;
		}

		/// <summary>
		/// Generate a single particle in the system.
		/// This function is used when particles are first created, and when they are regenerated
		/// </summary>
		/// <returns>New particle</returns>
		protected override Particle GenerateParticle()
		{
			// Generate random direction & speed for new particle
			float rndX = 2 * ((float)m_rand.NextDouble() - 0.5f);
			float rndY = 2 * ((float)m_rand.NextDouble() - 0.5f);
			float rndZ = 2 * ((float)m_rand.NextDouble() - 0.5f);

			// Create new particle at system's starting position
			Particle part = new Particle(m_Position,
				// With generated direction and speed
				new Vector(rndX, rndY, rndZ), m_Color,
				// And a random starting life
				m_rand.Next(50));

			// Return newly created particle
			return part;
		}
	}
}
