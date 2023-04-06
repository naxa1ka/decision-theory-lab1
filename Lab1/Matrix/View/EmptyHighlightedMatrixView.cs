namespace Lab1.Matrix;

public class EmptyHighlightedMatrixView<T> : IHighlightedMatrixView<T> where T : IComparable<T>
{
    public void Print(Matrix<T> matrix, Func<MatrixElement<T>, bool> isHighlightedElement,
        Func<MatrixElement<T>, bool> isDoubleHighlightedElement)
    {
    }
}