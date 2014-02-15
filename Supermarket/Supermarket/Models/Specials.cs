using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public class Specials
    {
        private SpecialsLoader _specialsLoader;
        private List<Special> _specials;

        public Specials(SpecialsLoader specialsLoader)
        {
            _specialsLoader = specialsLoader;
            _specials = _specialsLoader.Load();
        }
    }
}
