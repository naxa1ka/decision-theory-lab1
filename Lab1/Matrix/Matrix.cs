namespace Lab1.Matrix;

public class Matrix<T> where T : IComparable<T>
{
    private readonly T[,] _data;

    public Matrix(T[,] data)
    {
        _data = data;
    }

    public int Rows => _data.GetLength(0);
    public int Columns => _data.GetLength(1);

    public MatrixElement<T> GetElement(int row, int column)
    {
        return new MatrixElement<T>(row, column, _data[row, column]);
    }

    public MatrixElement<T>[] GetRow(int rowIndex)
    {
        var row = new MatrixElement<T>[Columns];
        for (var j = 0; j < Columns; j++)
            row[j] = GetElement(rowIndex, j);

        return row;
    }

    public MatrixElement<T>[] GetColumn(int columnIndex)
    {
        var column = new MatrixElement<T>[Rows];
        for (var i = 0; i < Rows; i++)
            column[i] = GetElement(i, columnIndex);

        return column;
    }
}