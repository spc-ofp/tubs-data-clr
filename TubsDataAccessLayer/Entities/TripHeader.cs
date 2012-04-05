// -----------------------------------------------------------------------
// <copyright file="TripHeader.cs" company="">
// TODO: Update copyright text.
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
    /// TripHeader is a lightweight object for working with
    /// a complete list of trips without pulling in the full
    /// object graph.
    /// </summary>
    public class TripHeader
    {
        // Primary key
        public virtual int Id { get; set; }

        public virtual string ProgramCode { get; set; }

        public virtual string StaffCode { get; set; }

        public virtual string TripNumber { get; set; }

        public virtual string FfaTripNumber { get; set; }

        public virtual string CkTripNumber { get; set; }

        public virtual string FmTripNumber { get; set; }

        public virtual string SbTripNumber { get; set; }

        public virtual string HwTripNumber { get; set; }

        public virtual string SpcTripNumber
        {
            get
            {
                return String.Format("{0} / {1}", this.StaffCode.Trim(), this.TripNumber.Trim());
            }
        }
    }
}
