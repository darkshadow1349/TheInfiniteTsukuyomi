using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace RemotingInterface
{
    interface DesktopInterface
    {
        String HelloMethod(string name);
        String GoodbyeMethod();
        MemoryStream GetBitmap();
    }
}
