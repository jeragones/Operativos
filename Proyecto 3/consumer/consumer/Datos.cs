using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Datos
    {
        static MensajesDataContext db = new MensajesDataContext();

        public static void guardar(string msg)
        {
            mensaje mj = new mensaje();
            mj.msg = msg;
            db.mensajes.InsertOnSubmit(mj);
            db.SubmitChanges();
        }
    }
}
