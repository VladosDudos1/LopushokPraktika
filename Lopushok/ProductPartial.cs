using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lopushok
{
    partial class Product
    {
        public string Material
        {
            get
            {
                return string.Join(", ", ProductMaterial.Select(x => x.Material.Name)); 
            }
            set { }
        }
    }
}
