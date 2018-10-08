namespace MatrixOperations
{
    public class MatrixMath<T> where T : struct
    {
        private MatrixTable<T> matrix = new MatrixTable<T>();

        internal MatrixMath(MatrixTable<T> matrix)
        {
            this.matrix = matrix;
        }

        public bool MatricesSizeEqual (MatrixTable<T> matrixToCompare)
        {
            if (matrix.Matrix.GetLength(0) != matrixToCompare.Matrix.GetLength(0) 
                || matrix.Matrix.GetLength(1) != matrixToCompare.Matrix.GetLength(1))
                return false;
            return true;
        }
    }
}