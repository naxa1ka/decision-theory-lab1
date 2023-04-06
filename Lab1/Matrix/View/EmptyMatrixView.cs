namespace Lab1.Matrix;

public class EmptyMatrixView<T> : IMatrixView<T> where T : IComparable<T>
{
    public void Print(Matrix<T> matrix, Func<MatrixElement<T>, string>? formatter = null)
    {
        
    }
}