// <copyright>Copyright © 2012 LECO® Corporation. All rights reserved.</copyright>

namespace WpfFirmwareDemo.WpfHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Windows;
    using WpfFirmwareDemo.Reflection;

    public static class DependencyPropertyHelpers
    {
        ///<exception cref="ArgumentException"></exception>
        public static DependencyProperty Register<TOwner, TProperty>(
            Expression<Func<TOwner, TProperty>> propertyExpression,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            var name = PropertyNameExtractor.Extract(propertyExpression);
            var property = DependencyProperty.Register(
                name, typeof(TProperty), typeof(TOwner), propertyMetadata, validateValueCallback);
            return property;
        }

        ///<exception cref="ArgumentException"></exception>
        public static DependencyPropertyKey RegisterReadOnly<TOwner, TProperty>(
            Expression<Func<TOwner, TProperty>> propertyExpression,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            var name = PropertyNameExtractor.Extract(propertyExpression);
            var propertyKey = DependencyProperty.RegisterReadOnly(
                name, typeof(TProperty), typeof(TOwner), propertyMetadata, validateValueCallback);
            return propertyKey;
        }

        ///<exception cref="ArgumentException"></exception>
        public static DependencyProperty RegisterAttached<TDependencyObject, TProperty>(
            Expression<Func<TDependencyObject, TProperty>> methodExpression,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null) where TDependencyObject : DependencyObject
        {
            var tuple = GetNameAndDeclaringType(methodExpression);
            var name = tuple.Item1;
            var ownerType = tuple.Item2;

            var property = DependencyProperty.RegisterAttached(
                // ReSharper disable once AssignNullToNotNullAttribute
                name, typeof(TProperty), ownerType, propertyMetadata, validateValueCallback);
            return property;
        }

        ///<exception cref="ArgumentException"></exception>
        public static DependencyPropertyKey RegisterAttachedReadOnly<TDependencyObject, TProperty>(
            Expression<Func<TDependencyObject, TProperty>> methodExpression,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null) where TDependencyObject : DependencyObject
        {
            var tuple = GetNameAndDeclaringType(methodExpression);
            var name = tuple.Item1;
            var ownerType = tuple.Item2;

            var propertyKey = DependencyProperty.RegisterAttachedReadOnly(
                // ReSharper disable once AssignNullToNotNullAttribute
                name, typeof(TProperty), ownerType, propertyMetadata, validateValueCallback);
            return propertyKey;
        }

        static Tuple<string, Type> GetNameAndDeclaringType<TDependencyObject, TProperty>(
            Expression<Func<TDependencyObject, TProperty>> methodExpression)
        {
            var methodCallExpression = (MethodCallExpression)methodExpression.Body;
            var methodInfo = methodCallExpression.Method;

            var getName = methodInfo.Name;
            //Rip off "Get" prefix
            var name = getName.Substring(3, getName.Length - 3);

            var ownerType = methodInfo.DeclaringType;

            return Tuple.Create(name, ownerType);
        }

    }
}
