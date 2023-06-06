using System.Reflection;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web;
using System;

namespace WebFormUtility
{
    public static class RequestHelper
    {
        public static T Get<T>() where T : class, new()
        {
            T result = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                string value = HttpContext.Current.Request.QueryString[prop.Name];
                if (!string.IsNullOrEmpty(value))
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(prop.PropertyType);
                    prop.SetValue(result, converter.ConvertTo(value, prop.PropertyType));
                }
            }
            return result;
        }

        public static T Post<T>() where T : class, new()
        {
            T result = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                string value = HttpContext.Current.Request.Form[prop.Name];
                if (!string.IsNullOrEmpty(value))
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(prop.PropertyType);
                    prop.SetValue(result, converter.ConvertTo(value, prop.PropertyType));
                }
            }
            return result;
        }
    }

    public class ResponseHelper : Page
    {
        /*
        private readonly Page page;
        public ResponseHelper(Page page)
        {
            this.page = page;
        }
        */
        public void ResModel<T>(T Item) where T : class, new()
        {
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                var control = FindControl(prop.Name);
                if (control != null)
                {
                    DisplayValue(control, prop.GetValue(Item));
                }
            }
        }

        private void DisplayValue(Control control, object value)
        {
            string typeName = control.GetType().Name;
            switch (typeName)
            {
                case "TextBox":
                    (control as TextBox).Text = value != null ? value.ToString() : string.Empty;
                    break;
                case "Label":
                    (control as Label).Text = value != null ? value.ToString() : string.Empty;
                    break;
                case "DropDownList":
                    (control as DropDownList).SelectedValue = value != null ? value.ToString() : string.Empty;
                    break;
            }
        }
    }
}
