using ConsoleOutputEngine.Implementations;

namespace ConsoleOutputEngine.Contracts;

public interface IMatrixDisplay
{
    void Display(List<string> matrix, int horizontalPosition);

    static IMatrixDisplay Instance => MatrixDisplay.Instance;
}
