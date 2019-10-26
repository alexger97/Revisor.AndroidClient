using System;
using System.Collections.Generic;
using System.Text;

namespace Revisor.Interfaces
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
        string GetPathTest();
    }
}
