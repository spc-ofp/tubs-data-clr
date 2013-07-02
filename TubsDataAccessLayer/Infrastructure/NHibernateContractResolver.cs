// -----------------------------------------------------------------------
// <copyright file="NHibernateContractResolver.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    using System;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// ContractResolver for serializing NHibernate proxies in Json.NET.
    /// </summary>
    /// <remarks>
    /// StackOverflow to the rescue!
    /// http://stackoverflow.com/questions/286721/json-net-and-nhibernate-lazy-loading-of-collections/5926718#5926718
    /// </remarks>
    public class NHibernateContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (typeof(NHibernate.Proxy.INHibernateProxy).IsAssignableFrom(objectType))
                return base.CreateContract(objectType.BaseType);
            else
                return base.CreateContract(objectType);
        }
    }
}
