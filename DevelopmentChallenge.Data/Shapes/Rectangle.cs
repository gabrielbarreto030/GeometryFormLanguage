using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Rectangle : IGeometricShape
    {
        private readonly decimal _width;
        private readonly decimal _height;        
        public Rectangle(decimal width, decimal height)
        {
           
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Largura e altura do retângulo devem ser maiores que zero.");

            _width = width;
            _height = height;
        }

       
        public decimal CalculateArea()
        {
            return _width * _height;
        }

        public decimal CalculatePerimeter()
        {
            return 2 * (_width + _height);
        }
        
        public string GetShapeName(int quantity)
        {           
            return quantity == 1 ? "Rectangle" : "Rectangles";
        }
    }
}
