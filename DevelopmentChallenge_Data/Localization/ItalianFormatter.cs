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
    public class ItalianFormatter : ILanguageFormatter
    {
        private readonly CultureInfo _cultureInfo = new CultureInfo("it-IT");

        public string GetReportHeader()
        {
            return "<h1>Rapporto Forme Geometriche</h1>";
        }

        public string GetEmptyListMessage()
        {
            return "<h1>Elenco di forme vuoto!</h1>";
        }

        public string GetShapeName(IGeometricShape shape, int quantity)
        {
            if (shape is Square)
                return quantity == 1 ? "Quadrato" : "Quadrati";
            if (shape is Circle)
                return quantity == 1 ? "Cerchio" : "Cerchi";
            if (shape is EquilateralTriangle)
                return quantity == 1 ? "Triangolo " : "Triangoli ";
            if (shape is Rectangle)
                return quantity == 1 ? "Rettangolo" : "Rettangoli";
            if (shape is Trapezoid)
                return quantity == 1 ? "Trapezio" : "Trapezi";

            return string.Empty; 
        }

        public string GetAreaLabel()
        {
            return "Area";
        }

        public string GetPerimeterLabel()
        {
            return "Perimetro";
        }

        public string GetTotalLabel()
        {
            return "TOTALE";
        }

        public string GetShapesLabel(int quantity)
        {
            return quantity == 1 ? "forma" : "forme";
        }

        public string FormatDecimal(decimal value)
        {
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ",";
            return value.ToString("#.##", numberFormat);
        }
    }
}
