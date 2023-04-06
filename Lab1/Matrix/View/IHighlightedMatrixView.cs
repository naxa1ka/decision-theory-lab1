namespace Lab1.Matrix;

public interface IHighlightedMatrixView<T> where T : IComparable<T>
{
    void Print(Matrix<T> matrix,
        Func<MatrixElement<T>, bool> isHighlightedElement,
        Func<MatrixElement<T>, bool> isDoubleHighlightedElement);
}