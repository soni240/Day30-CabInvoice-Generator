﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class Ride
    {
        //Creating Variables
        public double distance;
        public int time;

        //Initializes a new instance of the Ride class.
        //getting values of distance and times
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
