using System.Text;

namespace Lab1.Matrix;

public class HighlightedMatrixViewWithSpace<T> : IHighlightedMatrixView<T> where T : IComparable<T>
{
    private readonly TextWriter _output;
    private readonly IHighlightedMatrixView<T> _highlightedMatrixView;

    public HighlightedMatrixViewWithSpace(TextWriter output, IHighlightedMatrixView<T> highlightedMatrixView)
    {
        _output = output;
        _highlightedMatrixView = highlightedMatrixView;
    }

    public void Print(Matrix<T> matrix, Func<MatrixElement<T>, bool> isHighlightedElement, Func<MatrixElement<T>, bool> isDoubleHighlightedElement)
    {
        _highlightedMatrixView.Print(matrix, isHighlightedElement, isDoubleHighlightedElement);
        
        var sb = new StringBuilder();
        for (var i = 0; i < matrix.Columns * 4; i++) 
            sb.Append($"{"-",4}");
        sb.Append('\n');
        
        _output.WriteLine(sb);
    }
}