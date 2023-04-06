namespace Lab1.Matrix;

public class MatrixView<T> : IMatrixView<T> where T : IComparable<T>
{
    private const char ColumnSeparator = ' ';
    private const string RowSeparator = "\n";
    private const char PaddingChar = ' ';
    private readonly TextWriter _output;

    public MatrixView(TextWriter output)
    {
        _output = output;
    }

    public void Print(Matrix<T> matrix, Func<MatrixElement<T>, string>? formatter = null)
    {
        formatter ??= x => x.Value.ToString();

        var maxLengthOfElementInChars = 0;
        for (var i = 0; i < matrix.Rows; i++)
        {
            for (var j = 0; j < matrix.Columns; j++)
            {
                var element = matrix.GetElement(i, j);
                var formattedElement = formatter.Invoke(element);
                var length = formattedElement.Length;

                if (length > maxLengthOfElementInChars)
                    maxLengthOfElementInChars = length;
            }
        }

        for (var i = 0; i < matrix.Rows; i++)
        {
            for (var j = 0; j < matrix.Columns; j++)
            {
                var element = matrix.GetElement(i, j);
                var formattedElement = formatter.Invoke(element);
                formattedElement = formattedElement.PadRight(maxLengthOfElementInChars, PaddingChar);

                _output.Write(formattedElement);

                var isLastElementInRow = j < matrix.Columns - 1;
                if (isLastElementInRow)
                    _output.Write(ColumnSeparator);
            }

            _output.Write(RowSeparator);
        }
    }
}