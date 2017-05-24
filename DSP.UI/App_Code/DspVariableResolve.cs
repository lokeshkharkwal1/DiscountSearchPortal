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
        public int MinValue
        {
            get { return (int)this["minValue"]; }
            set { this["minValue"] = value; }
        }

        [ConfigurationProperty("maxValue")]
        public int MaxValue
        {
            get { return (int)this["maxValue"]; }
            set { this["maxValue"] = value; }
        }

        [ConfigurationProperty("errorMessage")]
        public string ErrorMessage
        {
            get { return (string)this["errorMessage"]; }
            set { this["errorMessage"] = value; }
        }
    }

    public class LoginPage : ConfigurationElement
    {
        [ConfigurationProperty("jobCodesAllowedToLogin")]
        public CustomeElement<string> JobCodesAllowedToLogin
        {
            get { return (CustomeElement<string>)this["jobCodesAllowedToLogin"]; }
            set { this["jobCodesAllowedToLogin"] = value; }
        }

        [ConfigurationProperty("loginPageHeading")]
        public CustomeElement<string> LoginPageHeading
        {
            get { return (CustomeElement<string>)this["loginPageHeading"]; }
            set { this["loginPageHeading"] = value; }
        }

        [ConfigurationProperty("loginFieldLabel")]
        public CustomeElement<string> LoginFieldLabel
        {
            get { return (CustomeElement<string>)this["loginFieldLabel"]; }
            set { this["loginFieldLabel"] = value; }
        }

        [ConfigurationProperty("loginFieldPlaceholder")]
        public CustomeElement<string> LoginFieldPlaceholder
        {
            get { return (CustomeElement<string>)this["loginFieldPlaceholder"]; }
            set { this["loginFieldPlaceholder"] = value; }
        }

        [ConfigurationProperty("loginButtonValue")]
        public CustomeElement<string> LoginButtonValue
        {
            get { return (CustomeElement<string>)this["loginButtonValue"]; }
            set { this["loginButtonValue"] = value; }
        }

        [ConfigurationProperty("errorMessageIfUserNotFound")]
        public CustomeElement<string> ErrorMessageIfUserNotFound
        {
            get { return (CustomeElement<string>)this["errorMessageIfUserNotFound"]; }
            set { this["errorMessageIfUserNotFound"] = value; }
        }

        [ConfigurationProperty("errorMessageIfUserNotActive")]
        public CustomeElement<string> ErrorMessageIfUserNotActive
        {
            get { return (CustomeElement<string>)this["errorMessageIfUserNotActive"]; }
            set { this["errorMessageIfUserNotActive"] = value; }
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

        [ConfigurationProperty("searchFieldLabel")]
        public CustomeElement<string> SearchFieldLabel
        {
            get { return (CustomeElement<string>)this["searchFieldLabel"]; }
            set { this["searchFieldLabel"] = value; }
        }

        [ConfigurationProperty("searchFieldPlaceholder")]
        public CustomeElement<string> SearchFieldPlaceholder
        {
            get { return (CustomeElement<string>)this["searchFieldPlaceholder"]; }
            set { this["searchFieldPlaceholder"] = value; }
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