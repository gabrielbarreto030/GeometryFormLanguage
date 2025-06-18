using System;
using System.Collections.Generic;
using System.Text;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Localization;
using DevelopmentChallenge.Data.Shapes;
using Xunit;

namespace DevelopmentChallenge.Tests.xUnit
{
    namespace DevelopmentChallenge.Data.Tests
    {
        public class DataTests
        {
           
            [Fact]
            public void TestResumenListaVacia()
            {
                Assert.Equal("<h1>Lista vacía de formas!</h1>",
                    FormaGeometrica.Imprimir(new List<FormaGeometrica>(), FormaGeometrica.Castellano));
            }

            [Fact]
            public void TestResumenListaVaciaFormasEnIngles()
            {
                Assert.Equal("<h1>Empty list of shapes!</h1>",
                   FormaGeometrica.Imprimir(new List<FormaGeometrica>(), FormaGeometrica.Ingles));
            }

            [Fact]
            public void TestResumenListaConUnCuadrado()
            {
                var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };
                var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);
                Assert.Equal("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
            }

            [Fact]
            public void TestResumenListaConMasCuadrados()
            {
                var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            };
                var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);
                Assert.Equal("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
            }

            [Fact]
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

                Assert.Equal(
                    "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                    resumen);
            }

            [Fact]
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

                Assert.Equal(
                    "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                    resumen);
            }


            [Fact]
            public void TestTrapezoidCalculations()
            {
                var trapezoid = new Trapezoid(4, 6, 5, 3, 7);               
                Assert.Equal(25m, trapezoid.CalculateArea());
                Assert.Equal(20m, trapezoid.CalculatePerimeter());

                var trapezoid2 = new Trapezoid(3, 8, 4, 5, 6);
                Assert.Equal(22m, trapezoid2.CalculateArea());
                Assert.Equal(22m, trapezoid2.CalculatePerimeter());

                var rectangleAsTrapezoid = new Trapezoid(5, 5, 4, 4, 4);
                Assert.Equal(20m, rectangleAsTrapezoid.CalculateArea());
                Assert.Equal(18m, rectangleAsTrapezoid.CalculatePerimeter());
            }

            [Fact]
            public void TestReportWithOneTrapezoidSpanish()
            {
                var formatter = new SpanishFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape> { new Trapezoid(4, 6, 5, 3, 7) };
                var report = generator.GenerateReport(shapes);
                Assert.Equal("<h1>Reporte de Formas</h1>1 Trapecio | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", report);
            }

