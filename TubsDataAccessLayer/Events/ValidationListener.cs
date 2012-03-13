// -----------------------------------------------------------------------
// <copyright file="ValidationListener.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.Event;
    using NHibernate.Persister.Entity;
    using Spc.Ofp.Tubs.DAL.Entities;

    /// <summary>
    /// Attempt at wiring System.ComponentModel.DataAnnotations to (Fluent) NHibernate.
    /// http://msdn.microsoft.com/en-us/library/dd411803.aspx
    /// http://ayende.com/blog/153569/taking-a-look-at-s-arp-litendash-final-thoughts
    /// http://www.dbones.co.uk/blog/post/2010/8/using-dataannotations-with-nhibernate
    /// </summary>
    public class ValidationListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        /*
         * Wire up like so...
        .ExposeConfiguration(config => { 
            config.EventListeners.PreInsertEventListeners = 
                new IPreInsertEventListener[] { new ValidationListener() };
            config.EventListeners.PreUpdateEventListeners =
                new IPreUpdateEventListener[] { new ValidationListener() };
        })
        */


        private bool ValidateWithNewContext(object obj)
        {
            ValidationContext ctx = new ValidationContext(obj, null, null);
            Validator.ValidateObject(obj, ctx, true);
            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            return ValidateWithNewContext(@event.Entity);
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            return ValidateWithNewContext(@event.Entity);
        }
    }
}
