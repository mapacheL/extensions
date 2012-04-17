﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signum.Entities.Operations;
using Signum.Utilities;
using Signum.Entities.Reflection;
using Signum.Utilities.Reflection;
using Signum.Engine.DynamicQuery;
using Signum.Engine.Linq;
using Signum.Engine.Extensions.Properties;
using Signum.Utilities.ExpressionTrees;
using System.Linq.Expressions;
using System.Reflection;
using Signum.Entities;
using Signum.Engine.Maps;
using System.IO;

namespace Signum.Engine.Help
{
    public static class HelpGenerator
    {
        public static string GetPropertyHelp(PropertyRoute pr)
        {
            string validations = Validator.GetOrCreatePropertyPack(pr).Validators.CommaAnd(v => v.HelpMessage);

            Implementations imp = Schema.Current.FindImplementations(pr); 

            if (validations.HasText())
                validations = Resources.Should + validations;

            if (Reflector.IsIIdentifiable(pr.Type))
            {
                return EntityProperty(pr, pr.Type, pr.Type.TypeLinks(imp)) + validations;
            }
            else if (pr.Type.IsLite())
            {
                Type cleanType = Reflector.ExtractLite(pr.Type);

                return EntityProperty(pr, cleanType, cleanType.TypeLinks(imp)) + validations;
            }
            else if (Reflector.IsEmbeddedEntity(pr.Type))
            {
                return EntityProperty(pr, pr.Type, pr.Type.NiceName());
            }
            else if (Reflector.IsMList(pr.Type))
            {
                Type elemType = pr.Type.ElementType();

                if (elemType.IsIIdentifiable())
                {
                    return Resources._0IsACollectionOfElements1.Formato(pr.PropertyInfo.NiceName(), elemType.TypeLinks(imp)) + validations;
                }
                else if (elemType.IsLite())
                {
                    return Resources._0IsACollectionOfElements1.Formato(pr.PropertyInfo.NiceName(), Reflector.ExtractLite(elemType).TypeLinks(imp)) + validations;
                }
                else if (Reflector.IsEmbeddedEntity(elemType))
                {
                    return Resources._0IsACollectionOfElements1.Formato(pr.PropertyInfo.NiceName(), elemType.NiceName()) + validations;
                }
                else
                {
                    string valueType = ValueType(pr.Add("Item"));
                    return Resources._0IsACollectionOfElements1.Formato(pr.PropertyInfo.NiceName(), valueType) + validations;
                }
            }
            else
            {
                string valueType = ValueType(pr);

                Gender gender = NaturalLanguageTools.GetGender(valueType);

                return Resources.ResourceManager.GetGenderAwareResource("_0IsA1", gender).Formato(pr.PropertyInfo.NiceName(), valueType) + validations;
            }
        }

        static string EntityProperty(PropertyRoute pr, Type propertyType, string typeName)
        {
            if (pr.PropertyInfo.IsDefaultName())
                return
                    propertyType.GetGenderAwareResource(() => Resources.The0).Formato(typeName) + " " +
                    pr.Parent.Type.GetGenderAwareResource(() => Resources.OfThe0).Formato(pr.Parent.Type.NiceName());
            else
                return
                    propertyType.GetGenderAwareResource(() => Resources._0IsA1).Formato(pr.PropertyInfo.NiceName(), typeName);
        }

        static string ValueType(PropertyRoute pr)
        {
            Type type = pr.Type;
            string format = Reflector.FormatString(pr);
            string unit = pr.PropertyInfo.SingleAttribute<UnitAttribute>().TryCC(u=>u.UnitName);
            return ValueType(type, format, unit);
        }

        private static string ValueType(Type type, string format, string unit)
        {
            Type cleanType = Nullable.GetUnderlyingType(type) ?? type;

            string typeName =
                    cleanType.IsEnum ? Resources.ValueLike0.Formato(Enum.GetValues(cleanType).Cast<Enum>().CommaOr(e => e.NiceToString())) :
                    cleanType == typeof(decimal) && unit != null && unit == "€" ? Resources.Amount :
                    cleanType == typeof(DateTime) && format == "d" ? Resources.Date :
                    NaturalTypeDescription(cleanType);

            string orNull = Nullable.GetUnderlyingType(type) != null ? Resources.OrNull : null;

            return typeName.Add(" ", unit != null ? Resources.ExpressedIn + unit : null).Add(" ", orNull);
        }

