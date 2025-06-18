/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica 
    {        
        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;

        public const int Castellano = 1;
        public const int Ingles = 2;           
      
        public static string Imprimir(List<FormaGeometrica> formasAntigas, int idiomaId)
        {
            var formatter = ShapeReportGenerator.GetFormatter(idiomaId); 
            var generator = new ShapeReportGenerator(formatter);
           
            var novasFormas = new List<IGeometricShape>();
            if (formasAntigas != null)
            {
                foreach (var formaAntiga in formasAntigas)
                {
                    IGeometricShape novaForma = null;
                    switch (formaAntiga.Tipo)
                    {
                        case Cuadrado:
                            novaForma = new Square(formaAntiga._lado);
                            break;
                        case Circulo:                          
                            novaForma = new Circle(formaAntiga._lado);
                            break;
                        case TrianguloEquilatero:
                            novaForma = new EquilateralTriangle(formaAntiga._lado);
                            break;                       
                        default:                            
                            break;
                    }
                    if (novaForma != null)
                    {
                        novasFormas.Add(novaForma);
                    }
                }
            }

            return generator.GenerateReport(novasFormas);
        }
      
        private readonly decimal _lado;
        public int Tipo { get; set; }
       
        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }      
    }
}
