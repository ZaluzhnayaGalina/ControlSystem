using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ControlSystem.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace ControlSystemClient
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(ConfirmLogin, p=>!string.IsNullOrEmpty(Login));
        }
        public ICommand LoginCommand { get; set; }
        public string Login { get; set; }
        public bool Success { get; set; } = false;
    
        private async void ConfirmLogin(object p)
        {
            var values = (object[])p;
            var passwordBox = values[0] as PasswordBox;
            if (passwordBox is null)
                return;
            var password = passwordBox.Password;
            if (string.IsNullOrEmpty(password))
                return;
            var hashSalt = GetSalt(password);
            using (var client = NewHttpClient())
            {
                var response = await client.GetAsync($"api/user/byName?name={Login}&passwordSalt={hashSalt}");
                if (response.IsSuccessStatusCode)
                {
                   Success = await response.Content.ReadAsAsync<bool>();
                    if (Success)
                    {
                        var window = values[1] as Window;
                        window?.Close();
                    }

                }
            }
        }

        private HttpClient NewHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:53363/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private string GetSalt(string password)
        {
            var shaM = new SHA256Managed();
            //создание хэша пароля
            string hash = BitConverter.ToString(shaM.ComputeHash(Encoding.UTF8.GetBytes(password)));
            //создание хэша от (хэш пароля + имя пользователя)
            string hashSalt = BitConverter.ToString(shaM.ComputeHash(Encoding.UTF8.GetBytes(hash + Login)));
            return hashSalt;
        }
    }
}
