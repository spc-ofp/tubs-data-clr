// -----------------------------------------------------------------------
// <copyright file="AccessDeniedException.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
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
    using System.Runtime.Serialization;

    /// <summary>
    /// AccessDeniedException is a custom exception used to implement security.
    /// It appears that throwing an Exception is the only way to prevent an entity load
    /// from the NHibernate 'Load' lifecycle.
    /// </summary>
    [Serializable]
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException() : base() { }

        public AccessDeniedException(string message)
            : base(message) { }
    
        public AccessDeniedException(string format, params object[] args)
            : base(string.Format(format, args)) { }
    
        public AccessDeniedException(string message, Exception innerException)
            : base(message, innerException) { }
    
        public AccessDeniedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected AccessDeniedException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }
}
