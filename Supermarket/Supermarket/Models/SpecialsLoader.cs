using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public interface SpecialsLoader
    {
        List<Special> Load();
    }
}
