using System;
using System.Collections.Generic;
using System.Text;

namespace L.Pathogen
{
    public interface IDataReaderProcessor
    {
        IList<InfectionTarget> Reader();
    }
}
