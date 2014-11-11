using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumer
{
    class Datos
    {
        MensajesDataContext db = new MensajesDataContext();

        public void guardar(string msg) 
        {
            mensaje mj = new mensaje();
            mj.msg = msg;
            db.mensajes.InsertOnSubmit(mj);
            db.SubmitChanges();
        }

    }
}
