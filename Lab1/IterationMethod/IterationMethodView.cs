using System.Text;
using Lab1.Matrix;
using Lab1.Matrix.Formatting;

namespace Lab1.IterationMethod;

public class IterationMethodView<T> : IIterationMethodView<T> where T : IComparable<T>
{
    private readonly string _separatorBetweenItems = $"{"|",2}";
    private const string Format = "F2";
    private const int AlignmentItemsLength = 6;

    private readonly TextWriter _textWriter;
    private readonly IMatrixElementFormatter<T> _defaultFormatter;
    private readonly IMatrixElementFormatter<T> _highlightFormatter;
    private readonly IFormatProvider _formatProvider;
    private bool _isHeaderShown;
    
    public IterationMethodView(
        TextWriter textWriter,
        IFormatProvider formatProvider,
        IMatrixElementFormatter<T> defaultFormatter,
        IMatrixElementFormatter<T> highlightFormatter)
    {
        _textWriter = textWriter;
        _defaultFormatter = defaultFormatter;
        _highlightFormatter = highlightFormatter;
        _formatProvider = formatProvider;
    }
    
    public void Print(int currentIteration,
        int matrixSize,
        MatrixElement<T>[] sumOfFirstPlayer, MatrixElement<T> prevMinElement,
        float d2, float d2Max,
        MatrixElement<T>[] sumOfSecondPlayer, MatrixElement<T> prevMaxElement,
        float d1, float d1Min,
        float dk)
    {
        if (!_isHeaderShown)
        {
            PrintHeader(matrixSize);
            _isHeaderShown = true;
        }

        var str = GetFilledLine(currentIteration,
            sumOfFirstPlayer, prevMinElement,
            d2, d2Max,
            sumOfSecondPlayer, prevMaxElement,
            d1, d1Min,
            dk);
        _textWriter.WriteLine(str);
    }

    private void PrintHeader(int matrixSize)
    {
        var str = GetHeader(matrixSize);
        _textWriter.WriteLine(str);
    }

    private string GetHeader(int rows)
    {
        var firstArray = new string[rows];
        for (var i = 0; i < rows; i++)
            firstArray[i] = $"{i + 1}B";

        var secondArray = new string[rows];
        for (var i = 0; i < rows; i++)
            secondArray[i] = $"{i + 1}A";

        return GetFormattedLine("k", firstArray, "d2", "d2m", secondArray, "d1", "d1m", "dk");
    }

    
    private string GetFilledLine(int currentIteration,
        MatrixElement<T>[] sumOfFirstPlayer, MatrixElement<T> prevMinElement,
        float d2, float d2Max,
        MatrixElement<T>[] sumOfSecondPlayer, MatrixElement<T> prevMaxElement,
        float d1, float d1Min,
        float dk
    )
    {
        var firstArray = sumOfFirstPlayer
            .Select(x => x.Equals(prevMinElement) ? _highlightFormatter.Format(x) : _defaultFormatter.Format(x))
            .ToArray();

        var secondArray = sumOfSecondPlayer
            .Select(x => x.Equals(prevMaxElement) ? _highlightFormatter.Format(x) : _defaultFormatter.Format(x))
            .ToArray();

        return GetFormattedLine(currentIteration.ToString(),
            firstArray,
            d2.ToString(Format, _formatProvider), d2Max.ToString(Format, _formatProvider),
            secondArray,
            d1.ToString(Format, _formatProvider), d1Min.ToString(Format, _formatProvider),
            dk.ToString(Format, _formatProvider)
        );
    }

    private string GetFormattedLine(
        string k,
        string[] firstArray,
        string d2, string d2Max,
        string[] secondArray,
        string d1, string d1Min,
        string dk
    )
    {
        var sb = new StringBuilder();

        sb.Append($"{k,AlignmentItemsLength}");
        sb.Append(_separatorBetweenItems);

        foreach (var item in firstArray)
            sb.Append($"{item,AlignmentItemsLength}");

        sb.Append(_separatorBetweenItems);
        sb.Append($"{d2,AlignmentItemsLength}");
        sb.Append(_separatorBetweenItems);
        sb.Append($"{d2Max,AlignmentItemsLength}");
        sb.Append(_separatorBetweenItems);

        foreach (var item in secondArray)
            sb.Append($"{item,AlignmentItemsLength}");

        sb.Append(_separatorBetweenItems);
        sb.Append($"{d1,AlignmentItemsLength}");
        sb.Append(_separatorBetweenItems);
        sb.Append($"{d1Min,AlignmentItemsLength}");
        sb.Append(_separatorBetweenItems);
        sb.Append($"{dk,AlignmentItemsLength}");
        sb.Append(_separatorBetweenItems);

        return sb.ToString();
    }
}