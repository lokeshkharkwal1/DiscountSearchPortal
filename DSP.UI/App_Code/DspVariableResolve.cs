using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DSP.UI.App_Code
{
    public class DspVariableResolve : ConfigurationSection
    {
        [ConfigurationProperty("loginPage")]
        public LoginPage LoginPage
        {
            get { return (LoginPage)this["loginPage"]; }

        }

        [ConfigurationProperty("searchPage")]
        public SearchPage SearchPage
        {
            get { return (SearchPage)this["searchPage"]; }

        }
    }

    public class Range : ConfigurationElement
    {
        [ConfigurationProperty("minValue")]
        public CustomeElement<string> MinValue
        {
            get { return (CustomeElement<string>)this["minValue"]; }
            set { this["minValue"] = value; }
        }

        [ConfigurationProperty("maxValue")]
        public CustomeElement<string> MaxValue
        {
            get { return (CustomeElement<string>)this["maxValue"]; }
            set { this["maxValue"] = value; }
        }

        [ConfigurationProperty("errorMessage")]
        public CustomeElement<string> ErrorMessage
        {
            get { return (CustomeElement<string>)this["errorMessage"]; }
            set { this["errorMessage"] = value; }
        }
    }

    public class LoginPage : ConfigurationElement
    {
        [ConfigurationProperty("loginPageHeading")]
        public CustomeElement<string> LoginPageHeading
        {
            get { return (CustomeElement<string>)this["loginPageHeading"]; }
            set { this["loginPageHeading"] = value; }
        }

        [ConfigurationProperty("loginLabel")]
        public CustomeElement<string> LoginLabel
        {
            get { return (CustomeElement<string>)this["loginLabel"]; }
            set { this["loginLabel"] = value; }
        }

        [ConfigurationProperty("loginPlaceholder")]
        public CustomeElement<string> LoginPlaceholder
        {
            get { return (CustomeElement<string>)this["loginPlaceholder"]; }
            set { this["loginPlaceholder"] = value; }
        }

        [ConfigurationProperty("loginButtonValue")]
        public CustomeElement<string> LoginButtonValue
        {
            get { return (CustomeElement<string>)this["loginButtonValue"]; }
            set { this["loginButtonValue"] = value; }
        }

        [ConfigurationProperty("invalidLogin")]
        public CustomeElement<string> InvalidLogin
        {
            get { return (CustomeElement<string>)this["invalidLogin"]; }
            set { this["invalidLogin"] = value; }
        }

        [ConfigurationProperty("inactiveUser")]
        public CustomeElement<string> InactiveUser
        {
            get { return (CustomeElement<string>)this["inactiveUser"]; }
            set { this["inactiveUser"] = value; }
        }

        [ConfigurationProperty("loginPattern")]
        public CustomeElement<int> LoginPattern
        {
            get { return (CustomeElement<int>)this["loginPattern"]; }
            set { this["loginPattern"] = value; }
        }

        [ConfigurationProperty("range")]
        public Range Range
        {
            get { return (Range)this["range"]; }
        }

    }

    public class SearchPage : ConfigurationElement
    {

        [ConfigurationProperty("searchPageHeading")]
        public CustomeElement<string> SearchPageHeading
        {
            get { return (CustomeElement<string>)this["searchPageHeading"]; }
            set { this["searchPageHeading"] = value; }
        }

        [ConfigurationProperty("searchLabel")]
        public CustomeElement<string> SearchLabel
        {
            get { return (CustomeElement<string>)this["searchLabel"]; }
            set { this["searchLabel"] = value; }
        }

        [ConfigurationProperty("searchPlaceholder")]
        public CustomeElement<string> SearchPlaceholder
        {
            get { return (CustomeElement<string>)this["searchPlaceholder"]; }
            set { this["searchPlaceholder"] = value; }
        }

        [ConfigurationProperty("searchButtonValue")]
        public CustomeElement<string> SearchButtonValue
        {
            get { return (CustomeElement<string>)this["searchButtonValue"]; }
            set { this["searchButtonValue"] = value; }
        }

        [ConfigurationProperty("searchPanelHeading")]
        public CustomeElement<string> SearchPanelHeading
        {
            get { return (CustomeElement<string>)this["searchPanelHeading"]; }
            set { this["searchPanelHeading"] = value; }
        }

        [ConfigurationProperty("preferredName")]
        public CustomeElement<string> PreferredName
        {
            get { return (CustomeElement<string>)this["preferredName"]; }
            set { this["preferredName"] = value; }
        }

        [ConfigurationProperty("location")]
        public CustomeElement<string> Location
        {
            get { return (CustomeElement<string>)this["location"]; }
            set { this["location"] = value; }
        }

        [ConfigurationProperty("eligibleForDiscount")]
        public CustomeElement<string> EligibleForDiscount
        {
            get { return (CustomeElement<string>)this["eligibleForDiscount"]; }
            set { this["eligibleForDiscount"] = value; }
        }

        [ConfigurationProperty("noResultFound")]
        public CustomeElement<string> NoResultFound
        {
            get { return (CustomeElement<string>)this["noResultFound"]; }
            set { this["noResultFound"] = value; }
        }

        [ConfigurationProperty("range")]
        public Range Range
        {
            get { return (Range)this["range"]; }
        }


    }

    public class CustomeElement<T> : ConfigurationElement
    {
        [ConfigurationProperty("value")]
        public T Value
        {
            get { return (T)this["value"]; }
            set { this["value"] = value; }
        }
    }

}