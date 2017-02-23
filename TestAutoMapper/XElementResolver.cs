using System;
using System.Xml.Linq;
using AutoMapper;

namespace TestAutoMapper
{
    public class XElementResolver<T> : IValueResolver<ITweetContract,XElement, T>
    {


        #region Implementation of IValueResolver<in ITweetContract,in XElement,T>
        /// <summary>
        /// Implementors use source object to provide a destination object.
        /// </summary>
        /// <param name="source">Source object</param><param name="destination">Destination object, if exists</param><param name="destMember">Destination member</param><param name="context">The context of the mapping</param>
        /// <returns>
        /// Result, typically build from the source resolution result
        /// </returns>
        public T Resolve(ITweetContract source, XElement destination, T destMember, ResolutionContext context)
        {
            return destMember;
        }
        #endregion
    }
}