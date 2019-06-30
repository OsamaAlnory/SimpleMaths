﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleMaths.UI
{
    public class ILabel : Label, Translatable
    {
        public string TText { get; set; }

        public void OnRefresh()
        {
            if (TText != null)
            {
                this.Text = App.STRINGS[TText];
            }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            OnRefresh();
        }

    }
}
