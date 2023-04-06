namespace Lab1.Matrix;

public record MatrixElement<T>(int Row, int Column, T Value) where T : IComparable<T>
{
    //where is contract with selecting row and column from element a
    public static MatrixElement<T> operator +(MatrixElement<T> a, MatrixElement<T> b)
    {
        return new MatrixElement<T>(a.Row, a.Column, (dynamic)a.Value + (dynamic)b.Value);
    }

    public virtual bool Equals(MatrixElement<T>? other)
    {
        if (other == null)
            return false;
        return Equals(other.Value, Value) && other.Column == Column && other.Row == Row;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column, Value);
    }
}