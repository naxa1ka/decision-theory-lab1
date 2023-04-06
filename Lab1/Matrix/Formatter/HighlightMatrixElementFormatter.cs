namespace Lab1.Matrix.Formatting;

public class HighlightMatrixElementFormatter<T> : IMatrixElementFormatter<T> where T : IComparable<T>
{
    public string Format(MatrixElement<T> element)
    {
        return $"[{element.Value.ToString()}]";
    }
}