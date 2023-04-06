using Lab1.Matrix;

namespace Lab1.IterationMethod;

public class IterationMethod
{
    private readonly IIterationMethodView<int> _view;

    private readonly Matrix<int> _matrix;

    private MatrixElement<int>[] _sumOfFirstPlayer;
    private MatrixElement<int>[] _sumOfSecondPlayer;
    private MatrixElement<int> _prevMinElement;
    private MatrixElement<int> _prevMaxElement;

    private readonly int _countOfIterations;
    private int _currentIteration;

    private float _d1Min = float.MaxValue;
    private float _d2Max = float.MinValue;

    public IterationMethod(
        IIterationMethodView<int> view,
        Matrix<int> matrix,
        int countOfIterations,
        int indexOfFirstRow)
    {
        _matrix = matrix;
        if (_matrix.HasSaddlePoint(Comparer<int>.Default))
            throw new ArgumentException("The matrix must not have a saddle point");
        _view = view;
        _countOfIterations = countOfIterations;
        _sumOfFirstPlayer = MatrixElementExtensions.CreateEmptyArray<int>(_matrix.Rows);
        _sumOfSecondPlayer = MatrixElementExtensions.CreateEmptyArray<int>(_matrix.Rows);
        _prevMaxElement = new MatrixElement<int>(indexOfFirstRow, -1, -1);
    }

    public void Run()
    {
        for (_currentIteration = 1; _currentIteration < _countOfIterations + 1; _currentIteration++)
            Iterate();
    }

    private void Iterate()
    {
        _sumOfFirstPlayer = _matrix
            .GetRow(_prevMaxElement.Row)
            .Add(_sumOfFirstPlayer);
        _prevMinElement = _sumOfFirstPlayer.Min();

        _sumOfSecondPlayer = _matrix
            .GetColumn(_prevMinElement.Column)
            .Add(_sumOfSecondPlayer);
        _prevMaxElement = _sumOfSecondPlayer.Max();

        var d1 = _prevMaxElement.Value / (float)_currentIteration;
        var d2 = _prevMinElement.Value / (float)_currentIteration;

        if (d1 < _d1Min)
            _d1Min = d1;
        if (d2 > _d2Max)
            _d2Max = d2;

        var dk = _d1Min - _d2Max;

        _view.Print(_currentIteration,
            matrixSize: _matrix.Rows,
            _sumOfFirstPlayer, _prevMinElement,
            d2, _d2Max,
            _sumOfSecondPlayer, _prevMaxElement,
            d1, _d1Min, dk);
    }
}