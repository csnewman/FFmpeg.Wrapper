using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg.Wrapper
{
    public enum AvMediaType
    {
        Unknown = -1,
        Video = 0,
        Audio = 1,
        Data = 2,
        SubTitle = 3,
        Attachement = 4,
        Nb = 5,
    }
}