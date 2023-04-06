namespace Lab1.Matrix.Formatting;

public interface IMatrixElementFormatter<T> where T : IComparable<T>
{
    string Format(MatrixElement<T> element);
}