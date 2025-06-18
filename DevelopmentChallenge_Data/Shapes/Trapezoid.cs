using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Shapes
{
    public class Trapezoid : IGeometricShape
    {
        private readonly decimal _base1;
        private readonly decimal _base2;
        private readonly decimal _height;
        private readonly decimal _side1; 
        private readonly decimal _side2; 
        public Trapezoid(decimal base1, decimal base2, decimal height, decimal side1, decimal side2)
        {
            
            if (base1 <= 0 || base2 <= 0 || height <= 0 || side1 <= 0 || side2 <= 0)
                throw new ArgumentException("Todas as dimensões do trapézio devem ser maiores que zero.");

            _base1 = base1;
            _base2 = base2;
            _height = height;
            _side1 = side1;
            _side2 = side2;
        }
        
        public decimal CalculateArea()
        {
            return (_base1 + _base2) * _height / 2m;
        }
       
        public decimal CalculatePerimeter()
        {
            return _base1 + _base2 + _side1 + _side2;
        }
        
        public string GetShapeName(int quantity)
        {           
            return quantity == 1 ? "Trapezoid" : "Trapezoids";
        }
    }
}
