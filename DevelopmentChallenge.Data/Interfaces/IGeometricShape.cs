using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IGeometricShape
    {
        decimal CalculateArea();
        decimal CalculatePerimeter();
        string GetShapeName(int quantity);
    }
}
