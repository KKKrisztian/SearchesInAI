using System.Collections.Generic;

namespace SearchInAI
{
    class City
    {
        private string name;
        private int kilometersToSzeged;
        private Dictionary<City, int> connectingCities;

        public City()
        {
            
        }

        public City(string name, int kilometersToSzeged)
        {
            this.name = name;
            this.kilometersToSzeged = kilometersToSzeged;
            connectingCities = new Dictionary<City, int>();
        }

        public void addConnectingCity(City connectingCity, int kilometersTo)
        {
            connectingCities.Add(connectingCity, kilometersTo);
        }

        public string getName()
        {
            return name;
        }

        public int getKilometersToSzeged()
        {
            return kilometersToSzeged;
        }

        public Dictionary<City, int> getConnectingCities()
        {
            return connectingCities;
        }
    }
}