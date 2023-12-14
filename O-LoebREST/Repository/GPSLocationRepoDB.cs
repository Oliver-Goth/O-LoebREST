using Microsoft.EntityFrameworkCore;
using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class GPSLocationRepoDB : IGpsLocationRepo
    {
        private readonly DataBaseContext _context;
        public GPSLocationRepoDB(DataBaseContext context) 
        {
            _context = context;
        }

        public GPSLocation GetById(int id)
        {
            GPSLocation GpsLocationToFind = _context.GPSLocations.FirstOrDefault(gps => gps.Id == id);

            return GpsLocationToFind;
        }
        public GPSLocation AddGPSLocation(GPSLocation gpsLocation) 
        {

            GPSLocation existingGpsLocation = GetById(1);

            if (existingGpsLocation.Latitude == gpsLocation.Latitude && existingGpsLocation.Longitude == gpsLocation.Longitude) 
            {

                return existingGpsLocation;
                
            
            
            } else
            {
                _context.GPSLocations.Remove(existingGpsLocation);
                _context.GPSLocations.Add(gpsLocation);
                _context.SaveChanges();
                return gpsLocation;

            }

        }
    }
}
