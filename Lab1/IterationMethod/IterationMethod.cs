using Lab1.Matrix;

namespace Lab1.IterationMethod;

public class IterationMethod
{
    private readonly IIterationMethodView<int> _view;
    
    private readonly IHighlightedMatrixView<int> _matrixView;
    private readonly Matrix<int> _matrix;

    private MatrixElement<int>[] _sumOfFirstPlayer;
    private MatrixElement<int>[] _sumOfSecondPlayer;
    private MatrixElement<int> _prevMinElement;
    private MatrixElement<int> _prevMaxElement;

    private int _currentIteration;

    private float _d1Min = float.MaxValue;
    private float _d2Max = float.MinValue;
    private float _d1;
    private float _d2;
    private float _dk;

    public IterationMethod(
        IIterationMethodView<int> view,
        IHighlightedMatrixView<int> matrixView,
        Matrix<int> matrix)
    {
        _matrix = matrix;
        if (_matrix.HasSaddlePoint(Comparer<int>.Default))
            throw new ArgumentException("The matrix must not have a saddle point");
        _view = view;
        _matrixView = matrixView;
        _sumOfFirstPlayer = MatrixElementExtensions.CreateEmptyArray<int>(_matrix.Rows);
        _sumOfSecondPlayer = MatrixElementExtensions.CreateEmptyArray<int>(_matrix.Rows);
    }

    public void Run(int indexOfFirstRow, int countOfIterations)
    {
        _currentIteration = 1;
        Iterate(indexOfFirstRow);
        
        for (_currentIteration = 2; _currentIteration < countOfIterations + 1; _currentIteration++)
            Iterate(_prevMaxElement.Row);
    }

    private void Iterate(int indexOfRow)
    {
        IterateFirstPlayer(indexOfRow);
        PrintSelectedRow();

        IterateSecondPlayer(_prevMinElement.Column);
        PrintSelectedColumn();

        CalculateD();
        Print();
    }

    private void IterateFirstPlayer(int row)
    {
        _sumOfFirstPlayer = _matrix
            .GetRow(row)
            .Add(_sumOfFirstPlayer);
        _prevMinElement = _sumOfFirstPlayer.Min();
    }

    private void IterateSecondPlayer(int column)
    {
        _sumOfSecondPlayer = _matrix
            .GetColumn(column)
            .Add(_sumOfSecondPlayer);
        _prevMaxElement = _sumOfSecondPlayer.Max();
    }


    private void PrintSelectedRow()
    {
        var rowMatrix = _matrix.ChangeRow(_prevMinElement.Row, _sumOfFirstPlayer);
        _matrixView.Print(rowMatrix,
            x => x.Row == _prevMinElement.Row,
            x => x.Equals(_prevMinElement));
    }

    private void PrintSelectedColumn()
    {
        var columnMatrix = _matrix.ChangeColumn(_prevMaxElement.Column, _sumOfSecondPlayer);
        _matrixView.Print(columnMatrix,
            x => x.Column == _prevMaxElement.Column,
            x => x.Equals(_prevMaxElement));
    }

    private void CalculateD()
    {
        _d1 = _prevMaxElement.Value / (float)_currentIteration;
        _d2 = _prevMinElement.Value / (float)_currentIteration;

        if (_d1 < _d1Min)
            _d1Min = _d1;
        if (_d2 > _d2Max)
            _d2Max = _d2;

        _dk = _d1Min - _d2Max;
    }

    private void Print()
    {
        _view.Print(_currentIteration,
            matrixSize: _matrix.Rows,
            _sumOfFirstPlayer, _prevMinElement,
            _d2, _d2Max,
            _sumOfSecondPlayer, _prevMaxElement,
            _d1, _d1Min, _dk);
    }
}