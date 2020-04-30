using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Alten.Career.Helpers
{
    public static class PropertyInfoHelper
    {
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                if (propertyExpression.Body is UnaryExpression unaryExpression &&
                    (unaryExpression.NodeType == ExpressionType.Convert))
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
            }

            return memberExpression.Member as PropertyInfo;
        }
    }
}
