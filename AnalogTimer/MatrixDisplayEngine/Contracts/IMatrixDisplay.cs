using MatrixDisplayEngine.Implementations;

namespace MatrixDisplayEngine.Contracts;

public interface IMatrixDisplay
{
    void Display(List<string> matrix, int horizontalPosition);

    static IMatrixDisplay Instance => MatrixDisplay.Instance;
}
