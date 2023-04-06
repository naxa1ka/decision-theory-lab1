using Lab1.Matrix;

namespace Lab1.IterationMethod;

public interface IIterationMethodView<T> where T : IComparable<T>
{
    void Print(int currentIteration,
        int matrixSize,
        MatrixElement<T>[] sumOfFirstPlayer, MatrixElement<T> prevMinElement,
        float d2,
        float d2Max,
        MatrixElement<T>[] sumOfSecondPlayer, MatrixElement<T> prevMaxElement,
        float d1,
        float d1Min,
        float dk);
}