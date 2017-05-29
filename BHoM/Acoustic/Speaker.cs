﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Base;

namespace BHoM.Acoustic
{
    public class Speaker
    {
        /// <summary>
        /// Source emissive point
        /// </summary>
        public Point Position { get; set; }
        /// <summary>
        /// Main emissive direction for directivity factor
        /// </summary>
        public Vector Direction { get; set; }
        /// <summary>
        /// Source dirctivity type as string
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Automatically generated identifier of a source
        /// </summary>
        public string SpeakerID { get; set; }       // Ask Arnauld how to generate it automatically
        /// <summary>
        /// Acoustic Gain
        /// </summary>
        public List<double> Gains { get; set; }      // value for each frequency

        #region Constructor

        /// <summary>
        /// Instantiate a new source by emissive point, direction and directivity type.
        /// </summary>
        /// <param name="position">Defines position of the source</param>
        /// <param name="direction">Defines main directivity vector</param>
        /// <param name="category">Defines source directivity type</param>
        public Speaker(Point position, Vector direction = null, string category = null)
        {
            if (direction == null)
                direction = new Vector(1, 0, 0);
            if (category == null)
                category = "Omni";

            Position = position;
            Direction = direction;
            Category = category;
        }

        /// <summary>
        /// Instantiate a new source by emissive point and category. Emits on Z axis.
        /// </summary>
        /// <param name="position">Defines position of the source</param>
        /// <param name="category">Defines source directivity type</param>
        public Speaker(Point position, string category) : this(position, null, category)
        {
        }

        /// <summary>
        /// Instantiate a new source by emissive point. By default, emits on Z axis as Omnidirectional source.
        /// </summary>
        /// <param name="position">Defines position of the source</param>
        public Speaker(Point position) : this(position, null, null)
        {
        }

        #endregion

        #region Properties

        public double GetGain(double frequency, double octave)
        {
            return (frequency < 5) ? Gains[0] : Gains[1];
        }

        public double GetGainAngleFactor(double angle, double octave) // take out octave
        {
            return (octave < 1000) ? (-2 * angle / 90 - 8) : (-18 * angle / 150 - 2); // I made some asumption here since matlab handles only 500Hz and 2000Hz
        }

        #endregion

    }
}