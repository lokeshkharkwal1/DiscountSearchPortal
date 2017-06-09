using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DSP.Helper
{

    public class DspConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("defaultBrandName", IsRequired = true)]
        public string DefaultBrandName
        {
            get { return (string)this["defaultBrandName"]; }

        }


        [ConfigurationProperty("allBrands")]
        public DspCollection AllBrands
        {
            get { return (DspCollection)this["allBrands"]; }
            set { this["allBrands"] = value; }
        }
    }

    [ConfigurationCollection(typeof(BrandConfiguration),AddItemName="addBrand")]
    public class DspCollection : ConfigurationElementCollection 
    {
        protected override void BaseAdd(ConfigurationElement element)
        {
            base.BaseAdd(element);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new BrandConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BrandConfiguration)element).BrandName;
        }



        new public BrandConfiguration this[string brandName]
        {
            get
            {
                return (BrandConfiguration)BaseGet(brandName);
            }
        }

        public void Add(BrandConfiguration brandConfig)
        {
            BaseAdd(brandConfig);            
        }
    }

    public class BrandConfiguration : ConfigurationElement
    {

        [ConfigurationProperty("brandName", IsKey=true, IsRequired=true)]
        public string BrandName
        {
            get { return (string)this["brandName"]; }

        }

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

        [ConfigurationProperty("uiLogoAndBanner")]
        public UiLogoAndBanner UiLogoAndBanner 
        {
            get { return (UiLogoAndBanner)this["uiLogoAndBanner"]; }
        }

        [ConfigurationProperty("customError")]
        public CustomError CustomError 
        {
            get { return (CustomError)this["customError"]; }
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

    public class UiLogoAndBanner : ConfigurationElement
    {
        [ConfigurationProperty("backgroundColor")]
        public CustomeElement<string> BackgroundColor
        {
            get { return (CustomeElement<string>)this["backgroundColor"]; }
            set { this["backgroundColor"] = value; }

        }

        [ConfigurationProperty("brandLogoPath")]
        public CustomeElement<string> BrandLogoPath
        {
            get { return (CustomeElement<string>)this["brandLogoPath"]; }
            set { this["brandLogoPath"] = value; }
        }

        [ConfigurationProperty("brandBannerPath")]
        public CustomeElement<string> BrandBannerPath
        {
            get { return (CustomeElement<string>)this["brandBannerPath"]; }
            set { this["brandBannerPath"] = value; }
        }

    }

    public class CustomError : ConfigurationElement 
    {
        [ConfigurationProperty("errorMessage")]
        public CustomeElement<string> ErrorMessage 
        {
            get { return (CustomeElement<string>)this["errorMessage"]; }
            set { this["errorMessage"] = value; }
        }

        [ConfigurationProperty("errorLogLocation")]
        public CustomeElement<string> ErrorLogLocation
        {
            get { return (CustomeElement<string>)this["errorLogLocation"]; }
            set { this["errorLogLocation"] = value; }
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

        [ConfigurationProperty("errorMessageIfUserNotAllowedToLogin")]
        public CustomeElement<string> ErrorMessageIfUserNotAllowedToLogin
        {
            get { return (CustomeElement<string>)this["errorMessageIfUserNotAllowedToLogin"]; }
            set { this["errorMessageIfUserNotAllowedToLogin"] = value; }
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