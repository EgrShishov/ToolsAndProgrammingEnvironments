using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.Entities
{
    public class ViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ValidTemplate { get; set; }
        public DataTemplate InvalidTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var odd_names = new List<string> { "USD", "CNY", "GBP"};
            return !odd_names.Contains(((Rate)item).Cur_Abbreviation) ? ValidTemplate : InvalidTemplate;
        }
    }
}
