namespace Lab1.Matrix;

public interface IMatrixView<T> where T : IComparable<T>
{
    void Print(Matrix<T> matrix, Func<MatrixElement<T>, string>? formatter = null);
}