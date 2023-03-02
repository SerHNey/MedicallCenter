using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicallCenter.Clasees
{
    public struct SignInAttempt
    {
        private string login;
        private DateTime datetime;
        private bool isSuccessful;
        public SignInAttempt(string login, DateTime datetime, bool isSuccessful)
        {
            this.login = login;
            this.datetime = datetime;
            this.isSuccessful = isSuccessful;
        }
    }
}
