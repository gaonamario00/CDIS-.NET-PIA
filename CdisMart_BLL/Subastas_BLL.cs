using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class Subastas_BLL
    {

        public List<Object> cargarSubastas()
        {
            Subasta_DAL subasta_DAL = new Subasta_DAL();
            return subasta_DAL.cargarSubastas();
        }

        public Auction cargarSubastaPorID(int AuctionID)
        {
            Subasta_DAL subasta_DAL = new Subasta_DAL();
            return subasta_DAL.cargarSubastaPorID(AuctionID);
        }

        public void agregarSubasta(Auction subasta)
        {
            Subasta_DAL subasta_DAL = new Subasta_DAL();
            subasta_DAL.agregarSubasta(subasta);
        }

        public void actualizarMejorOferta(int AuctionId, decimal amount, int userId)
        {
            Subasta_DAL subasta = new Subasta_DAL();
            subasta.actualizarMejorOferta(AuctionId, amount, userId);
        }
    }
}
