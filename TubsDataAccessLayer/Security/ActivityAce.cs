// -----------------------------------------------------------------------
// <copyright file="ActivityAce.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Security
{
    using System;
    using Spc.Ofp.Tubs.DAL.Infrastructure;

    /// <summary>
    /// Access Control Entity for Activity.
    /// </summary>
    public class ActivityAce : IAccessControl
    {
        public virtual int Id { get; set; }

        public virtual string EntityName { get; set; }

        public virtual int Fkid { get; set; }
    }
}
