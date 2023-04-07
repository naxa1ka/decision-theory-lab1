using System.Globalization;
using Lab1.File;
using Lab1.IterationMethod;
using Lab1.Matrix;
using Lab1.Matrix.Formatting;

const string filePath = @"P:\_CSharp_Projects_\DecisionTheory\Lab1\Lab1\input.txt";
var rawMatrix = FileExtensions.ReadMatrix(filePath, int.Parse);
var matrix = new Matrix<int>(rawMatrix);

var textWriter = Console.Out;
var emptyIterationMethodView = new EmptyIterationMethodView<int>();
var iterationMethodView = new IterationMethodView<int>(
    textWriter, new CultureInfo("en-US"),
    new DefaultMatrixElementFormatter<int>(),
    new HighlightMatrixElementFormatter<int>());

var matrixView = new MatrixView<int>(textWriter);
var emptyHighlightedMatrixView = new EmptyHighlightedMatrixView<int>();
var highlightedMatrixView = new HighlightedMatrixView<int>(matrixView,
    new DefaultMatrixElementFormatter<int>(),
    new HighlightMatrixElementFormatter<int>(),
    new DoubleHighlightMatrixElementFormatter<int>()
);
var highlightedMatrixViewWithSpace = new HighlightedMatrixViewWithSpace<int>(textWriter, highlightedMatrixView);

var iterationMethod = new IterationMethod(iterationMethodView, emptyHighlightedMatrixView, matrix);
iterationMethod.Run(0, 8);