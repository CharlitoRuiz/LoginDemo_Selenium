using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemo.POJO
{
    public class loginData
    {
        public Truelogin trueLogin { get; set; }
        public Badlogin badlogin { get; set; }

        public class Truelogin
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        public class Badlogin
        {
            public string username { get; set; }
            public string password { get; set; }
        }

    }
}
