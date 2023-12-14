using O_LoebREST.Models;

public interface IGpsLocationRepo
{
    GPSLocation GetById(int id);
    GPSLocation AddGPSLocation(GPSLocation gpsLocation);
}
    
    
    

