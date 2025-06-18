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
    public class SpanishFormatter : ILanguageFormatter
    {
        private readonly CultureInfo _cultureInfo = new CultureInfo("es-ES");

        public string GetReportHeader()
        {
            return "<h1>Reporte de Formas</h1>";
        }

        public string GetEmptyListMessage()
        {
            return "<h1>Lista vacía de formas!</h1>";
        }

        public string GetShapeName(IGeometricShape shape, int quantity)
        {
            if (shape is Square)
                return quantity == 1 ? "Cuadrado" : "Cuadrados";
            if (shape is Circle)
                return quantity == 1 ? "Círculo" : "Círculos";
            if (shape is EquilateralTriangle)
                return quantity == 1 ? "Triángulo" : "Triángulos";           

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
            return "TOTAL";
        }

        public string GetShapesLabel(int quantity)
        {
            return  "formas";
        }

        public string FormatDecimal(decimal value)
        {
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ",";
            return value.ToString("#.##", numberFormat);
        }
    }
}
