using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    public class CompareByName : IComparer<Player>
    {
        private readonly bool ascending;

        public CompareByName(bool ascending)
        {
            this.ascending = ascending;
        }

        public int Compare(Player x, Player y)
        {
            if (x == null || y == null)
                throw new ArgumentException("Players cannot be null");

            int result = string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            return ascending ? result : -result;
        }
    }
}