using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MolopolyGame
{
    //JailFactory class extends from PropertyFactory class
    public class JailFactory : PropertyFactory
    {
        public Jail create(string sName, bool isJail)
        {
            return new Jail(sName, isJail);
        }

    }
}
