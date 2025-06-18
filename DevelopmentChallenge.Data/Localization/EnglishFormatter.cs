using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Localization
{
    public class EnglishFormatter : ILanguageFormatter
    {
        private readonly CultureInfo _cultureInfo = new CultureInfo("en-US");

        public string GetReportHeader()
        {
            return "<h1>Shapes report</h1>";
        }

        public string GetEmptyListMessage()
        {
            return "<h1>Empty list of shapes!</h1>";
        }

        public string GetShapeName(IGeometricShape shape, int quantity)
        {
            if (shape is Square)
                return quantity == 1 ? "Square" : "Squares";
            if (shape is Circle)
                return quantity == 1 ? "Circle" : "Circles";
            if (shape is EquilateralTriangle)
                return quantity == 1 ? "Triangle" : "Triangles";
            if (shape is Rectangle)
                return quantity == 1 ? "Rectangle" : "Rectangles";

            return string.Empty; 
        }

        public string GetAreaLabel()
        {
            return "Area";
        }

        public string GetPerimeterLabel()
        {
            return "Perimeter";
        }

        public string GetTotalLabel()
        {
            return "TOTAL";
        }

        public string GetShapesLabel(int quantity)
        {
            return  "shapes";
        }
        public string FormatDecimal(decimal value)
        {
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ",";
            return value.ToString("#.##", numberFormat);
        }
    }
}
