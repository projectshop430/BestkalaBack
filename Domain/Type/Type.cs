using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Type
{
    public class Type
    {
        public enum SaveResulte
        {
            success,
            error,
            exit,
        }
        public enum RegisterResult
        {
            success,
            error,
            Emailexit,
        }

        public enum LoginResult
        {
            success,
            error,
            Emailexit,
            EmailNotAcitve,
            EmailNotfound
        }

        public enum FavoriteResult
        {
            success,
            error,
            IDexit,
            IDNotfound,
            IdProductNotexit

        }

       
    }
}

