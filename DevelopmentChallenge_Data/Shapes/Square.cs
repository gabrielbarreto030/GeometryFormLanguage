using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Square : IGeometricShape
    {
        private readonly decimal _side;

        public Square(decimal side)
        {
            _side = side;
        }

        public decimal CalculateArea()
        {
            return _side * _side;
        }

        public decimal CalculatePerimeter()
        {
            return _side * 4;
        }

        public string GetShapeName(int quantity)
        {
            return quantity == 1 ? "Square" : "Squares"; 
        }
    }
}
