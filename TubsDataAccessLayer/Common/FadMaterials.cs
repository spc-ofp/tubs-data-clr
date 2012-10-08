// -----------------------------------------------------------------------
// <copyright file="FadMaterials.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Common
{
    /*
     * This file is part of TUBS.
     *
     * TUBS is free software: you can redistribute it and/or modify
     * it under the terms of the GNU Affero General Public License as published by
     * the Free Software Foundation, either version 3 of the License, or
     * (at your option) any later version.
     *  
     * TUBS is distributed in the hope that it will be useful,
     * but WITHOUT ANY WARRANTY; without even the implied warranty of
     * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     * GNU Affero General Public License for more details.
     *  
     * You should have received a copy of the GNU Affero General Public License
     * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
     */
    using System;
    using System.ComponentModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public enum FadMaterials
    {
        /// <summary>
        /// No value provided
        /// </summary>
        [Description("No value provided")]
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("Logs, Trees or debris tied together")]
        LogsOrTrees = 230,

        /// <summary>
        /// 
        /// </summary>
        [Description("Timber/planks/pallets/spools")]
        Timber = 231,

        /// <summary>
        /// 
        /// </summary>
        [Description("PVC or Plastic tubing")]
        PvcOrPlasticTubing = 232,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plastic drums")]
        PlasticDrums = 233,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plastic Sheeting")]
        PlasticSheeting = 234,

        /// <summary>
        /// 
        /// </summary>
        [Description("Metal Drums (i.e. 44 gallon)")]
        MetalDrums = 235,

        /// <summary>
        /// 
        /// </summary>
        [Description("Philippines design drum FAD")]
        Philippines = 236,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bamboo/Cane")]
        BambooOrCane = 237,

        /// <summary>
        /// 
        /// </summary>
        [Description("Floats/Corks")]
        FloatsOrCorks = 238,

        /// <summary>
        /// 
        /// </summary>
        [Description("Unknown (describe)")]
        Unknown = 239,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chain, cable rings, weights")]
        ChainCableRingsOrWeights = 240,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cord/rope")]
        CordOrRope = 241,

        /// <summary>
        /// 
        /// </summary>
        [Description("Netting hanging underneath FAD")]
        Netting = 242,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bait containers")]
        BaitContainers = 243,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sacking/bagging")]
        SackingOrBagging = 244,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coconut fronds/tree branches")]
        CoconutFronds = 245,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other (describe)")]
        Other = 246, 
    }
}
