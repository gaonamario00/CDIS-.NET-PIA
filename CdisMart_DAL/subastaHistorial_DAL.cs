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

    }
}
