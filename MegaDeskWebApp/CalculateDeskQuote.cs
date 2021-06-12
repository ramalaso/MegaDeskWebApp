using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWebApp
{
    public class CalculateDeskQuote
    {
        static Dictionary<string, List<int>> rushPrices = new Dictionary<string, List<int>>()
        {
            {"3", new List<int>(){60,70,80 } },
            {"5", new List<int>(){40,50,60 } },
            {"7", new List<int>(){30,35,40 } },
            {"14", new List<int>(){0,0, 0 } },
            {"0", new List<int>(){60,70,80 } },
        };

        public static int getRushPrice(string days, int size)
        {
            int index = size < 1000 ? 0 : size < 2000 ? 1 : 2;
            return rushPrices[days][index];
        }

        public enum Surface : int
        {
            oak = 200,
            laminate = 100,
            pine = 50,
            rosewood = 300,
            veneer = 125,
            None = 0
        }

        public static int getSurfacePrice(Surface surface)
        {
            return (int)surface;
        }

        public static int getSurfaceAreaPrice(int size)
        {
            return size > 1000 ? size : 0;
        }

        public static int calculateQuote(int width, int depth, int numberOfDrawers, Surface surface, string days)
        {
            const int BASE_PRICE = 200;
            int priceAreaPrice = getSurfaceAreaPrice(width * depth);
            int priceDrawers = numberOfDrawers * 50;
            int priceMaterials = getSurfacePrice(surface);
            int priceRushOrder = getRushPrice(days, width * depth);
            return BASE_PRICE + priceAreaPrice + priceDrawers + priceMaterials + priceRushOrder;
        }
    }
}
