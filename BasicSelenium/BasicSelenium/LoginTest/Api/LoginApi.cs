using System;
using RestSharp;

namespace BasicSelenium.LoginTest.Api
{
    public static class LoginApi
    {
        public static string Login2(User user)
        {
            var client = new RestClient("https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/");
            var request = new RestRequest("auth/validateCredentials", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"actionID=&hdnUserTimeZoneOffset=2&txtUsername={user.Username}&txtPassword={user.Password}&Submit=LOGIN", ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.Cookies[0].Value;
        }


        public static  Token Login(User user, Token token = null)
        {
            var client = new RestClient("https://s2.demo.opensourcecms.com/orangehrm/symfony/web/index.php/");
            var request = new RestRequest("/auth/validateCredentials", Method.POST);
            request.AddHeader("Content-Type", " application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"actionID=&hdnUserTimeZoneOffset=2&txtUsername={user.Username}&txtPassword={user.Password}&Submit=LOGIN", ParameterType.RequestBody);
            if(token != null)
                request.AddCookie("PHPSESSID", token.PHPSESSID);
            var response = client.Execute(request);
            Console.WriteLine(response.Cookies[0].Value);
            return new Token(response.Cookies[0].Value);
        }
    }
}
