using System.Globalization;
using Lab1.File;
using Lab1.IterationMethod;
using Lab1.Matrix;
using Lab1.Matrix.Formatting;

const string filePath = @"P:\_CSharp_Projects_\DecisionTheory\Lab1\Lab1\input.txt";
var rawMatrix = FileExtensions.ReadMatrix(filePath, int.Parse);
var matrix = new Matrix<int>(rawMatrix);

var textWriter = Console.Out;
var view = new IterationMethodView<int>(
    textWriter, new CultureInfo("en-US"),
    new DefaultMatrixElementFormatter<int>(),
    new HighlightMatrixElementFormatter<int>());
var iterationMethod = new IterationMethod(view, matrix, 8, 0);
iterationMethod.Run();
