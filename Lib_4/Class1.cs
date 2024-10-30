namespace Lib_4
{
    public class ClassProizvedenie
    {
        public static void ProizvMatrix(out int proizMatrix, int[,] matrix)//Метод, вывод proizMatrix(произведение столбцов),
                                                                           //а matrix(Матрица) ввод данных
        {
            proizMatrix = 1;//Присваивается значение 1,
                            //а то если будет 0, то и в ответе будет 0 ;)
            for (int j = 0; j < matrix.GetLength(0); j ++)//Цикл которые считывает каджую столбец
            {
                for (int k = 0; k < matrix.GetLength(1); k ++)
                proizMatrix *= matrix[k, j];//Умножается и присваивается значения от matrix 
            }
        }
    }
}
