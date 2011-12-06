// -----------------------------------------------------------------------
// <copyright file="TripMap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Mapping for common trip data.
    /// </summary>
    public class TripMap : ClassMap<Trip>
    {
        public TripMap()
        {
            Table("[obsv].[trip]");
            Id(x => x.Id, "obstrip_id").GeneratedBy.Identity();
            Map(x => x.TripNumber, "tripno");
            Map(x => x.DepartureDate, "dep_dtime");
            Map(x => x.UtcDepartureDate, "utc_dep_dtime");
            Map(x => x.ReturnDate, "ret_dtime");

            References(x => x.Vessel).Column("vessel_id");
            References(x => x.Observer).Column("staff_code");
            References(x => x.DeparturePort).Column("dep_port");
            References(x => x.ReturnPort).Column("ret_port");

            DiscriminateSubClassesOnColumn<string>("gear_code");
        }
    }

    /// <summary>
    /// Mapping for purse seine specific data.
    /// </summary>
    public class PurseSeineTripMap : SubclassMap<PurseSeineTrip>
    {
        public PurseSeineTripMap()
        {
            DiscriminatorValue("S");
            HasMany(x => x.SeaDays).KeyColumn("obstrip_id");
        }
    }

    /// <summary>
    /// Mapping for long line specific data.
    /// </summary>
    public class LongLineTripMap : SubclassMap<LongLineTrip>
    {
        public LongLineTripMap()
        {
            DiscriminatorValue("L");
        }
    }
}
