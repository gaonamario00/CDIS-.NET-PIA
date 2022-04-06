using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class SubastaHistorial_BLL
    {

        public void agregarApuestaAHistorial(AuctionRecord auctionRecord)
        {
            subastaHistorial_DAL subastaHistorial_DAL = new subastaHistorial_DAL();
            subastaHistorial_DAL.agregarApuestaAHistorial(auctionRecord);
        }

        public List<object> cargarUsuariosPorSubasta(int subastaID, int userActual)
        {
            subastaHistorial_DAL cargarHistorial_DAL = new subastaHistorial_DAL();
            return cargarHistorial_DAL.cargarUsuariosPorSubasta(subastaID, userActual);
        }

        public List<AuctionRecord> cargarHistorialPorUsuario(int UserId)
        {
            subastaHistorial_DAL cargarHistorial_DAL = new subastaHistorial_DAL();
            return cargarHistorial_DAL.cargarHistorialPorUsuario(UserId);
        }
    }
}
