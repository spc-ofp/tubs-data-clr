// -----------------------------------------------------------------------
// <copyright file="TubsLinqToHqlGeneratorsRegistry.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    using NHibernate.Linq.Functions;
    using NHibernate.Linq;
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TubsLinqToHqlGeneratorsRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public TubsLinqToHqlGeneratorsRegistry()
        {
            //RegisterGenerator(ReflectionHelper.GetMethodDefinition(() =>
            //    SecurableExtensions.In<object>(null, (object[])null)),
            //                new EntityContainsGenerator());
            //RegisterGenerator(ReflectionHelper.GetMethodDefinition(() =>
            //    SecurableExtensions.In<object>(null, (IQueryable<object>)null)),
            //                    new EntityContainsGenerator());
            RegisterGenerator(ReflectionHelper.GetMethodDefinition(() =>
                SecurableExtensions.AclContains(null, null)),
                                new AclContainsGenerator());
            
            //EntityMethodGenerator<Trip, string, bool>.Register(this, (trip) => trip.IsAllowed("xyzzy"), Trip.IsAllowedExpression);
            //this.Merge(new EntityMethodGenerator());
            //this.Merge(new EntityContainsGenerator());
        }
    }
}
