using System;
using System.Collections;
using System.Drawing;

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
		protected bool m_Regenerate;
		// Central position of the system
		protected Vector m_Position;
		// Default maximum life of a particle
		protected int particleMaxLife = 150;
		// Default color of a particle
		protected Color m_Color;

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
		/// Draw all the particles in the system
		/// </summary>
		/// <param name="g">Graphics object to be painted on</param>
		public virtual void Draw(Graphics g)
		{
			Pen pen;
			int intense;
			Particle part;

			// For each particle in the system
			for (int i = 0; i < m_Particles.Count; i++)
			{
				// Get the current particle
				part = this[i];
				// Calculate particle intensity
				intense = (int)((float)part.Life / PARTICLES_MAX_LIFE);
				// Generate pen for the particle
				pen = new Pen(Color.FromArgb(intense * m_Color.R , 
											 intense * m_Color.G, 
											 intense * m_Color.B));
				// Draw particle
				g.DrawEllipse(pen, part.Position.X, part.Position.Y, 
					Math.Max(1,4 * part.Life / PARTICLES_MAX_LIFE),
					Math.Max(1,4 * part.Life / PARTICLES_MAX_LIFE));
				pen.Dispose();
			}
		}


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

		/// <summary>
		/// Accessor to the maximum life of particles in the system
		/// </summary>
		public virtual int PARTICLES_MAX_LIFE
		{
			get { return particleMaxLife; }
		}

	}
}
