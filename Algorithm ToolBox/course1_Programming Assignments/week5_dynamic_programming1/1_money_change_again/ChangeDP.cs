using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDP
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = Convert.ToInt32(Console.ReadLine());
            var availableCoins = new int[] {1,3,4};
            var minCoins = GetMinimumNumberOfCoinsDP(money,availableCoins);
            Console.WriteLine(minCoins);
        }
		private static int GetMinimumNumberOfCoinsDP(int money, int[] coins)
        {
            int[] MinCoins = new int[money + 1];
            MinCoins[0] = 0;
            // Initialize the resultant array with max values
            for (int i = 1; i <= money; i++)
            {
                MinCoins[i] = Int32.MaxValue;
            }
            // start filling the array with bottom up approach
            for (int curMoney = 1; curMoney <= money; curMoney++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    // consider all those coins which are less than than the current money
                    if (curMoney >= coins[j])
                    {
                        var coinsRequired = MinCoins[curMoney - coins[j]];
                        if (coinsRequired != Int32.MaxValue && 1 + coinsRequired < MinCoins[curMoney])
                        {
                            MinCoins[curMoney] = 1 + coinsRequired;
                        }
                    }
                    else
                        break;
                }
            }
            return MinCoins[money];
        }
    }
}