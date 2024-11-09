using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Core.Interfaces
{
    public interface IFileAttachment
    {
        string Name { get; }
        string FileType { get; }
        string FilePath {  get; }
    }
}
