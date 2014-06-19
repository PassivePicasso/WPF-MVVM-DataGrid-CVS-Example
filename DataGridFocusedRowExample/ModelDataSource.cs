using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridFocusedRowExample
{
    public class ModelDataSource
    {
        private static readonly Random rand = new Random();

        public static RowViewModel GetRandomModel()
        {
            return new RowViewModel { Name = RandomString(rand.Next(30)), Copyrights = rand.Next(1000), Money = rand.Next(10000000), Trademarks = rand.Next(10000) };
        }

        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
