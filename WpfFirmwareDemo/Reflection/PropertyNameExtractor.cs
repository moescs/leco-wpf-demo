// <copyright>Copyright © 2012 LECO® Corporation. All rights reserved.</copyright>

namespace WpfFirmwareDemo.Reflection
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Allows you to use lambda expressions for property names instead of strings
    /// </summary>
    public static class PropertyNameExtractor
    {
        ///<exception cref="ArgumentException"></exception>
        public static string Extract<TOwner, TProperty>(Expression<Func<TOwner, TProperty>> property)
        {
            var propertyExpression = property.Body as MemberExpression;
            var name = propertyExpression?.Member.Name;
            return name;
        }

        ///<exception cref="ArgumentException"></exception>
        public static string Extract<T>(Expression<Func<T>> property)
        {
            var unaryExpression = property.Body as UnaryExpression;
            var memberExpression = unaryExpression == null
                ? property.Body as MemberExpression
                : unaryExpression.Operand as MemberExpression;

            var name = memberExpression?.Member.Name;
            return name;
        }
    }
}
