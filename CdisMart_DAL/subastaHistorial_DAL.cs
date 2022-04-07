using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class subastaHistorial_DAL
    {
        CdisMartEntities model;

        public subastaHistorial_DAL() {
            model = new CdisMartEntities();
        }

        public void agregarApuestaAHistorial(AuctionRecord auctionRecord)
        {
            model.AuctionRecord.Add(auctionRecord);
            model.SaveChanges();
        }

        public List<Object> cargarUsuariosPorSubasta(int subastaID, int userActual)
        {
            var subastas = from sub in model.AuctionRecord
                           where sub.AuctionId == subastaID
                           where sub.UserId != userActual
                           from userNames in model.UserTable
                           where sub.UserId == userNames.UserId
                           select new  { UserId = sub.UserId, UserName = userNames.UserName };

            HashSet<Object> resultHash = new HashSet<Object>(subastas.AsEnumerable<Object>().ToList());
            List<Object> result = resultHash.ToList();

            return result;
        }

        public List<AuctionRecord> cargarHistorialPorUsuario(int UserId)
        {
            var subastas = from sub in model.AuctionRecord
                           where sub.UserId == UserId
                           select sub;
            return subastas.ToList();
        }

        public List<AuctionRecord> cargarHistorialPorSubasta(int auctionId)
        {
            var subastas = from sub in model.AuctionRecord
                           where auctionId == sub.AuctionId
                           select sub;
            return subastas.ToList();
        }

        public List<AuctionRecord> cargarMiHistorialPorSubasta(int userId, int auctionId)
        {
            var subastas = from sub in model.AuctionRecord
                           where auctionId == sub.AuctionId
                           where userId == sub.UserId
                           select sub;
            return subastas.ToList();
        }
    }
}
