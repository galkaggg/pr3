namespace LibMas
{   public class RandomMatrix
    {
        public static void RandMatrix(out int[,] matrix, int column, int row, int randMax)//Метод, вывод данных через переменную matrix,
                                                                                          //а переменная column(Столбцы),переменная row(Строки)
                                                                                          //и переменная randMax(Максимальное рандомное число) это ввод данных
        {
            Random rnd; rnd = new Random();//Создание random
            matrix = new int[row, column];//Присваивание к matrix переменных row(Строк) и column(Столбцов)
            for (int i = 0; i < row; i++)//Цикл для заполнения строк
            {
                for (int j = 0; j < column; j++)//Цикл для заполнения столбцов
                {
                    matrix[i, j] = rnd.Next(randMax);//Присваивание в строки и столбы рандомных чисел
                }
            }
        }
    }
}

