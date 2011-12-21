// -----------------------------------------------------------------------
// <copyright file="MarineDevice.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Tubs.DAL.Entities
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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MarineDevice
    {
        public virtual int Id { get; protected set; }

        public virtual string Description { get; set; }

        public virtual string Category { get; set; }

        public virtual string GearList { get; set; }

        public virtual int LongLineOrder { get; set; }

        public virtual int PurseSeineOrder { get; set; }

        public virtual int PoleAndLineOrder { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }
    }
}
