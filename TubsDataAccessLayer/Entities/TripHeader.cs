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
    using System.Text;
    using Spc.Ofp.Tubs.DAL.Common;

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

        public virtual Observer Observer { get; set; }

        public virtual string TripNumber { get; set; }

        public virtual string DeparturePort { get; set; }

        public virtual string ReturnPort { get; set; }

        public virtual DateTime? DepartureDate { get; set; }

        public virtual DateTime? ReturnDate { get; set; }

        public virtual string GearCode { get; set; }
		
        public virtual WorkbookVersion? Version { get; set; }

        // Tried to get the vessel name/flag via NHibernate .Join(...)
        // Unfortunately, join only works when the PK from this entity is
        // the FK in the joined table.  The documented workaround is
        // to reference the subordinate entity.
        public virtual Vessel Vessel { get; set; }

        public virtual string FfaTripNumber { get; set; }

        public virtual string CkTripNumber { get; set; }

        public virtual string FmTripNumber { get; set; }

        public virtual string SbTripNumber { get; set; }

        public virtual string HwTripNumber { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }

        public virtual DateTime? ClosedDate { get; set; }

        /// <summary>
        /// SPC specific trip number
        /// </summary>
        public virtual string SpcTripNumber
        {
            get
            {
                return String.Format("{0} / {1}", this.Observer.StaffCode.Trim(), this.TripNumber.Trim());
            }
        }

        public virtual string WorkbookVersion
        {
            get
            {
                return this.Version.HasValue ? this.Version.ToString() : String.Empty;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(
                "S".Equals(this.GearCode, StringComparison.InvariantCultureIgnoreCase) ? "Purse Seine " :
                "L".Equals(this.GearCode, StringComparison.InvariantCultureIgnoreCase) ? "Long Line " :
                "P".Equals(this.GearCode, StringComparison.InvariantCultureIgnoreCase) ? "Pole and Line " :
                "Unknown "
            );
            builder.Append("trip ").Append(SpcTripNumber);
            return builder.ToString();
        }

    }
}
