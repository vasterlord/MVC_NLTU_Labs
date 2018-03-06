using NLTU_Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NLTU_Labs.Data
{
    public class BusRepository
    {
        public List<Bus> GetBusesPark()
        {
            return Data.BusesPark.OrderBy(id=>id.Id).ToList();
        } 

        public List<Bus> GetBusesRoute()
        {
            return Data.BusesRoute.OrderBy(id => id.Id).ToList();
        }

        public Bus GetBusPark(int id)
        {
            Bus bus = Data.BusesPark
                .Where(e => e.Id == id)
                .SingleOrDefault();
            return bus;
        }

        public Bus GetBusRoute(int id)
        {
            Bus bus = Data.BusesRoute
                .Where(e => e.Id == id)
                .SingleOrDefault();
            return bus;
        }

        public void AddBusPark(Bus bus)
        {
            int nextAvailableBusId = Data.BusesPark
                .Max(e => e.Id) + 1;

            bus.Id = nextAvailableBusId;

            Data.BusesPark.Add(bus);
        }

        public void AddBusRoute(Bus bus)
        {
            int nextAvailableBusId = Data.BusesRoute
                .Max(e => e.Id) + 1;

            bus.Id = nextAvailableBusId;

            Data.BusesRoute.Add(bus);
        }

        public void UpdateBusPark(Bus bus)
        {
            // Find the index of the entry that we need to update.
            int busIndex = Data.BusesPark.FindIndex(e => e.Id == bus.Id);

            if (busIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", bus.Id));
            }

            Data.BusesPark[busIndex] = bus;
        }

        public void UpdateBusRoute(Bus bus)
        {
            // Find the index of the entry that we need to update.
            int busIndex = Data.BusesRoute.FindIndex(e => e.Id == bus.Id);

            if (busIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", bus.Id));
            }

            Data.BusesRoute[busIndex] = bus;
        } 

        public void DeleteBusPark(int id)
        {
            // Find the index of the entry that we need to delete.
            int busIndex = Data.BusesPark.FindIndex(e => e.Id == id);

            if (busIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", id));
            }
            Data.BusesRoute.Add(Data.BusesPark.ElementAt(busIndex));
            Data.BusesPark.RemoveAt(busIndex);
        }

        public void DeleteBusRoute(int id)
        {
            // Find the index of the entry that we need to delete.
            int busIndex = Data.BusesRoute.FindIndex(e => e.Id == id);

            if (busIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", id));
            }
            Data.BusesPark.Add(Data.BusesRoute.ElementAt(busIndex));
            Data.BusesRoute.RemoveAt(busIndex);
        }
    }
}