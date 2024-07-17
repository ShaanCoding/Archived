public class LinAlg
{
    public static double[] vectorMatrixDotProduct(double[][] mainMatrix, double[] mainVector)
    {
        double[] returnMatrix = new double[mainMatrix.length];
        if (mainVector.length == mainMatrix.length || mainVector.length == mainMatrix[0].length)
        {
            //Calculates dot product
            for(int i=0;i<mainMatrix.length;i++)
            {
                returnMatrix[i] = 0;
                for(int j=0;j<mainMatrix[0].length;j++)
                {
                    returnMatrix[i] += mainMatrix[i][j] * mainVector[j];
                }
            }
            return  returnMatrix;
        }
        else
        {
            System.out.println("ERROR: Does not satisfy dotproduct");
            return null;
        }
    }

    public static double[] vectorVectorRemove(double[] mainVector, int[] row)
    {
        double[] returnVector = new double[mainVector.length - row.length];
        int k = 0;
        int j = 0;

        for(int i = 0; i < mainVector.length; i++)
        {
            if(i != row[j])
            {
                returnVector[k] = mainVector[i];
                k++;
            }
            else if(i == row[j])
            {
                if(j == (row.length - 1))
                {
                    j = 0;
                }
                else
                {
                    j++;
                }
            }
        }
        return returnVector;
    }

    public static double[][] vectorMatrixRemove(double[][] mainMatrix, int[] rows, int[] columns)
    {
        int rowlen = mainMatrix.length;
        int collen = mainMatrix[0].length;
        int ni = 0, nj = 0;
        double[][] matrixReturn = new double[mainMatrix.length - rows.length][mainMatrix[0].length - columns.length];
        int c = 0;
        int r = 0;

        for (int i = 0; i < rowlen; i++)
        {
            if (i != rows[c])
            {
                for (int j = 0; j < collen; j++)
                {
                    if (j != columns[r])
                    {
                        matrixReturn[ni][nj++] = mainMatrix[i][j];
                    }
                    if (j == columns[r])
                    {
                        if (j < (columns.length - 1))
                        {
                            r++;
                        }
                    }
                }
                ni++;
                nj = 0;
            }
            if (i == rows[c])
            {
                if (i < rows.length - 1)
                {
                    c++;
                }
            }

            r = 0;
        }
        return  matrixReturn;
    }

    public static int[] vectorAdditionByOne(int value, int[] vector)
    {
        int[] returnVector = new int[vector.length];
        for(int i = 0; i < vector.length; i++)
        {
            returnVector[i] = vector[i] + value;
        }
        return returnVector;
    }

    public static void displayVector(double[] vector)
    {
        String outputString = "| ";
        for(int i = 0;i < vector.length; i++)
        {
            outputString += i != (vector.length - 1) ?
                    vector[i] + " | " : vector[i] + " |\n";
        }
        System.out.println(outputString);
    }

    public static double[][] matrixAddition(double[][] matrixOne, double[][] matrixTwo)
    {
        double[][] returnMatrix = new double[matrixOne.length][matrixOne[0].length];
        for(int i = 0; i < matrixOne.length; i++)
        {
            for(int j = 0; j < matrixOne[0].length; j++)
            {
                returnMatrix[i][j] = matrixOne[i][j] + matrixTwo[i][j];
            }
        }
        return returnMatrix;
    }

    public double vectorVectorDotProduct(double[] vectorOne, double[] vectorTwo)
    {
        double returnValue = 0;
        for(int i = 0; i < vectorOne.length; i++)
        {
            returnValue += vectorOne[i] * vectorTwo[i];
        }
        return returnValue;
    }

    public static double[][] generateEmptyMatrix(int columns, int rows)
    {
        double[][] returnMatrix = new double[columns][rows];
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                returnMatrix[i][j] = 0;
            }
        }
        return returnMatrix;
    }

    public static double[][] oneValueMultiplyMatrix(double oneValue, double[][] mainMatrix)
    {
        double[][] returnMatrix = new double[mainMatrix.length][mainMatrix[0].length];
        for(int i = 0; i < mainMatrix.length; i++)
        {
            for(int j = 0; j < mainMatrix[0].length; j++)
            {
                returnMatrix[i][j] = mainMatrix[i][j] * oneValue;
            }
        }
        return returnMatrix;
    }

    public static void displayMatrix(double[][] mainMatrix)
    {
        String displayString = "\n-=== Matrix ==-\n| ";
        for(int i = 0; i < mainMatrix.length; i++)
        {
            for(int j = 0; j < mainMatrix[0].length; j++)
            {
                displayString += i != (mainMatrix.length - 1) ?
                        "| " + mainMatrix[i][j] + " | " : "| " + mainMatrix[i][j] + " |";
            }
        }
        System.out.println(displayString);
    }

    public static double[][] inverseMatrix(double[][] mainMatrix)
    {
        int matrixLength = mainMatrix.length;
        double determinant = determinantSolver(mainMatrix, matrixLength);
        double[][] inverseMatrix = new double[matrixLength][matrixLength];
        double inverseDeterminant;
        double[][] transposedAdjoint = transposeSolver(adjointSolver(mainMatrix));
        if(determinant == 0)
        {
            return null;
        }
        else
        {
            inverseDeterminant = 1 / determinant;
            inverseMatrix = oneValueMultiplyMatrix(inverseDeterminant, transposedAdjoint);
            return inverseMatrix;
        }
    }

    public static double[][] matrixMatrixMultiplication(double[][] matrixOne, double[][] matrixTwo)
    {
        double[][] returnMatrix = generateEmptyMatrix(matrixOne.length, matrixTwo[0].length);
        for(int i = 0; i < returnMatrix.length; i++)
        {
            for(int j = 0; j < returnMatrix[0].length; j++)
            {
                for(int k = 0; k < matrixOne[0].length; k++)
                {
                    returnMatrix[i][j] = matrixOne[i][k] * matrixTwo[k][j];
                }
            }
        }
        return returnMatrix;
    }

    public static double[][] transposeSolver(double[][] mainMatrix)
    {
        double[][] transposeMatrix = new double[mainMatrix[0].length][mainMatrix.length];
        for (int i = 0; i < mainMatrix.length; i++)
        {
            for (int j = 0; j < mainMatrix[0].length; j++)
            {
                transposeMatrix[j][i] = mainMatrix[i][j];
            }
        }
        return transposeMatrix;
    }

    public static double[][] adjointSolver(double[][] mainMatrix)
{
    //Matrix of coefficents
    int lengthOfMatrix = mainMatrix.length;
    double[][] miniMatrix = new double[lengthOfMatrix][lengthOfMatrix];
    double[][] returnMatrix = new double[lengthOfMatrix][lengthOfMatrix];

    for (int rows = 0; rows < lengthOfMatrix; rows++)
    {
        for (int columns = 0; columns < lengthOfMatrix; columns++)
        {
            miniMatrix = rowColumnRemover(mainMatrix, rows, columns);
            returnMatrix[rows][columns] = determinantSolver(miniMatrix, miniMatrix.length) * (Math.pow((-1), (rows + 1 + columns + 1)));

        }
    }



    return returnMatrix;
}

    public static double[][] rowColumnRemover(double[][] mainMatrix, int row, int column)
    {
        double[][] matrixReturn = new double[mainMatrix.length - 1][(mainMatrix[0].length - 1)];
        int k = 0;
        int l = 0;
        int m = 0;
        int n = 0;

        for (int i = 0; i < mainMatrix.length; i++)
        {
            for (int j = 0; j < mainMatrix[0].length; j++)
            {

                if (i != row && j != column)
                {
                    matrixReturn[m][n] = mainMatrix[i][j];
                    m++;
                    if (m == (mainMatrix.length - 1))
                    {
                        m = 0;
                        n++;
                    }
                }
                if (k < (mainMatrix[0].length - 1))
                {
                    k++;
                }
                else
                {
                    k = 0;
                    l++;
                }
            }
        }
        return matrixReturn;
    }

    public static double determinantSolver(double[][] mainMatrix, int lengthOfMatricies)
    {
        //Determinate Solver Variables
        double determinate = 0;
        int objectOfMatriciesDeterminantToCalculate;
        int evenOrOddSwitch = 1;
        double[][] miniArray = new double[lengthOfMatricies][lengthOfMatricies];
        int rows;
        int columns;
        int miniMatrixRows;
        int miniMatrixColumns;

        //Exits Loop if matricies is 1*1
        if (lengthOfMatricies == 1)
        {
            return mainMatrix[0][0];
        }
        else
        {
            determinate = 0;
            for (objectOfMatriciesDeterminantToCalculate = 0; objectOfMatriciesDeterminantToCalculate < lengthOfMatricies; objectOfMatriciesDeterminantToCalculate++)
            {
                miniMatrixRows = 0;
                miniMatrixColumns = 0;

                //Row column remover
                //Replace with function
                for (rows = 0; rows < lengthOfMatricies; rows++)
                {
                    for (columns = 0; columns < lengthOfMatricies; columns++)
                    {
                        miniArray[rows][columns] = 0;
                        if (rows != 0 && columns != objectOfMatriciesDeterminantToCalculate)
                        {

                            miniArray[miniMatrixRows][miniMatrixColumns] = mainMatrix[rows][columns];
                            if (miniMatrixColumns < (lengthOfMatricies - 2))
                            {
                                miniMatrixColumns++;
                            }
                            else
                            {
                                miniMatrixColumns = 0;
                                miniMatrixRows++;
                            }
                        }
                    }
                }

                //Endfunction

                //Sums of determinate of each matricies and then inverts even or odd switch to equate
                determinate = determinate + evenOrOddSwitch * (mainMatrix[0][objectOfMatriciesDeterminantToCalculate] * determinantSolver(miniArray, lengthOfMatricies - 1));
                evenOrOddSwitch = evenOrOddSwitch * -1;
            }
        }
        return determinate;
    }
}

