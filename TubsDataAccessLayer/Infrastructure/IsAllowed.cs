// -----------------------------------------------------------------------
// <copyright file="IsAllowed.cs" company="SPC">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Tubs.DAL.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate.Linq.Functions;
    using System.Reflection;
    using NHibernate.Hql.Ast;
    using System.Collections.ObjectModel;
    using NHibernate.Linq.Visitors;
    using System.Linq.Expressions;

    /// <summary>
    /// TODO: Update summary.
    /// Is it possible to add a runtime HQL generator based on the .Like() ?
    /// method as implemented in NHibernate 3.3.3
    /// (sketch of implementation found here: https://nhibernate.jira.com/browse/NH-3301)
    /// </summary>
    public class IsAllowed : IRuntimeMethodHqlGenerator
    {
        private readonly IHqlGeneratorForMethod generator = new IsAllowedGenerator();

        public bool SupportsMethod(MethodInfo method)
        {
            return
                method != null &&
                method.Name == "IsAllowed" &&
                method.DeclaringType != null &&
                method.DeclaringType.FullName == "Foo";
        }

        public IHqlGeneratorForMethod GetMethodGenerator(MethodInfo method)
        {
            return generator;
        }
    }

    public class IsAllowedGenerator : IHqlGeneratorForMethod
    {
        public IEnumerable<MethodInfo> SupportedMethods
        {
            get { throw new NotSupportedException(); }
        }

        
        public HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Like(
                visitor.Visit(arguments[0]).AsExpression(),
                visitor.Visit(arguments[1]).AsExpression());
        }
        
    }
}
