using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Circle : IGeometricShape
    {
        private readonly decimal _diameter; 

        public Circle(decimal diameter)
        {
            _diameter = diameter;
        }

        public decimal CalculateArea()
        {
            
            return (decimal)Math.PI * (_diameter / 2) * (_diameter / 2);
        }

        public decimal CalculatePerimeter()
        {            
            return (decimal)Math.PI * _diameter;
        }

        public string GetShapeName(int quantity)
        {
            return quantity == 1 ? "Circle" : "Circles";
        }
    }
}
