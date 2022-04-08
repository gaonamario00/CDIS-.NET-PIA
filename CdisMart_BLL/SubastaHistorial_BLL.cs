using System;
using System.Activities.Statements;
using System.Collections.Generic;

using System.Transactions;

using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class SubastaHistorial_BLL
    {

        public void agregarApuestaAHistorial(AuctionRecord auctionRecord, decimal mejorOferta)
        {
            if (auctionRecord.Amount < 0 || auctionRecord.Amount > 1000000)
            {
                throw new Exception("1");
            }
            else
            {
                    if (mejorOferta >= auctionRecord.Amount)
                    {
                        throw new Exception("2");
                    }
                    else
                    {
                        subastaHistorial_DAL subastaHistorial_DAL = new subastaHistorial_DAL();
                        Subasta_DAL subasta_DAL = new Subasta_DAL();

                            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                            {
                            
                                subastaHistorial_DAL.agregarApuestaAHistorial(auctionRecord);
                                subasta_DAL.actualizarMejorOferta(auctionRecord.AuctionId, auctionRecord.Amount, auctionRecord.UserId);
                            
                            ts.Complete();
                            }
                    }
            }
                
        }   
        

        public List<object> cargarUsuariosPorSubasta(int subastaID, int userActual)
        {
            subastaHistorial_DAL cargarHistorial_DAL = new subastaHistorial_DAL();
            return cargarHistorial_DAL.cargarUsuariosPorSubasta(subastaID, userActual);
        }

        public List<AuctionRecord> cargarHistorialPorUsuario(int UserId, int auctionId)
        {
            subastaHistorial_DAL cargarHistorial_DAL = new subastaHistorial_DAL();
            return cargarHistorial_DAL.cargarHistorialPorUsuario(UserId, auctionId);
        }

        public List<AuctionRecord> cargarHistorialPorSubasta(int auctionId)
        {
            subastaHistorial_DAL cargarHistorial_DAL = new subastaHistorial_DAL();
            return cargarHistorial_DAL.cargarHistorialPorSubasta(auctionId);
        }

        public List<AuctionRecord> cargarMiHistorialPorSubasta(int userId, int auctionId)
        {
            subastaHistorial_DAL cargarHistorial_DAL = new subastaHistorial_DAL();
            return cargarHistorial_DAL.cargarMiHistorialPorSubasta(userId, auctionId);
        }
    }
}
