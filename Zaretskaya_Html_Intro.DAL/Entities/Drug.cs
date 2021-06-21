using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaretskaya_Html_Intro.DAL.Entities
{
    public class Drug
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public int Price { set; get; }

        public DrugGroup Group { set; get; }

        public int GroupId { set; get; }

        public string Image { set; get; }

    }
}
