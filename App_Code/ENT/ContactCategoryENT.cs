﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryENT
/// </summary>
public class StateENT
{
    public class ContactCategoryENT
    {
        #region Constructor
        public ContactCategoryENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;

        public SqlInt32 ContactCategory
        {
            get
            {
                return _ContactCategoryID;
            }
            set
            {
                _ContactCategoryID = value;
            }
        }
        #endregion ContactCategoryID

        #region ContactCategoryName
        protected SqlString _ContactCategoryName;

        public SqlString ContactCategoryName
        {
            get
            {
                return _ContactCategoryName;
            }
            set
            {
                _ContactCategoryName = value;
            }
        }
        #endregion ContactCategoryName

        #region CreationDate
        protected SqlDateTime _CreationDate;

        public SqlDateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                _CreationDate = value;
            }
        }
        #endregion CreationDate

    }
}