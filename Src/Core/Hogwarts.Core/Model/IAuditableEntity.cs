﻿namespace Hogwarts.Core.Model
{
    using System;


    public interface IAuditableEntity
    {
        DateTime CreatedAt
        {
            get;
            set;
        }

        string CreatedBy
        {
            get;
            set;
        }

        DateTime UpdatedAt
        {
            get;
            set;
        }

        string UpdatedBy
        {
            get;
            set;
        }
    }
}