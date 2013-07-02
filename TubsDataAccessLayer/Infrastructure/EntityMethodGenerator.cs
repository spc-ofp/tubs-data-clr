// -----------------------------------------------------------------------
// <copyright file="EntityMethodGenerator.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2013 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Reflection;
    using NHibernate.Hql.Ast;
    using NHibernate.Linq;
    using NHibernate.Linq.Functions;
    using NHibernate.Linq.Visitors;
    using Remotion.Linq.Parsing.ExpressionTreeVisitors;
    using Spc.Ofp.Tubs.DAL.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Inject HQL as appropriate
    /// http://stackoverflow.com/questions/14578113/extending-linq-to-nhibernate-with-custom-hql-generator
    /// </summary>
    //public class EntityMethodGenerator<T1, T2, TResult> : BaseHqlGeneratorForMethod
    public class EntityMethodGenerator : BaseHqlGeneratorForMethod
    {
        public EntityMethodGenerator()
        {
            var methodDefinition =
                ReflectionHelper.GetMethodDefinition(() => 
                    SecurableExtensions.IsLoadableFor(null, null));

            SupportedMethods = new[] { methodDefinition };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="targetObject">Should be an ISecurable</param>
        /// <param name="arguments">Not sure what the heck arg[0] is, but arg[1] is the entityName</param>
        /// <param name="treeBuilder"></param>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public override HqlTreeNode BuildHql(
            MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            // This works, but it pulls the entity into memory, which is not what we want.
            Expression<Func<ISecurable, string, bool>> IsAllowedExpression = (x, name) => 
                x.IsLoadableFor(name);

            return visitor.Visit(IsAllowedExpression);
        }
        
        
        /*
        public EntityMethodGenerator()
        {
            SupportedMethods = new[]
            {
                ReflectionHelper.GetMethodDefinition<ISecurable>(t => t.IsLoadableFor(string.Empty)),
                //ReflectionHelper.GetMethodDefinition<Trip>(t => t.IsAllowed("xyzzy")),
                //ReflectionHelper.GetMethodDefinition<PurseSeineActivity>(t => t.IsAllowed("xyzzy")),
            };
        }
        */
    }
}
