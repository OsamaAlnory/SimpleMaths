using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleMaths.UI
{
    public class IImage : Image
    {
        public string Src { get; set; }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if(Src != null)
            {
                this.Source = App.GetSource(Src);
            }
        }

    }
}
