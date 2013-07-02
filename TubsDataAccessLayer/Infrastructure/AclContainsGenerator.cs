// -----------------------------------------------------------------------
// <copyright file="AclContainsGenerator.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AclContainsGenerator : BaseHqlGeneratorForMethod
    {
        public AclContainsGenerator()
        {
            SupportedMethods = new[]
            {
                ReflectionHelper.GetMethodDefinition(() =>
                    SecurableExtensions.AclContains(null, null))
            };
        }

        public HqlTreeNode xBuildHql(
            MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            // arguments[0] is the expression as it already exists
            // arguments[1] is our constant value
            Console.WriteLine("arg[1]: {0}", arguments[1]);
            var value = visitor.Visit(arguments[1]).AsExpression();
            Console.WriteLine("BuildHql value: {0}", value);
            HqlTreeNode inClauseNode;

            if (arguments[0] is ConstantExpression)
            {
                Console.WriteLine("Is constant expression");
                inClauseNode = BuildFromArray((Array)((ConstantExpression)arguments[0]).Value, treeBuilder);
            }
            else
            {
                Console.WriteLine("Building from expression");
                Console.WriteLine("expression: {0}", arguments[0]);
                inClauseNode = BuildFromExpression(arguments[0], visitor);
            }

            HqlTreeNode inClause = treeBuilder.In(value, inClauseNode);

            return inClause;
        }

        private HqlTreeNode BuildFromExpression(Expression expression,
                IHqlExpressionVisitor visitor)
        {
            //TODO: check if it's a valid expression for in clause, 
            //i.e. it selects only one column
            return visitor.Visit(expression).AsExpression();
        }

        private HqlTreeNode BuildFromArray(Array valueArray, HqlTreeBuilder treeBuilder)
        {
            var elementType = valueArray.GetType().GetElementType();

            if (!elementType.IsValueType && elementType != typeof(string))
                throw new ArgumentException("Only primitives and strings can be used");

            Type enumUnderlyingType = elementType.IsEnum ?
            Enum.GetUnderlyingType(elementType) : null;
            var variants = new HqlExpression[valueArray.Length];

            for (int index = 0; index < valueArray.Length; index++)
            {
                var variant = valueArray.GetValue(index);
                var val = variant;

                if (elementType.IsEnum)
                    val = Convert.ChangeType(variant, enumUnderlyingType);

                variants[index] = treeBuilder.Constant(val);
            }

            return treeBuilder.DistinctHolder(variants);
        }



         ///<summary>
         ///
         ///</summary>
         ///<param name="method"></param>
         ///<param name="targetObject">Should be an ISecurable</param>
         ///<param name="arguments">Not sure what the heck arg[0] is, but arg[1] is the entityName</param>
         ///<param name="treeBuilder"></param>
         ///<param name="visitor"></param>
        ///<returns></returns>
        public override HqlTreeNode BuildHql(
            MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            // arguments[0] is a System.Linq.Expressions.Expression
            // arguments[1] is our constant value
            var expr = arguments[0];

            // This doesn't really help us right now, but log it just in case...
            if (expr is Remotion.Linq.Clauses.Expressions.QuerySourceReferenceExpression)
            {
                Console.WriteLine(
                    "ReferencedQuerySource: {0}",
                    ((Remotion.Linq.Clauses.Expressions.QuerySourceReferenceExpression)expr).ReferencedQuerySource
                );
            }

            // Getting somewhere?
            // expr.Type is Spc.Ofp.Tubs.DAL.Entities.Trip
            Console.WriteLine("Expression type: {0}", expr.Type);            

            
            // HqlAlias is "AccessControl" (entity property), "ace" (name used in expression) ?
            // HqlExpression is equality expression ?
            var aceAlias = treeBuilder.Alias("AccessControl as ace");

            var entityName = ((ConstantExpression)arguments[1]).Value;

            Console.WriteLine("entityName: {0}", entityName);

            var equality = treeBuilder.Equality(
                treeBuilder.Alias("ace.EntityName"),
                treeBuilder.Constant(entityName)
            );

            var joinExpression = treeBuilder.Join(equality, aceAlias);

            

            // This doesn't actually do anything...
            return visitor.Visit(expr).AsExpression();
            
            /*
             * var dc = 
                DetachedCriteria.For<T>()
                                .CreateAlias("AccessControl", "ace", JoinType.InnerJoin)
                                .Add(NHibernate.Criterion.Expression.Eq("ace.EntityName", this._entityName));
             */

        }
    }
}
