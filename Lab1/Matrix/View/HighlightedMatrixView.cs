using Lab1.Matrix.Formatting;

namespace Lab1.Matrix;

public class HighlightedMatrixView<T> : IHighlightedMatrixView<T> where T : IComparable<T>
{
    private readonly IMatrixView<T> _view;
    private readonly IMatrixElementFormatter<T> _matrixElementFormatter;
    private readonly IMatrixElementFormatter<T> _highlightedMatrixElementFormatter;
    private readonly IMatrixElementFormatter<T> _doubleHighlightedMatrixElementFormatter;

    public HighlightedMatrixView(IMatrixView<T> view, 
        IMatrixElementFormatter<T> matrixElementFormatter,
        IMatrixElementFormatter<T> highlightedMatrixElementFormatter,
        IMatrixElementFormatter<T> doubleHighlightedMatrixElementFormatter)
    {
        _view = view;
        _matrixElementFormatter = matrixElementFormatter;
        _highlightedMatrixElementFormatter = highlightedMatrixElementFormatter;
        _doubleHighlightedMatrixElementFormatter = doubleHighlightedMatrixElementFormatter;
    }

    public void Print(Matrix<T> matrix,
        Func<MatrixElement<T>, bool> isHighlightedElement,
        Func<MatrixElement<T>, bool> isDoubleHighlightedElement)
    {
        _view.Print(matrix, x =>
        {
            if (isDoubleHighlightedElement.Invoke(x))
                return _doubleHighlightedMatrixElementFormatter.Format(x);
            
            if (isHighlightedElement.Invoke(x))
                return _highlightedMatrixElementFormatter.Format(x);

            return _matrixElementFormatter.Format(x);
        });
    }
}