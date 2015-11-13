using System;
using System.Drawing;

namespace Particles
{
	/// <summary>
	/// Summary description for Firework.
	/// </summary>
	public class PSFountain : ParticlesSystem
	{
		private static readonly int DEFAULT_NUM_PARTICLES = 250;

		// Random numbers generator
		private Random m_rand = new Random();

		/// <summary>
		/// Default constructor
		/// </summary>
		public PSFountain() : this(Vector.Zero, Color.Black)
		{ }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Starting position of system</param>
		public PSFountain(Vector pos) : this(pos, Color.Black)
		{ }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Starting position of system</param>
		/// <param name="col">Color of the particles in the system</param>
		public PSFountain(Vector pos, Color col)
		{
			// Mark that this system regenerates particles
			m_Regenerate = true;
			// Set system's position at given position
			m_Position = pos;
			// Set system color to given color
			m_Color = col;
			// Create ONLY 5 particles
			for (int i = 0; i < 5; i++)
			{
				// Create particle, and add it to the list of particles
				m_Particles.Add(GenerateParticle());
			}
		}

		/// <summary>
		/// Generate a single particle in the system.
		/// This function is used when particles are first created, and when they are regenerated
		/// </summary>
		/// <returns>New particle</returns>
		protected override Particle GenerateParticle()
		{
			// Generate random direction & speed for new particle
			// In a fountain, particles move almost straight up
			float rndX = 0.5f * ((float)m_rand.NextDouble() - 0.4f);
			float rndY = -1 - 1 * (float)m_rand.NextDouble();
			float rndZ = 2 * ((float)m_rand.NextDouble() - 0.4f);

			// Create new particle at system's starting position
			Particle part = new Particle(m_Position,
				// With generated direction and speed
				new Vector(rndX, rndY, rndZ),  m_Color,
				// And a random starting life
				m_rand.Next(50));

			// Return newly created particle
			return part;
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
			for (int i=0; i < count; i++)
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
			// If there aren't enough particles
			if  (m_Particles.Count < DEFAULT_NUM_PARTICLES)
				// Add another particles
				m_Particles.Add(GenerateParticle());

			// Always return true, since system is regenerating
			return true;
		}
	}
}
