namespace MatrixDisplayEngine.Contracts;

public interface IMatrixDisplay
{
    void Display(List<string> matrix, int horizontalPosition);

    void Display(IEnumerable<List<string>> multipleMatrixes, int horizontalPosition);
}
