﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoFinalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarDetalle : ContentPage
    {
        public EditarDetalle()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}