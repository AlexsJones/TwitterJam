using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterJam.Interfaces;

namespace TwitterJam.Implementation
{
    public class LttStatusFeed : ITwitterStatusFeed
    {
        public List<ITwitterStatusInformation> StatusInformation { get; set; }

        public LttStatusFeed()
        {
            StatusInformation = new List<ITwitterStatusInformation>();
        }

        public void AddItem(ITwitterStatusInformation statusItem)
        {
            StatusInformation.Add(statusItem);
        }

        public void Dispose()
        {
           
        }
    }
}
