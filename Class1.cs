using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinuEpood
{
    internal class CartItem : ListViewItem
    {
        public CartItem(string text) : base(text) { }

        public override string ToString()
        {
            return Text;
        }
    }
}
