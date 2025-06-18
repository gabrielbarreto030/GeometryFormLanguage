using System;
using System.Collections.Generic;
using System.Text;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Localization;
using DevelopmentChallenge.Data.Shapes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestReportEmptyListItalian()
        {           
            var formatter = new ItalianFormatter();
            var generator = new ShapeReportGenerator(formatter);
            var shapes = new List<IGeometricShape>();
            var report = generator.GenerateReport(shapes);
            Assert.AreEqual("<h1>Elenco di forme vuoto!</h1>", report);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(FormaGeometrica.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestReportWithOneRectangleEnglish()
        {
            var formatter = new EnglishFormatter();
            var generator = new ShapeReportGenerator(formatter);
            var shapes = new List<IGeometricShape> { new Rectangle(4, 6) }; 

            var report = generator.GenerateReport(shapes);
            
            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 24 | Perimeter 20 <br/>TOTAL:<br/>1 shapes Perimeter 20 Area 24", report);
        }

        [TestCase]
        public void TestReportWithOneTrapezoidSpanish()
        {
            var formatter = new SpanishFormatter();
            var generator = new ShapeReportGenerator(formatter);
            var shapes = new List<IGeometricShape> { new Trapezoid(4, 6, 5, 3, 7) };

            var report = generator.GenerateReport(shapes);
           
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", report);
        }


        [TestCase]
        public void TestTrapezoidCalculations()
        {
            
            var trapezoid = new Trapezoid(4, 6, 5, 3, 7);
            Assert.AreEqual(25m, trapezoid.CalculateArea(), "Cálculo da Área do Trapézio incorreto.");
            Assert.AreEqual(20m, trapezoid.CalculatePerimeter(), "Cálculo do Perímetro do Trapézio incorreto.");

            
            var trapezoid2 = new Trapezoid(3, 8, 4, 5, 6);
            Assert.AreEqual(22m, trapezoid2.CalculateArea(), "Cálculo da Área do Trapézio incorreto (2).");
            Assert.AreEqual(22m, trapezoid2.CalculatePerimeter(), "Cálculo do Perímetro do Trapézio incorreto (2).");

            
            var rectangleAsTrapezoid = new Trapezoid(5, 5, 4, 4, 4);
            Assert.AreEqual(20m, rectangleAsTrapezoid.CalculateArea(), "Cálculo do Trapézio (Retângulo) incorreto.");
            Assert.AreEqual(18m, rectangleAsTrapezoid.CalculatePerimeter(), "Cálculo do Trapézio (Retângulo) incorreto.");
        }

        [TestCase]
        public void TestRectangleCalculations()
        {
            
            var rectangle = new Rectangle(5, 10); 
            Assert.AreEqual(50m, rectangle.CalculateArea(), "Cálculo da Área do Retângulo 5x10 incorreto.");
            Assert.AreEqual(30m, rectangle.CalculatePerimeter(), "Cálculo do Perímetro do Retângulo 5x10 incorreto.");

            var squareAsRectangle = new Rectangle(7, 7);
            Assert.AreEqual(49m, squareAsRectangle.CalculateArea(), "Cálculo da Área do Retângulo (Quadrado) 7x7 incorreto.");
            Assert.AreEqual(28m, squareAsRectangle.CalculatePerimeter(), "Cálculo do Perímetro do Retângulo (Quadrado) 7x7 incorreto.");
        }


        [TestCase]
        public void TestReportAllShapesAllLanguages()
        {           
            var allShapes = new List<IGeometricShape>
            {               
                new Square(5), 
                new Square(1), 
                new Square(3.5m),             
                new Circle(3), 
                new Circle(2.75m), 
                new EquilateralTriangle(4), 
                new EquilateralTriangle(9), 
                new EquilateralTriangle(4.2m),
               
                new Rectangle(2, 5),
                new Rectangle(3, 3), 
                new Rectangle(4, 6),
                new Trapezoid(4, 6, 5, 3, 7),
                new Trapezoid(3, 8, 4, 5, 6), 
            };
            var spanishFormatter = new SpanishFormatter();
            var spanishGenerator = new ShapeReportGenerator(spanishFormatter);
            var spanishReport = spanishGenerator.GenerateReport(allShapes);

            
            var expectedSpanishReport = new StringBuilder();
            expectedSpanishReport.Append("<h1>Reporte de Formas</h1>");
            expectedSpanishReport.Append("3 Cuadrados | Area 38,25 | Perimetro 38 <br/>");
            expectedSpanishReport.Append("2 Círculos | Area 13,01 | Perimetro 18,06 <br/>");
            expectedSpanishReport.Append("3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>"); 
            expectedSpanishReport.Append("3 Rectángulos | Area 43 | Perimetro 46 <br/>"); 
            expectedSpanishReport.Append("2 Trapecios | Area 47 | Perimetro 42 <br/>"); 
            expectedSpanishReport.Append("TOTAL:<br/>");
            expectedSpanishReport.Append("13 formas Perimetro 195,66 Area 190,9");

            Assert.AreEqual(expectedSpanishReport.ToString(), spanishReport, "Relatório em Espanhol incorreto.");
           
            var englishFormatter = new EnglishFormatter();
            var englishGenerator = new ShapeReportGenerator(englishFormatter);
            var englishReport = englishGenerator.GenerateReport(allShapes);
            
            var expectedEnglishReport = new StringBuilder();
            expectedEnglishReport.Append("<h1>Shapes report</h1>");
            expectedEnglishReport.Append("3 Squares | Area 38,25 | Perimeter 38 <br/>");
            expectedEnglishReport.Append("2 Circles | Area 13,01 | Perimeter 18,06 <br/>");
            expectedEnglishReport.Append("3 Triangles | Area 49,64 | Perimeter 51,6 <br/>");
            expectedEnglishReport.Append("3 Rectangles | Area 43 | Perimeter 46 <br/>");
            expectedEnglishReport.Append("2 Trapezoids | Area 47 | Perimeter 42 <br/>");
            expectedEnglishReport.Append("TOTAL:<br/>");
            expectedEnglishReport.Append("13 shapes Perimeter 195,66 Area 190,9"); 

            Assert.AreEqual(expectedEnglishReport.ToString(), englishReport, "Relatório em Inglês incorreto.");
            
            var italianFormatter = new ItalianFormatter();
            var italianGenerator = new ShapeReportGenerator(italianFormatter);
            var italianReport = italianGenerator.GenerateReport(allShapes);

            
            var expectedItalianReport = new StringBuilder();
            expectedItalianReport.Append("<h1>Rapporto Forme Geometriche</h1>");
            expectedItalianReport.Append("3 Quadrati | Area 38,25 | Perimetro 38 <br/>");
            expectedItalianReport.Append("2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>");
            expectedItalianReport.Append("3 Triangoli  | Area 49,64 | Perimetro 51,6 <br/>");
            expectedItalianReport.Append("3 Rettangoli | Area 43 | Perimetro 46 <br/>");
            expectedItalianReport.Append("2 Trapezi | Area 47 | Perimetro 42 <br/>");
            expectedItalianReport.Append("TOTALE:<br/>");
            expectedItalianReport.Append("13 forme Perimetro 195,66 Area 190,9"); 

            Assert.AreEqual(expectedItalianReport.ToString(), italianReport, "Relatório em Italiano incorreto.");
        }
    
    }
}
