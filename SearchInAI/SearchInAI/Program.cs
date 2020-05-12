using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInAI
{
    class Program
    {

        static void addConnectingCitiesToEachOther(City c1, City c2, int kilometersBetween)
        {
            c1.addConnectingCity(c2, kilometersBetween);
            c2.addConnectingCity(c1, kilometersBetween);
        }


        static void runAStarSearch(City currentCity)
        {
            Console.WriteLine("Starting in " + currentCity.getName() + "...\n");
            int totalCost = 0;
            Dictionary<City, int> currentCityConnectingCities = new Dictionary<City, int>();


            while (currentCity.getKilometersToSzeged() != 0)
            {
                currentCityConnectingCities = currentCity.getConnectingCities();
                int currentSzegedPlusCurrentCityDistance = 0;
                int bestSzegedPlusCurrentCityDistance = int.MaxValue;
                City bestConnectingCity = new City();
                int distanceBetweenCities = 0;
              

                Console.Write(currentCity.getName() + " connects to: ");

                foreach (KeyValuePair<City, int> connectingCity in currentCityConnectingCities)
                {
                    currentSzegedPlusCurrentCityDistance =
                        connectingCity.Value + connectingCity.Key.getKilometersToSzeged();

                    Console.Write(connectingCity.Key.getName() + "(" + currentSzegedPlusCurrentCityDistance + " = " + connectingCity.Value + " + " + connectingCity.Key.getKilometersToSzeged() + ")");

                    if (currentSzegedPlusCurrentCityDistance < bestSzegedPlusCurrentCityDistance)
                    {
                        bestConnectingCity = connectingCity.Key;

                        distanceBetweenCities = connectingCity.Value;

                        bestSzegedPlusCurrentCityDistance =
                            distanceBetweenCities + connectingCity.Key.getKilometersToSzeged();

                    }

                    if (!connectingCity.Key.Equals(currentCityConnectingCities.Last().Key))
                    {
                        Console.Write(", ");
                    }

                }

                Console.WriteLine("\nTraveled " + distanceBetweenCities + "kilometers to " + bestConnectingCity.getName() + "\n");
                totalCost += distanceBetweenCities;
                currentCity = bestConnectingCity;
            }

            Console.WriteLine("Reached Szeged (goal node)");
            Console.WriteLine("Total Cost: " + totalCost + " kilometers\n");
        }
        static void runGreadySearch(City currentCity)
        {
            Console.WriteLine("Starting in " + currentCity.getName() + "...\n");
            int totalCost = 0;
            Dictionary<City, int> currentCityConnectingCities = new Dictionary<City, int>();


            while (currentCity.getKilometersToSzeged() != 0)
            {
                currentCityConnectingCities = currentCity.getConnectingCities();
                int currentSzegedPlusCurrentCityDistance = 0;
                int bestSzegedPlusCurrentCityDistance = int.MaxValue;
                City bestConnectingCity = new City();
                int distanceBetweenCities = 0;


                Console.Write(currentCity.getName() + " connects to: ");

                foreach (KeyValuePair<City, int> connectingCity in currentCityConnectingCities)
                {
                    currentSzegedPlusCurrentCityDistance =
                       connectingCity.Key.getKilometersToSzeged();

                    Console.Write(connectingCity.Key.getName() + "(" + currentSzegedPlusCurrentCityDistance + ")");

                    if (currentSzegedPlusCurrentCityDistance < bestSzegedPlusCurrentCityDistance)
                    {
                        bestConnectingCity = connectingCity.Key;

                        distanceBetweenCities = connectingCity.Value;

                        bestSzegedPlusCurrentCityDistance =
                            connectingCity.Key.getKilometersToSzeged();

                    }

                    if (!connectingCity.Key.Equals(currentCityConnectingCities.Last().Key))
                    {
                        Console.Write(", ");
                    }

                }

                Console.WriteLine("\nTraveled " + distanceBetweenCities + "kilometers to " + bestConnectingCity.getName() + "\n");
                totalCost += distanceBetweenCities;
                currentCity = bestConnectingCity;
            }

            Console.WriteLine("Reached Szeged (goal node)");
            Console.WriteLine("Total Cost: " + totalCost + " kilometers\n");
        }

        

        static void Main(string[] args)
        {

            City gyor = new City("Győr", 246);
            City szombathely = new City("Szombathely", 290);
            City zalaegerszeg = new City("Zalaegerszeg", 260);
            City kaposvar = new City("Kaposvár", 179);
            City pecs = new City("Pécs", 149);
            City szekszard = new City("Szekszárd", 111);
            City veszprem = new City("Veszprém", 195);
            City tatabanya = new City("Tatabánya", 197);
            City szekesfehervar = new City("Székesfehérvár", 168);
            City budapest = new City("Budapest", 161);
            City kecskemet = new City("Kecskemét", 80);
            City szolnok = new City("Szolnok", 101);
            City salgotarjan = new City("Salgótarján", 206);
            City szeged = new City("Szeged", 0);
            City eger = new City("Eger", 183);
            City miskolc = new City("Miskolc", 210);
            City bekescsaba = new City("Békéscsaba", 84);
            City nyiregyhaza = new City("Nyíregyháza", 223);
            City debrecen = new City("Debrecen", 181);



            addConnectingCitiesToEachOther(gyor,szombathely, 92);
            addConnectingCitiesToEachOther(gyor,veszprem, 67);
            addConnectingCitiesToEachOther(gyor, tatabanya, 58);
            addConnectingCitiesToEachOther(szombathely, veszprem, 98);
            addConnectingCitiesToEachOther(szombathely,zalaegerszeg, 45);
            addConnectingCitiesToEachOther(zalaegerszeg, veszprem, 86);
            addConnectingCitiesToEachOther(zalaegerszeg,kaposvar, 90);
            addConnectingCitiesToEachOther(kaposvar,veszprem, 83);
            addConnectingCitiesToEachOther(kaposvar,szekszard, 69);
            addConnectingCitiesToEachOther(kaposvar,pecs, 45);
            addConnectingCitiesToEachOther(pecs, szekszard, 47);
            addConnectingCitiesToEachOther(szekszard, veszprem, 100);
            addConnectingCitiesToEachOther(szekszard, szekesfehervar, 95);
            addConnectingCitiesToEachOther(szekszard,kecskemet,97);
            addConnectingCitiesToEachOther(szekszard, szeged, 111);
            addConnectingCitiesToEachOther(szekesfehervar, veszprem, 40);
            addConnectingCitiesToEachOther(szekesfehervar, tatabanya, 42);
            addConnectingCitiesToEachOther(szekesfehervar, budapest, 57);
            addConnectingCitiesToEachOther(szekesfehervar, kecskemet, 101);
            addConnectingCitiesToEachOther(tatabanya,budapest, 49);
            addConnectingCitiesToEachOther(budapest, salgotarjan, 89);
            addConnectingCitiesToEachOther(budapest, eger, 110);
            addConnectingCitiesToEachOther(budapest, szolnok, 91);
            addConnectingCitiesToEachOther(budapest, kecskemet, 80);
            addConnectingCitiesToEachOther(salgotarjan, eger, 48);
            addConnectingCitiesToEachOther(eger, miskolc, 38);
            addConnectingCitiesToEachOther(eger, nyiregyhaza, 100);
            addConnectingCitiesToEachOther(eger, debrecen, 101);
            addConnectingCitiesToEachOther(eger, szolnok, 82);
            addConnectingCitiesToEachOther(miskolc, nyiregyhaza, 71);
            addConnectingCitiesToEachOther(nyiregyhaza, debrecen, 47);
            addConnectingCitiesToEachOther(debrecen, szolnok, 115);
            addConnectingCitiesToEachOther(debrecen, bekescsaba, 102);
            addConnectingCitiesToEachOther(bekescsaba, szolnok, 89);
            addConnectingCitiesToEachOther(bekescsaba, szeged, 84);
            addConnectingCitiesToEachOther(kecskemet, szeged, 80);
            addConnectingCitiesToEachOther(szolnok, szeged, 101);
            addConnectingCitiesToEachOther(szolnok, kecskemet, 46);


            runAStarSearch(gyor);
            runGreadySearch(gyor);

            Console.ReadKey();


        }
    }
}
