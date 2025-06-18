using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class ShapeReportGenerator
    {
        private readonly ILanguageFormatter _formatter;

        public ShapeReportGenerator(ILanguageFormatter formatter)
        {
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        public string GenerateReport(List<IGeometricShape> shapes)
        {
            if (shapes == null || !shapes.Any())
            {
                return _formatter.GetEmptyListMessage();
            }

            var sb = new StringBuilder();
            sb.Append(_formatter.GetReportHeader());
           
            var shapesByType = shapes.GroupBy(s => s.GetType());

            foreach (var group in shapesByType)
            {
                var shapeType = group.Key;
                var count = group.Count();
                var totalArea = group.Sum(s => s.CalculateArea());
                var totalPerimeter = group.Sum(s => s.CalculatePerimeter());

              
               
                var representativeShape = group.First();

                sb.Append(FormatShapeLine(representativeShape, count, totalArea, totalPerimeter));
            }

          
            var totalShapes = shapes.Count;
            var overallTotalPerimeter = shapes.Sum(s => s.CalculatePerimeter());
            var overallTotalArea = shapes.Sum(s => s.CalculateArea());

            sb.Append(_formatter.GetTotalLabel());
            sb.Append(":<br/>");
            sb.Append($"{totalShapes} {_formatter.GetShapesLabel(totalShapes)} ");
            sb.Append($"{_formatter.GetPerimeterLabel()} {_formatter.FormatDecimal(overallTotalPerimeter)} ");
            sb.Append($"{_formatter.GetAreaLabel()} {_formatter.FormatDecimal(overallTotalArea)}");

            return sb.ToString();
        }

        private string FormatShapeLine(IGeometricShape shape, int quantity, decimal area, decimal perimeter)
        {
            var shapeName = _formatter.GetShapeName(shape, quantity);
            var areaLabel = _formatter.GetAreaLabel();
            var perimeterLabel = _formatter.GetPerimeterLabel();
            var formattedArea = _formatter.FormatDecimal(area);
            var formattedPerimeter = _formatter.FormatDecimal(perimeter);

            return $"{quantity} {shapeName} | {areaLabel} {formattedArea} | {perimeterLabel} {formattedPerimeter} <br/>";
        }
        
        public static ILanguageFormatter GetFormatter(int languageId)
        {          
            switch (languageId)
            {
                case 1: 
                    return new SpanishFormatter();
                case 2: 
                    return new EnglishFormatter();              
                default:                  
                    return new EnglishFormatter(); 
            }
        }
    }
}
