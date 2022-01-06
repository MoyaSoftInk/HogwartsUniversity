﻿namespace Hogwarts.Core.Validator
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    /// <summary>
    /// Static class capable of readinng de DataAnnotations of a type and return a list of corresponding IValidationInfos.
    /// </summary>
    internal static class DataAnnotationHelper
    {
        public static string ParseDisplayName(Type entityType, string propertyName)
        {
            string displayName = propertyName;

            DisplayAttribute displayAttribute = TypeDescriptor.GetProperties(entityType)
                                                .Cast<PropertyDescriptor>()
                                                .Where(p => p.Name == propertyName)
                                                .SelectMany(p => p.Attributes.OfType<DisplayAttribute>()).FirstOrDefault();

            if (displayAttribute != null)
            {
                displayName = displayAttribute.Name;
            }

            return displayName;
        }
    }
}
