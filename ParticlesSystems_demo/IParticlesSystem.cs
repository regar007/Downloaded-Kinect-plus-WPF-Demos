using System;
using System.Collections;

namespace Particles
{
	/// <summary>
	/// Summary description for ParticlesList.
	/// </summary>
	public abstract class ParticlesSystem
	{
		// Array to keep all the particles of the system
		protected ArrayList m_Particles = new ArrayList();
		// Should the particles regenerate over time
		protected bool m_Regenerate = false;
		// Central position of the system
		protected Vector m_Position;

		/// <summary>
		/// Default constructor
		/// </summary>
		public ParticlesSystem()
		{
			// Set default position of the system
			m_Position = Vector.Zero;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pos">Central position of the system</param>
		public ParticlesSystem(Vector pos)
		{
			// Set system's position to given position
			m_Position = pos;
		}

		/// <summary>
		/// Generate a single particle in the system.
		/// This function is used when particles are first created, and when they are regenerated
		/// </summary>
		/// <returns>New particle</returns>
		protected abstract Particle GenerateParticle();

		/// <summary>
		/// Update all the particles in the system
		/// </summary>
		/// <returns>False - if there are no more particles in system
		/// True - otherwise</returns>
		public abstract bool Update();


		/// <summary>
		/// Indexer allowing access to each particle in the system
		/// </summary>
		public Particle this[int index]
		{
			get	
			{
				return (Particle)m_Particles[index];
			}
		}

		/// <summary>
		/// Accessor to the number of particles in the system
		/// </summary>
		public int CountParticles
		{
			get { return m_Particles.Count; }
		}

	}
}
