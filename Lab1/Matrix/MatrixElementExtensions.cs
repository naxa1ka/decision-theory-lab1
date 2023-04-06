namespace Lab1.Matrix;

public static class MatrixElementExtensions
{
    public static MatrixElement<T>[] Add<T>(this MatrixElement<T>[] firstArray, MatrixElement<T>[] secondArray) where T : IComparable<T>
    {
        if (firstArray.Length != secondArray.Length)
            throw new ArgumentException("The arrays must have the same length to be added.");

        var result = new MatrixElement<T>[firstArray.Length];
        for (var i = 0; i < firstArray.Length; i++) 
            result[i] = firstArray[i] + secondArray[i];

        return result;
    }

    public static MatrixElement<T> Min<T>(this MatrixElement<T>[] array) where T : IComparable<T>
    {
        return array.MinBy(element => element.Value);
    }
    
    public static MatrixElement<T> Max<T>(this MatrixElement<T>[] array) where T : IComparable<T>
    {
        return array.MaxBy(element => element.Value);
    }

    public static MatrixElement<T>[] CreateEmptyArray<T>(int matrixSize) where T : IComparable<T>
    {
        var array = new MatrixElement<T>[matrixSize];
        for (var i = 0; i < array.Length; i++) 
            array[i] = new MatrixElement<T>(0, 0, default);
        return array;
    }
}