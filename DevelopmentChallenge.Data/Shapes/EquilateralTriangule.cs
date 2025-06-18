using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Shapes
{
    public class EquilateralTriangle : IGeometricShape
    {
        private readonly decimal _side;

        public EquilateralTriangle(decimal side)
        {
            _side = side;
        }

        public decimal CalculateArea()
        {
           
            return ((decimal)Math.Sqrt(3) / 4) * _side * _side;
        }

        public decimal CalculatePerimeter()
        {
          
            return _side * 3;
        }

        public string GetShapeName(int quantity)
        {
            return quantity == 1 ? "Triangle" : "Triangles";
        }
    }
}
