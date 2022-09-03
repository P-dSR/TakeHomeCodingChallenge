using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraping
{
    class Resultado
    {
        public string Title { get; set; }
        public string Brand { get; set; }
        public List<string> Categories { get; set; }
        public string Description { get; set; }
        public List<Skus> Skus { get; set; }
        public List<Properties> Properties { get; set; }
        public List<Reviews> Reviews { get; set; }
        public string Reviews_avg_score { get; set; }
        public string url { get; set; }
    }

}
