// -----------------------------------------------------------------------
// <copyright file="Brail.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Brail
    {
        public virtual int Id { get; protected set; }

        public virtual int? BrailNumber { get; set; }

        public virtual int? PageNumber { get; set; }

        public virtual int? PageCount { get; set; }

        public virtual int? FishPerBrail { get; set; }

        public virtual string MeasuringInstrument { get; set; }

        public virtual string LengthCode { get; set; }

        public virtual int? FullBrailCount { get; set; }

        public virtual int? SevenEightsBrailCount { get; set; }

        public virtual int? ThreeQuartersBrailCount { get; set; }

        public virtual int? TwoThirdsBrailCount { get; set; }

        public virtual int? OneHalfBrailCount { get; set; }

        public virtual int? OneThirdBrailCount { get; set; }

        public virtual int? OneQuarterBrailCount { get; set; }

        public virtual int? OneEighthBrailCount { get; set; }

        public virtual int? TotalBrailCount { get; set; }

        public virtual decimal? SumOfAllBrails { get; set; }

        //// Long term, this needs to be fixed by moving it out to another table

        public virtual int? Brail1FullnessCode { get; set; }

        public virtual int? SamplesFromBrail1 { get; set; }

        public virtual int? Brail2FullnessCode { get; set; }

        public virtual int? SamplesFromBrail2 { get; set; }

        public virtual int? Brail3FullnessCode { get; set; }

        public virtual int? SamplesFromBrail3 { get; set; }

        public virtual int? Brail4FullnessCode { get; set; }

        public virtual int? SamplesFromBrail4 { get; set; }

        public virtual int? Brail5FullnessCode { get; set; }

        public virtual int? SamplesFromBrail5 { get; set; }

        public virtual int? Brail6FullnessCode { get; set; }

        public virtual int? SamplesFromBrail6 { get; set; }

        public virtual int? Brail7FullnessCode { get; set; }

        public virtual int? SamplesFromBrail7 { get; set; }

        public virtual int? Brail8FullnessCode { get; set; }

        public virtual int? SamplesFromBrail8 { get; set; }

        public virtual int? Brail9FullnessCode { get; set; }

        public virtual int? SamplesFromBrail9 { get; set; }

        public virtual int? Brail10FullnessCode { get; set; }

        public virtual int? SamplesFromBrail10 { get; set; }

        public virtual int? Brail11FullnessCode { get; set; }

        public virtual int? SamplesFromBrail11 { get; set; }

        public virtual int? Brail12FullnessCode { get; set; }

        public virtual int? SamplesFromBrail12 { get; set; }

        public virtual int? Brail13FullnessCode { get; set; }

        public virtual int? SamplesFromBrail13 { get; set; }

        public virtual int? Brail14FullnessCode { get; set; }

        public virtual int? SamplesFromBrail14 { get; set; }

        public virtual int? Brail15FullnessCode { get; set; }

        public virtual int? SamplesFromBrail15 { get; set; }

        public virtual int? Brail16FullnessCode { get; set; }

        public virtual int? SamplesFromBrail16 { get; set; }

        public virtual int? Brail17FullnessCode { get; set; }

        public virtual int? SamplesFromBrail17 { get; set; }

        public virtual int? Brail18FullnessCode { get; set; }

        public virtual int? SamplesFromBrail18 { get; set; }

        public virtual int? Brail19FullnessCode { get; set; }

        public virtual int? SamplesFromBrail19 { get; set; }

        public virtual int? Brail20FullnessCode { get; set; }

        public virtual int? SamplesFromBrail20 { get; set; }

        public virtual int? Brail21FullnessCode { get; set; }

        public virtual int? SamplesFromBrail21 { get; set; }

        public virtual int? Brail22FullnessCode { get; set; }

        public virtual int? SamplesFromBrail22 { get; set; }

        public virtual int? Brail23FullnessCode { get; set; }

        public virtual int? SamplesFromBrail23 { get; set; }

        public virtual int? Brail24FullnessCode { get; set; }

        public virtual int? SamplesFromBrail24 { get; set; }

        public virtual int? Brail25FullnessCode { get; set; }

        public virtual int? SamplesFromBrail25 { get; set; }

        public virtual int? Brail26FullnessCode { get; set; }

        public virtual int? SamplesFromBrail26 { get; set; }

        public virtual int? Brail27FullnessCode { get; set; }

        public virtual int? SamplesFromBrail27 { get; set; }

        public virtual int? Brail28FullnessCode { get; set; }

        public virtual int? SamplesFromBrail28 { get; set; }

        public virtual int? Brail29FullnessCode { get; set; }

        public virtual int? SamplesFromBrail29 { get; set; }

        public virtual int? Brail30FullnessCode { get; set; }

        public virtual int? SamplesFromBrail30 { get; set; }

        public virtual string Comments { get; set; }

        public virtual string EnteredBy { get; set; }

        public virtual DateTime? EnteredDate { get; set; }

        public virtual LengthSamplingHeader Header { get; set; }
    }
}
