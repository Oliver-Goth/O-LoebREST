using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class GPSLocationRepoDB
    {
        private readonly DataBaseContext _context;
        public GPSLocationRepoDB(DataBaseContext context) 
        {
            _context = context;
        }
        public void AddGPSLocation(GPSLocation gpsLocation) 
        {
            _context.GPSLocations.Add(gpsLocation);
            _context.SaveChanges();
        }
    }
}
