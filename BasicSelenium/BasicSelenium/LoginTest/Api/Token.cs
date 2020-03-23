using System;
using System.Collections.Generic;
using System.Text;

namespace BasicSelenium.LoginTest.Api
{
    public class Token
    {
        public Token(string token)
        {
            PHPSESSID = token;
        }

        public string PHPSESSID;
    }
}
