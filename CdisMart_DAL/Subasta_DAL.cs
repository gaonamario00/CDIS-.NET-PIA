using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class Subasta_DAL
    {
        CdisMartEntities model;

        public Subasta_DAL()
        {
            model = new CdisMartEntities();
        }

        public List<Object> cargarSubastas()
        {
            var subastas = from s in model.Auction
                           select new
                           {
                               AuctionId = s.AuctionId,
                               ProductoName = s.ProductoName,
                               Description = s.Description,
                               StartDate = s.StartDate,
                               EndDate = s.EndDate,
                               //HighestBid = s.HighestBid,
                               //Winner = s.Winner,
                               //UserId = s.UserId
                           };
            return subastas.AsEnumerable<Object>().ToList();
        }

        public Auction cargarSubastaPorID(int AuctionID)
        {
            var subasta = (from s in model.Auction
                           where s.AuctionId == AuctionID
                           select s).FirstOrDefault();
            return subasta;
        }

        public void agregarSubasta(Auction subasta)
        {
            model.Auction.Add(subasta);
            model.SaveChanges();
        }

    }
}
