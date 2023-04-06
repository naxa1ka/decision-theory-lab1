using Lab1.Matrix;

namespace Lab1.IterationMethod;

public class EmptyIterationMethodView<T> : IIterationMethodView<T> where T : IComparable<T>
{
    public void Print(int currentIteration, int matrixSize, MatrixElement<T>[] sumOfFirstPlayer, MatrixElement<T> prevMinElement,
        float d2, float d2Max, MatrixElement<T>[] sumOfSecondPlayer, MatrixElement<T> prevMaxElement, float d1, float d1Min,
        float dk)
    {
        
    }
}