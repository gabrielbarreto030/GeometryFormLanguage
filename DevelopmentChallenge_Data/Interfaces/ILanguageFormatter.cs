using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface ILanguageFormatter
    {
        string GetReportHeader();
        string GetEmptyListMessage();
        string GetShapeName(IGeometricShape shape, int quantity);
        string GetAreaLabel();
        string GetPerimeterLabel();
        string GetTotalLabel();
        string GetShapesLabel(int quantity);
        string FormatDecimal(decimal value);
    }
}
