// -----------------------------------------------------------------------
// <copyright file="LengthCode.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent codes from [obsv].[ref_len]
    /// </summary>
    public enum LengthCode
    {
        /// <summary>
        /// Anal fin length
        /// </summary>
        [Description("Anal fin length")]
        AN,

        /// <summary>
        /// Bill to fork in tail
        /// </summary>
        [Description("Bill to fork in tail")]
        BL,

        /// <summary>
        /// Curved Carapace Length
        /// </summary>
        [Description("Curved Carapace Length")]
        CC,

        /// <summary>
        /// Cleithrum to anterior base caudal keel
        /// </summary>
        [Description("Cleithrum to anterior base caudal keel")]
        CK,

        /// <summary>
        /// Carapace length (turtles)
        /// </summary>
        [Description("Carapace length (turtles)")]
        CL,

        /// <summary>
        /// Carapace width
        /// </summary>
        [Description("Carapace width")]
        CW,

        /// <summary>
        /// Cleithrum to caudal fork
        /// </summary>
        [Description("Cleithrum to caudal fork")]
        CX,

        /// <summary>
        /// Posterior eye orbital to caudal fork
        /// </summary>
        [Description("Posterior eye orbital to caudal fork")]
        EO,

        /// <summary>
        /// Posterior eye orbital to vent
        /// </summary>
        [Description("Posterior eye orbital to vent")]
        EV,

        /// <summary>
        /// 1st dorsal to fork in tail
        /// </summary>
        [Description("1st dorsal to fork in tail")]
        FF,

        /// <summary>
        /// Weight of all fins (sharks)
        /// </summary>
        [Description("Weight of all fins (sharks)")]
        FN,

        /// <summary>
        /// 1st dorsal to 2nd dorsal
        /// </summary>
        [Description("1st dorsal to 2nd dorsal")]
        FS,

        /// <summary>
        /// Fillets weight
        /// </summary>
        [Description("Fillets weight")]
        FW,

        /// <summary>
        /// Gilled, gutted, headed, flaps removed
        /// </summary>
        [Description("Gilled, gutted, headed, flaps removed")]
        GF,

        /// <summary>
        /// Gilled and gutted weight
        /// </summary>
        [Description("Gilled and gutted weight")]
        GG,

        /// <summary>
        /// Gutted and headed weight
        /// </summary>
        [Description("Gutted and headed weight")]
        GH,

        /// <summary>
        /// Girth
        /// </summary>
        [Description("Girth")]
        GI,

        /// <summary>
        /// Gutted only (gills left in)
        /// </summary>
        [Description("Gutted only (gills left in)")]
        GO,

        /// <summary>
        /// Gilled, gutted and tailed
        /// </summary>
        [Description("Gilled, gutted and tailed")]
        GT,

        /// <summary>
        /// Gutted, headed and tailed
        /// </summary>
        [Description("Gutted, headed and tailed")]
        GX,

        /// <summary>
        /// Lower jaw to fork in tail
        /// </summary>
        [Description("Lower jaw to fork in tail")]
        LF,

        /// <summary>
        /// Not measured
        /// </summary>
        [Description("Not measured")]
        NM,

        /// <summary>
        /// Observer's Estimate
        /// </summary>
        [Description("Observer's Estimate")]
        OW,

        /// <summary>
        /// Pectoral fin to fork in tail
        /// </summary>
        [Description("Pectoral fin to fork in tail")]
        PF,

        /// <summary>
        /// Pectoral fin to 2nd dorsal
        /// </summary>
        [Description("Pectoral fin to 2nd dorsal")]
        PS,

        /// <summary>
        /// Straight Carapace Length
        /// </summary>
        [Description("Straight Carapace Length")]
        SC,

        /// <summary>
        /// Tip of snout to end of caudal peduncle
        /// </summary>
        [Description("Tip of snout to end of caudal peduncle")]
        SL,

        /// <summary>
        /// Body Thickness (Width)
        /// </summary>
        [Description("Body Thickness (Width)")]
        TH,

        /// <summary>
        /// Tip of snout to end of tail
        /// </summary>
        [Description("Tip of snout to end of tail")]
        TL,

        /// <summary>
        /// Total width (tip of wings - rays)
        /// </summary>
        [Description("Total width (tip of wings - rays)")]
        TW,

        /// <summary>
        /// Upper jaw to fork in tail
        /// </summary>
        [Description("Upper jaw to fork in tail")]
        UF,

        /// <summary>
        /// Upper jaw to 2nd dorsal fin
        /// </summary>
        [Description("Upper jaw to 2nd dorsal fin")]
        US,

        /// <summary>
        /// Whole weight
        /// </summary>
        [Description("Whole weight")]
        WW
    }
}
