using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterJam.Interfaces
{
    public interface ITwitterStatusFeed
    {
        List<ITwitterStatusInformation> StatusInformation { get; set; }

        void AddItem(ITwitterStatusInformation statusItem);

    }
}
