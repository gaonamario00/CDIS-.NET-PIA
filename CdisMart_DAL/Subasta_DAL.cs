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

        public List<Auction> cargarSubastas()
        {
            var subastas = from s in model.Auction
                           select s;
            return subastas.ToList();
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

        public void actualizarMejorOferta(int AuctionId, decimal amount, int winner)
        {
            var subasta = (from s in model.Auction
                          where s.AuctionId == AuctionId
                          select s).FirstOrDefault();

            subasta.HighestBid = amount;
            subasta.Winner = winner;

            model.SaveChanges();

        }

    }
}
