﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClaseMagistralSemana6
{
    public partial class MainPage : ContentPage
    {
       // private const string Url = "http://localhost/proyecto/post.php";
        private const string Url = "http://eyecomers.com/estudiante.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ClaseMagistralSemana6.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            obtener();
        }

        public async void obtener( )
        {
            var content = await client.GetStringAsync(Url);
            List<ClaseMagistralSemana6.Datos> posts = JsonConvert.DeserializeObject<List<ClaseMagistralSemana6.Datos>>(content);
            _post = new ObservableCollection<ClaseMagistralSemana6.Datos>(posts);

            MyListView.ItemsSource = _post;

        }


        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}
