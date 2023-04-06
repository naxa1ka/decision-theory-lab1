namespace Lab1.Matrix.Formatting;

public class DoubleHighlightMatrixElementFormatter<T> : IMatrixElementFormatter<T> where T : IComparable<T>
{
    public string Format(MatrixElement<T> element)
    {
        return $"[[{element.Value.ToString()}]]";
    }
}