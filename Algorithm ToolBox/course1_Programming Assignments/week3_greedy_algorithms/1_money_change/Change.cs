using System;

namespace Change
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            int fiveCurrencyCoin = 5, tenCurrencyCoin = 10;
            var minNumOfCoins = GetMinimumNumberOfCoins(input, tenCurrencyCoin, fiveCurrencyCoin);
            Console.WriteLine(minNumOfCoins);
        }
		private static int GetMinimumNumberOfCoins(int currency, int tenCurrencyCoin, int fiveCurrencyCoin)
        {
            int minNumOfCoins = 0;
            while (currency > 0)
            {
                if (currency >= tenCurrencyCoin)
                {
                    minNumOfCoins += (currency / tenCurrencyCoin);
                    if (currency % tenCurrencyCoin == 0)
                        break;
                    currency %= tenCurrencyCoin;
                }
                if (currency >= fiveCurrencyCoin)
                {
                    minNumOfCoins += (currency / fiveCurrencyCoin);
                    if (currency % fiveCurrencyCoin == 0)
                        break;
                    currency %= fiveCurrencyCoin;
                }
                if (currency < 5)
                {
                    minNumOfCoins += currency;
                    break;
                }
            }
            return minNumOfCoins;
        }
    }
}