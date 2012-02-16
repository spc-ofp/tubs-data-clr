// -----------------------------------------------------------------------
// <copyright file="ConditionCode.cs" company="Secretariat of the Pacific Community">
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
    /// These values represent codes from [obsv].[ref_cond]
    /// </summary>
    public enum ConditionCode
    {
        /// <summary>
        /// Alive but unable to describe condition
        /// </summary>
        [Description("Alive but unable to describe condition")]
        A0,

        /// <summary>
        /// Alive and healthy
        /// </summary>
        [Description("Alive and healthy")]
        A1,

        /// <summary>
        /// Alive, but injured or distressed
        /// </summary>
        [Description("Alive, but injured or distressed")]
        A2,

        /// <summary>
        /// Alive, but unlikely to live
        /// </summary>
        [Description("Alive, but unlikely to live")]
        A3,

        /// <summary>
        /// Entangled, okay
        /// </summary>
        [Description("Entangled, okay")]
        A4,

        /// <summary>
        /// Entangled, injured
        /// </summary>
        [Description("Entangled, injured")]
        A5,

        /// <summary>
        /// Hooked, externally, injured
        /// </summary>
        [Description("Hooked, externally, injured")]
        A6,

        /// <summary>
        /// Hooked, internally, injured
        /// </summary>
        [Description("Hooked, internally, injured")]
        A7,

        /// <summary>
        /// Hooked, unknown, injured
        /// </summary>
        [Description("Hooked, unknown, injured")]
        A8,

        /// <summary>
        /// Dead
        /// </summary>
        [Description("Dead")]
        D ,

        /// <summary>
        /// Entangled, dead
        /// </summary>
        [Description("Entangled, dead")]	
        D1,

        /// <summary>
        /// Hooked, externally, dead
        /// </summary>
        [Description("Hooked, externally, dead")]
        D2,

        /// <summary>
        /// Hooked, internally, dead
        /// </summary>
        [Description("Hooked, internally, dead")]
        D3,

        /// <summary>
        /// Hooked, unknown, dead
        /// </summary>
        [Description("Hooked, unknown, dead")]
        D4,

        /// <summary>
        /// Condition, unknown
        /// </summary>
        [Description("Condition, unknown")]
        U,

        /// <summary>
        /// Entangled, unknown condition
        /// </summary>
        [Description("Entangled, unknown condition")]
        U1,

        /// <summary>
        /// Hooked, externally, condition unknown
        /// </summary>
        [Description("Hooked, externally, condition unknown")]
        U2,

        /// <summary>
        /// Hooked, internally, condition unknown
        /// </summary>
        [Description("Hooked, internally, condition unknown")]
        U3,

        /// <summary>
        /// Hooked, unknown, condition unknown
        /// </summary>
        [Description("Hooked, unknown, condition unknown")]
        U4,
    }
}
