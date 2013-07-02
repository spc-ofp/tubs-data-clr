// -----------------------------------------------------------------------
// <copyright file="LongLineCatchHeader.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// There is no database table for Long Line sampling header.  The only data in the
    /// 'header' is the page number, set number, and measuring instrument.  Set number
    /// is collected in set, and I guess page number isn't really used.  As a result,
    /// measuring instrument is actually recorded in LongLineSet (bleah).
    /// Also, AutoMapper doesn't seem to like to map bare collections of entities.
    /// As a result, the DAL includes this fake header.  It's on the caller to
    /// create an appropriate instance of this entity.
    /// </summary>
    public class LongLineCatchHeader
    {
        /// <summary>
        /// Parent fishing set primary key.
        /// </summary>
        public int SetId { get; set; }        
        
        /// <summary>
        /// Link back to parent Set.
        /// </summary>
        public LongLineSet FishingSet { get; set; }

        /// <summary>
        /// List of catch.
        /// </summary>
        public IList<LongLineCatch> Samples { get; set; }
    }
}