        static string TypeLinks(this Type type, Implementations implementations)
        {
            if (implementations == null)
                return type.TypeLink();
            if (implementations.IsByAll)
                return Resources.Any + " " + type.TypeLink();
            return ((ImplementedByAttribute)implementations).ImplementedTypes.CommaOr(TypeLink);
        }

        static string TypeLink(this Type type)
        {
            string cleanName = TypeLogic.TryGetCleanName(type);
            if (cleanName.HasText())
                return "[e:" + cleanName + "]";
            return type.NiceName();
        }

        static string PropertyLink(this PropertyRoute route)
        {
            string cleanName = TypeLogic.GetCleanName(route.RootType);
            return "[p:" + cleanName + "." + route.PropertyString() + "]";
        }

        static string NaturalTypeDescription(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return Resources.Check;

                case TypeCode.Char:
                    return Resources.Character;

                case TypeCode.DateTime:
                    return Resources.DateTime;

                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return Resources.Integer;

                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return Resources.Value;

                case TypeCode.String:
                    return Resources.String;
            }

            return type.Name;
        }

        public static string GetOperationHelp(Type type, OperationInfo operationInfo)
        {
            switch (operationInfo.OperationType)
            {
                case OperationType.Execute: return type.GetGenderAwareResource(()=>Resources.Call0Over1OfThe2).Formato(
                    operationInfo.Key.NiceToString(),
                    operationInfo.Lite.Value ? Resources.TheDatabaseVersion : Resources.YourVersion, 
                    type.NiceName());
                case OperationType.Delete: return Resources.RemovesThe0FromTheDatabase.Formato(type.NiceName());
                case OperationType.Constructor: return
                    type.GetGenderAwareResource(() => Resources.ConstructsANew0).Formato(type.NiceName());
                case OperationType.ConstructorFrom: return
                    operationInfo.ReturnType.GetGenderAwareResource(() => Resources.ConstructsANew0).Formato(operationInfo.ReturnType.NiceName()) + " " +
                    type.GetGenderAwareResource(()=>Resources.From0OfThe1).Formato(operationInfo.Lite.Value ? Resources.TheDatabaseVersion  : Resources.YourVersion, type.NiceName());
                case OperationType.ConstructorFromMany: return
                    operationInfo.ReturnType.GetGenderAwareResource(()=>Resources.ConstructsANew0).Formato(operationInfo.ReturnType.NiceName()) + " " +
                    type.GetGenderAwareResource(()=>Resources.FromMany0).Formato(type.NicePluralName());
            }

            return "";
        }

        public static string GetQueryHelp(IDynamicQuery dynamicQuery)
        {
            ColumnDescriptionFactory cdf = dynamicQuery.EntityColumn();

            return Resources.QueryOf0.Formato(cdf.Type.CleanType().TypeLinks(cdf.Implementations));
        }

        internal static string GetQueryColumnHelp(ColumnDescriptionFactory kvp)
        {
            string typeDesc = QueryColumnType(kvp);

            if (kvp.PropertyRoutes != null)
                return Resources._0IsA1AndShowsTheProperty2.Formato(kvp.DisplayName(), typeDesc, kvp.PropertyRoutes.ToString(pr=>PropertyLink(pr), ", "));
            else
                return Resources._0IsACalculated1.Formato(kvp.DisplayName(), typeDesc);
        }

        private static string QueryColumnType(ColumnDescriptionFactory kvp)
        {
            var cleanType = kvp.Type.CleanType();

            if (Reflector.IsIIdentifiable(cleanType))
            {
                return cleanType.TypeLinks(kvp.Implementations);
            }
            else if (Reflector.IsEmbeddedEntity(kvp.Type))
            {
                return kvp.Type.NiceName();
            }
            else
            {
                return ValueType(kvp.Type, kvp.Format, kvp.Unit);
            }
        }
    }
}
