﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        //Create Variables 
        //Create Constants
        RideType rideType;
        private RideRepository rideRepository;
        private double averageFarePerRide;
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;


        //Initializes a new instance of the class.
        //Creating Method
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        // Calculates the fare.     
        // Create Method
        // Invalid Time
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
    }
    // Calculates the fare for array of rides
    // for checking total fare
    // Adding Method 
    public InvoiceSummary CalculateFare(Ride[] rides)
    {
        double totalFare = 0;
        // checks for rides available and passes them to calculate fare method to calculate fare for each method
        try
        {
            //calculating total fare for all rides
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
        }
        //catches exception if available
        catch (CabInvoiceException)
        {
            //If no rides there then throw exception
            if (rides == null)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no rides found");
            }
        }
        //returns invoice summary object 
        return new InvoiceSummary(rides.Length, totalFare);
    }

    double CalculateFare(double distance, int time)
    {
        throw new NotImplementedException();
    }

    // Adds the rides in dictionary with key as a user id 
    //Adding Method
    public void AddRides(string userId, Ride[] rides)
    {
        try
        {
            object rideRepository = null;
            rideRepository.AddRide(userId, rides);
        }
        catch (CabInvoiceException)
        {
            if (rides == null)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null rides");
            }
        }
    }
    //Gets the invoice summary by passing user id into ride repository and then passing rides array to calculate fares.
    public InvoiceSummary GetInvoiceSummary(string userId)
    {
        try
        {
            return this.CalculateFare(rideRepository.GetRides(userId));
        }
        catch
        {
            throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
        }
    }
}

