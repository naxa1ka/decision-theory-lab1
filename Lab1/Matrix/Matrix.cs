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

    public Matrix<T> ChangeRow(int rowIndex, MatrixElement<T>[] row)
    {
        T[,] destArray = (T[,])_data.Clone();
        for (var i = 0; i < destArray.GetLength(1); i++) 
            destArray[rowIndex, i] = row[i].Value;
        return new Matrix<T>(destArray);
    }

    public Matrix<T> ChangeColumn(int columnIndex, MatrixElement<T>[] column)
    {
        T[,] destArray = (T[,])_data.Clone();
        for (var i = 0; i < destArray.GetLength(0); i++) 
            destArray[i, columnIndex] = column[i].Value;
        return new Matrix<T>(destArray);
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

    public bool HasSaddlePoint(IComparer<T> comparer)
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var currentElement = new MatrixElement<T>(GetElement(i, j));
                var rowElements = GetRow(i);
                var columnElements = GetColumn(j);

                var isRowMinimum =
                    rowElements.All(x => comparer.Compare(x.Value, currentElement.Value) >= 0);
                var isColumnMaximum =
                    columnElements.All(x => comparer.Compare(x.Value, currentElement.Value) <= 0);

                if (isRowMinimum && isColumnMaximum)
                    return true;
            }
        }

        return false;
    }
}