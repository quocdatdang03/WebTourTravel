using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTourTravel.Models
{
    public class ModelInfoBooking
    {
        public Tour tour { get; set; }
        public int soLuongCon { get; set; }

        public ModelInfoBooking(Tour tour, int slc) {
            this.tour = tour;
            this.soLuongCon = slc;
        }

    }
}