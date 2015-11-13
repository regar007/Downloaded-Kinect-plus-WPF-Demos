using System;
using System.Drawing;

namespace Particles
{
	/// <summary>
	/// Summary description for Firework.
	/// </summary>
	public class PSFirework : ParticlesSystem
	{
		private static readonly int DEFAULT_NUM_PARTICLES = 150;
		protected new int particleMaxLife = 80;

		// Random numbers generator
		private Random m_rand = new Random();
		private bool stageRocket = true;

		/// <summary>
		/// Default constructor
		/// </summary>
		public PSFirework()
		{
			// Start system at the (0,0,0) position
			m_Position = Vector.Zero;
			// Set system color to black
			m_Color = Color.Black;
			// Initialize the system
			InitSystem();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Starting position of system</param>
		public PSFirework(Vector pos)
		{
			// Set system's position at given position
			m_Position = pos;
			// Set system color to black
			m_Color = Color.Black;
			// Initialize the system
			InitSystem();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Starting position of system</param>
		/// <param name="col">Color of the particles in the system</param>
		public PSFirework(Vector pos, Color col)
		{
			// Set system's position at given position
			m_Position = pos;
			// Set system color to given color
			m_Color = col;
			// Initialize the system
			InitSystem();
		}

		/// <summary>
		/// Initialize the system
		/// </summary>
		private void InitSystem()
		{
			// Generate random direction & speed for new particle
			float rndX = 1 * ((float)m_rand.NextDouble() - 0.5f);
			float rndY = -2f - 1 * ((float)m_rand.NextDouble());
			float rndZ = 1 * ((float)m_rand.NextDouble() - 0.5f);

			// Create new particle at system's starting position
			Particle part = new Particle(m_Position,
				// With generated direction and speed
				new Vector(rndX, rndY, rndZ), m_Color,
				// And a random starting life
				m_rand.Next(50));

			// Create particle, and add it to the list of particles
			m_Particles.Add(part);
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

			// If we're at the "rocket" stage
			if (stageRocket)
			{
				// Get single particle
				part = (Particle)m_Particles[0];
				// Update the particle
				part.Update();
				// If the particle is old enough
				if (part.Life > particleMaxLife)
				{
					// Change to firework stage
					stageRocket = !stageRocket;
					// Create all particles
					for (int i = 0; i < DEFAULT_NUM_PARTICLES; i++)
					{
						Particle newPart = new Particle(part.Position,
							// With generated direction and speed
							new Vector((float)Math.Cos(Math.PI * 2 * i/DEFAULT_NUM_PARTICLES), 
									   ((float)Math.Sin(Math.PI * 2 * i/DEFAULT_NUM_PARTICLES)/2)-0.75f, 0), m_Color, 0);
						m_Particles.Add(newPart);
					}
					// Remove "rocket" particle
					m_Particles.RemoveAt(0);
				}
				return true;
			}

			// If we're at the firework stage

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
		/// Don't do anything - particles needs to be dynamically created
		/// </summary>
		/// <returns>null</returns>
		protected override Particle GenerateParticle()
		{
			// Always return null
			return null;
		}
	}
}