            [Fact]
            public void TestReportWithMultipleTrapezoidsEnglish()
            {
                var formatter = new EnglishFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
            {
                new Trapezoid(4, 6, 5, 3, 7),
                new Trapezoid(3, 8, 4, 5, 6),
                new Trapezoid(5, 5, 4, 4, 4)
            };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                    "<h1>Shapes report</h1>3 Trapezoids | Area 67 | Perimeter 60 <br/>TOTAL:<br/>3 shapes Perimeter 60 Area 67",
                    report
               );
            }

            [Fact]
            public void TestReportWithMixedShapesIncludingTrapezoidItalian()
            {
                var formatter = new ItalianFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
             {
                 new Square(5),
                 new Circle(3),
                 new Trapezoid(4, 6, 5, 3, 7),
                 new EquilateralTriangle(4),
             };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                    "<h1>Rapporto Forme Geometriche</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>1 Cerchio | Area 7,07 | Perimetro 9,42 <br/>1 Trapezio | Area 25 | Perimetro 20 <br/>1 Triangolo  | Area 6,93 | Perimetro 12 <br/>TOTALE:<br/>4 forme Perimetro 61,42 Area 64",
                    report
                );
            }

            [Fact]
            public void TestRectangleCalculations()
            {
                var rectangle = new Rectangle(5, 10);
                Assert.Equal(50m, rectangle.CalculateArea());
                Assert.Equal(30m, rectangle.CalculatePerimeter());

                var squareAsRectangle = new Rectangle(7, 7);
                Assert.Equal(49m, squareAsRectangle.CalculateArea());
                Assert.Equal(28m, squareAsRectangle.CalculatePerimeter());

                var rectangle3 = new Rectangle(2.5m, 4m);
                Assert.Equal(10m, rectangle3.CalculateArea());
                Assert.Equal(13m, rectangle3.CalculatePerimeter());
            }

            [Fact]
            public void TestReportWithOneRectangleEnglish()
            {
                var formatter = new EnglishFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape> { new Rectangle(4, 6) };
                var report = generator.GenerateReport(shapes);
                Assert.Equal("<h1>Shapes report</h1>1 Rectangle | Area 24 | Perimeter 20 <br/>TOTAL:<br/>1 shapes Perimeter 20 Area 24", report);
            }

            [Fact]
            public void TestReportWithMultipleRectanglesSpanish()
            {
                var formatter = new SpanishFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
            {
                new Rectangle(5, 10),
                new Rectangle(7, 7),
                new Rectangle(2, 5)
            };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                     "<h1>Reporte de Formas</h1>3 Rectángulos | Area 109 | Perimetro 72 <br/>TOTAL:<br/>3 formas Perimetro 72 Area 109",
                     report
                );
            }

            [Fact]
            public void TestReportWithMixedShapesIncludingRectangleItalian()
            {
                var formatter = new ItalianFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
             {
                 new Square(5),
                 new Circle(3),
                 new Rectangle(4, 6),
                 new EquilateralTriangle(4),
             };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                    "<h1>Rapporto Forme Geometriche</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>1 Cerchio | Area 7,07 | Perimetro 9,42 <br/>1 Rettangolo | Area 24 | Perimetro 20 <br/>1 Triangolo  | Area 6,93 | Perimetro 12 <br/>TOTALE:<br/>4 forme Perimetro 61,42 Area 63",
                    report
                );
            }            

            [Fact]
            public void TestReportEmptyListItalian()
            {
                var formatter = new ItalianFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>();
                var report = generator.GenerateReport(shapes);
                Assert.Equal("<h1>Elenco di forme vuoto!</h1>", report);
            }

            [Fact]
            public void TestReportOnlyEquilateralTrianglesItalian()
            {
                var formatter = new ItalianFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
            {
                new EquilateralTriangle(3),
                new EquilateralTriangle(5),
            };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                    "<h1>Rapporto Forme Geometriche</h1>2 Triangoli  | Area 14,72 | Perimetro 24 <br/>TOTALE:<br/>2 forme Perimetro 24 Area 14,72",
                    report
                );
            }

            [Fact]
            public void TestReportOnlyCirclesSpanish()
            {
                var formatter = new SpanishFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
            {
                new Circle(4),
                new Circle(10),
                new Circle(1),
            };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                    "<h1>Reporte de Formas</h1>3 Círculos | Area 91,89 | Perimetro 47,12 <br/>TOTAL:<br/>3 formas Perimetro 47,12 Area 91,89",
                    report
                );
            }

            [Fact]
            public void TestReportOnlyRectanglesItalian()
            {
                var formatter = new ItalianFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
             {
                 new Rectangle(2, 3),
                 new Rectangle(5, 5),
                 new Rectangle(1, 10),
             };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                     "<h1>Rapporto Forme Geometriche</h1>3 Rettangoli | Area 41 | Perimetro 52 <br/>TOTALE:<br/>3 forme Perimetro 52 Area 41",
                     report
                );
            }

            [Fact]
            public void TestReportOnlyTrapezoidsEnglish()
            {
                var formatter = new EnglishFormatter();
                var generator = new ShapeReportGenerator(formatter);
                var shapes = new List<IGeometricShape>
            {
                new Trapezoid(3, 5, 4, 3.5m, 4.5m),
                new Trapezoid(6, 8, 5, 7, 9),
            };
                var report = generator.GenerateReport(shapes);
                Assert.Equal(
                     "<h1>Shapes report</h1>2 Trapezoids | Area 51 | Perimeter 46 <br/>TOTAL:<br/>2 shapes Perimeter 46 Area 51",
                     report
                );
            }
            

            [Fact]
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

                Assert.Equal(expectedSpanishReport.ToString(), spanishReport);

              
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

                Assert.Equal(expectedEnglishReport.ToString(), englishReport);

              
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

                Assert.Equal(expectedItalianReport.ToString(), italianReport); 
            }
        }
    }
}