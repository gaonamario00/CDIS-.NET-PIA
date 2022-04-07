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

        public List<Auction> cargarSubastas()
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

            int dateIsValid = DateTime.Compare(DateTime.Now, subasta.StartDate);

            if (dateIsValid <= 0)
            {
                dateIsValid = DateTime.Compare(subasta.StartDate, subasta.EndDate);
                if (dateIsValid < 0)
                {
                    if (verificarCantidadDeSubastasDeUsuario(subasta.UserId))
                    {
                        Subasta_DAL subasta_DAL = new Subasta_DAL();
                        subasta_DAL.agregarSubasta(subasta);
                    }else throw new Exception("Limite de subastas vigentes alcanzado alcanzado");
                }
                else throw new Exception("Fecha final invalida");
            }
            else throw new Exception("Fecha inicio invalida");

            
        }

        public void actualizarMejorOferta(int AuctionId, decimal amount, int userId)
        {
            Subasta_DAL subasta = new Subasta_DAL();
            subasta.actualizarMejorOferta(AuctionId, amount, userId);
        }

        public bool verificarCantidadDeSubastasDeUsuario(int userId)
        {

            Subasta_DAL subastas_DAL = new Subasta_DAL();

            var subastas = new List<Auction>();
            subastas = subastas_DAL.cargarSubastas();

            int cantSubastas = 0;


            foreach(Auction subasta in subastas)
            {
                int dateIsValid = DateTime.Compare(subasta.EndDate, DateTime.Now);

                if(dateIsValid > 0)
                {
                    if (subasta.UserId == userId) cantSubastas++;
                }
            }

            if (cantSubastas >= 3) return false;
            else return true;
        }
    }
}
