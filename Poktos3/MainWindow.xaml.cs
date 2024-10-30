using Lib_4;
using LibMas;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poktos3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)//Закрытие программы
        {
            Close();
        }

        private void btInfo_Click(object sender, RoutedEventArgs e)//Информация
        {
            MessageBox.Show("Сделала:Галкина Ирина ИСП-34 \nЗадание:Дана матрица размера M × N. Для каждого столбца матрицы найти произведение\r\nего элементов");
        }
        int [,]matrix;
        private void btRaz_Click(object sender, RoutedEventArgs e)
        {
            bool boolCtolbciMatrix = int.TryParse(tbCtolbciMatrix.Text, out int ctolbciMatrix);//Создаем переменную boolCtolbciMatrix и метод TryParse пытается преоброзовать текст в число
                                                                                               //и если это удается, то переменная boolCtolbciMatrix принимает значение true. ctolbciMatrix это выходной парамет
            bool boolMaxMatrix = int.TryParse(tbMaxMatrix.Text, out int maxMatrix);//Создаем переменную boolMaxMatrix и метод TryParse пытается преоброзовать текст в число
                                                                                   //и если это удается, то переменная boolMaxMatrix принимает значение true. maxMatrix это выходной парамет
            bool boolCtrokiMatrix = int.TryParse(tbCtrokiMatrix.Text, out int ctrokiMatrix);//Создаем переменную boolCtrokiMatrix и метод TryParse пытается преоброзовать текст в число
                                                                                            //и если это удается, то переменная boolCtrokiMatrix принимает значение true. ctrokiMatrix это выходной парамет
            if (boolMaxMatrix == true & boolCtolbciMatrix == true & boolCtrokiMatrix == true & maxMatrix > 0)//Условие, если все переменные bool будут true и maxMatrix будет > 0
            {
                int ctolbci = Convert.ToInt32(ctolbciMatrix);//Присваиваем переменной ctolbci значение от переменной ctolbciMatrix
                int ctroki = Convert.ToInt32(ctrokiMatrix);//Присваиваем переменной ctroki значение от переменной ctrokiMatrix
                int maxRandom = Convert.ToInt32(maxMatrix);// Писваиваем переменной maxRandom значение от переменной maxMatrix
                RandomMatrix.RandMatrix(out matrix, ctolbci, ctroki, maxRandom);//Вызываем библиотеку и отдаем ей все наши переменные что бы на выходе получить заполненую матрицу рандомными числами 
                ClassProizvedenie.ProizvMatrix(out int proizMatrix, matrix);//Вызываем библиотеку и отдаем ей перменную matrix что бы на выходе получить уже произведение столбцов матрицы
                tbRez.Text = Convert.ToString(proizMatrix);//Выводим все это в textbox
            }
        }
        public void CoxMatrix(int[,] matrix)//Сохранение матрицы
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы *.*|*.*|Текстовый файл|*txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                if (matrix != null)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(matrix.GetLength(0));
                    file.WriteLine(matrix.GetLength(1));
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            file.Write(matrix[i, j] + " ");
                        }
                        file.WriteLine();
                    }
                    file.Close();
                }
            }
        }
        public void OtkrMatrix(int[,] matrix)//Открытие матрицы
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы *.*|*.*|Текстовый файл|*txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);
                string[] str = file.ReadToEnd().Split('\n');
                int row = Convert.ToInt32(str[0]);
                int column = Convert.ToInt32(str[1]);
                matrix = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    string[] line = str[i + 2].Split(' ');
                    for (int j = 0; j < column; j++)
                    {
                        matrix[i, j] = int.Parse(line[j]);
                    }
                }
                file.Close();
                ClassProizvedenie.ProizvMatrix(out int sumMatrix, matrix);
                tbRez.Text = Convert.ToString(sumMatrix);
            }
        }

        private void CoxMatrix_Click(object sender, RoutedEventArgs e)//Открытие CoxMatrix
        {
            CoxMatrix(matrix);
        }

        private void OtkrMatrix_Click(object sender, RoutedEventArgs e)//Открытие OtkrMatrix
        {
            OtkrMatrix(matrix);
        }

        private void CleanMatrix_Click(object sender, RoutedEventArgs e)//Очишаем матрицу
        {
            matrix = null;
        }
    }
}