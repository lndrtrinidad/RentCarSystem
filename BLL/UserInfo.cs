using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarSystem.BLL
{
    //Esta clase me ayuda a validar la informacion de usuario para asi no tener que poner el Login en el starupi
    public static class UserInfo
    {
        public static bool IsLoggedIn { get; set; }
    }
}
