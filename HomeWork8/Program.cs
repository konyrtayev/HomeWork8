Console.Clear();

Tasks t = new Tasks();
Methods m = new Methods();

bool isWork = true;
string mainMenuText = $"Если хотите вызвать справку, напишите - /help.{Environment.NewLine}"
                    + $"Если хотите завершить работу программы, напишите - exit.{Environment.NewLine}"
                    + $"Если хотите очистить терминал, напишите clear.{Environment.NewLine}{Environment.NewLine}"
                    + $"Какую задачу хотите проверить?{Environment.NewLine}Напишите номер задачи от 1 до 5: ";

while (isWork)
{
  Console.Write(mainMenuText);
  string word = Console.ReadLine();
  Console.WriteLine();

  if (m.CheckNumberOfTask(word))
  {
    switch (word)
    {
      case "1":
      {
        t.Task54_SortRowsInArray();
        m.ToEndTask();
        break;
      }
      case "2":
      {
        t.Task56_FindRowWithMinimalSum();
        m.ToEndTask();
        break;
      }
      case "3":
      {
        t.Task58_MultiplyMatrix();
        m.ToEndTask();
        break;
      }
      case "4":
      {
        t.Task60_FillThreeDimensionArrayWIthTwoUnicDigits();
        m.ToEndTask();
        break;
      }
      case "5":
      {
        t.Task62_FillArraySpirally();
        m.ToEndTask();
        break;
      }
    }
  }
  else if (word.ToLower() == "e" || word.ToLower() == "exit" || word.ToLower() == "у")
  {
    isWork = false;
  }
  else if (word.ToLower() == "c" || word.ToLower() == "clear" || word.ToLower() == "с")
  {
    Console.Clear();
  }
  else if (word.ToLower() == "/help" || word.ToLower() == "h" || word.ToLower() == "р")
  {
    m.ToHelp();
  }
  else
  {
    Console.WriteLine($"Команда не была распознана, повторите ввод{Environment.NewLine}");
  }
}

public class Methods
{
  #region MethodsForTasks

  public int ReadInt(string arg)
  {
    Console.Write($"Введите {arg}: ");
    int num;

    while (!int.TryParse(Console.ReadLine(), out num))
    {
      Console.Write("Значение не подходит, повторите: ");
    }

    return num;
  }

  public void PrintTwoDimensionArray(int[,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        Console.Write($"{array[i, j]} ");
      }

      Console.WriteLine();
    }

    Console.WriteLine();
  }

  public void PrintThreeDimensionArray(int[,,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        for (int k = 0; k < array.GetLength(2); k++)
        {
          Console.WriteLine($"{array[i, j, k]}({i}, {j}, {k})");
        }
      }
    }

    Console.WriteLine();
  }

  public int[,] GetTwoDimensionArray(int firstLength, int secondLength)
  {
    int[,] array = new int[firstLength, secondLength];

    return array;
  }

  public void FillRandomlyTwoDimensionArray(int[,] array, int minValue, int maxValue)
  {
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        array[i, j] = random.Next(minValue, maxValue + 1);
      }
    }
  }
  public void FillArrayWithTwoUnicDigits(int[] array)
  {
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
      bool isUnic = false;

      while (!isUnic)
      {
        array[i] = random.Next(10, 100);

        if (CheckArrayUnic(array, i))
        {
          isUnic = true;
        }
      }
    }
  }

  public bool CheckArrayUnic(int[] array, int i)
  {
    for (int j = 0; j < i; j++)
    {
      if (i == 0)
      {
        return true;
      }
      else if (array[i] == array[j])
      {
        return false;
      }
    }

    return true;
  }

  public void FillThreeDimensionArray(int[,,] array, int[] numbers)
  {
    int l = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        for (int k = 0; k < array.GetLength(2); k++)
        {
          array[i, j, k] = numbers[l++];
        }
      }
    }
  }

  public void FillManuallyTwoDimensionArray(int[,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        array[i, j] = ReadInt($"число на позицию [{i}, {j}]");
      }
    }
  }

  public int[,] FillArrayLikeDecided(bool whatMethod, int whatMethodNumber, int[,] array)
  {
    if (whatMethod)
    {
      if (whatMethodNumber == 1)
      {
        FillManuallyTwoDimensionArray(array);
        Console.WriteLine();
        PrintTwoDimensionArray(array);
        return array;
      }
      else if (whatMethodNumber == 2)
      {
        FillRandomlyTwoDimensionArray(array, ReadInt("минимальное значение наполнения"), ReadInt("максимальное значение наполнения"));
        Console.WriteLine();
        PrintTwoDimensionArray(array);
        return array;
      }
    }

    Console.WriteLine($"Команду неудалось распознать, заполним случайным образом.{Environment.NewLine}");

    FillRandomlyTwoDimensionArray(array, 1, 9);
    PrintTwoDimensionArray(array);
    return array;
  }

  public void SortRowsInArray(int[,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        SortRowInArray(array, i, j);
      }
    }
  }

  public void SortRowInArray(int[,] array, int i, int j)
  {
    for (int k = j + 1; k < array.GetLength(1); k++)
    {
      if (array[i, j] < array[i, k])
      {
        int temporary = array[i, k];
        array[i, k] = array[i, j];
        array[i, j] = temporary;
      }
    }
  }

  public int FindRowWithMinimalSum(int[,] array)
  {
    int minSum = int.MaxValue;
    int index = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
      int rowSum = 0;

      for (int j = 0; j < array.GetLength(1); j++)
      {
        rowSum += array[i, j];
      }

      if (minSum > rowSum)
      {
        minSum = rowSum;
        index = i;
      }
    }

    return index;
  }

  public string CopyRowFromArray(int[,] array, int indexOfRow)
  {
    string result = string.Empty;

    for (int j = 0; j < array.GetLength(1); j++)
    {
      if (j == array.GetLength(1) - 1)
      {
        result += $"{array[indexOfRow, j]}";
      }
      else
      {
        result += $"{array[indexOfRow, j]}, ";
      }
    }

    return result;
  }

  public (bool first, int second) ChooseFillingMethod(string arg)
  {
    Console.WriteLine($"Каким способом хотите заполнить {arg} массив? Введите \"1\" для ручного заполнения или \"2\" для случайного наполнения.");
    int number = ReadInt("цифру");

    if (number == 1)
    {
      return (true, 1);
    }
    else if (number == 2)
    {
      return (true, 2);
    }
    else
    {
      return (false, 0);
    }
  }

  public bool CheckMyMatrixBeforeMultiply(int[,] firstArray, int[,] secondArray)
  {
    if (firstArray.GetLength(1) == secondArray.GetLength(0))
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public void MultiplyTwoMatrix(int[,] firstArray, int[,] secondArray, int[,] result)
  {
    for (int i = 0; i < result.GetLength(0); i++)
    {
      for (int j = 0; j < result.GetLength(1); j++)
      {
        result[i, j] = CalculateElementRecursion(firstArray, secondArray, i, j, 0);
      }
    }
  }

  public int CalculateElementRecursion(int[,] firstArray, int[,] secondArray, int i, int j, int index)
  {
    if (firstArray.GetLength(1) > index && secondArray.GetLength(0) > index)
    {
      return firstArray[i, index] * secondArray[index, j] + CalculateElementRecursion(firstArray, secondArray, i, j, index + 1);
    }

    return 0;
  }

  public void FillArraySpirally(int[,] array)
  {
    
  }

  

  #endregion

  #region MethodsForWork

  public bool CheckNumberOfTask(string number)
  {
    return (number == "1" || number == "2" || number == "3" || number == "4" || number == "5");
  }

  public void ToEndTask()
  {
    Console.WriteLine($"Для возврата в главное меню, нажмите любую кнопку{Environment.NewLine}");
    Console.ReadKey();
  }

  public void ToHelp()
  {
    Console.Clear();
    string text = $"Справка:{Environment.NewLine}1. Посчитать, сколько введено чисел больше 0.{Environment.NewLine}"
                + $"2. Нахождение точки пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2.{Environment.NewLine}"
                + $"/help или /h. Справка{Environment.NewLine}Exit или E. Завершение работы программы";

    Console.WriteLine(text);
    ToEndTask();
    Console.Clear();
  }

  #endregion
}


internal class Tasks
{
  Methods m = new Methods();

  public void Task54_SortRowsInArray()
  {
    string text = $"Вы выбрали задачу номер 1{Environment.NewLine}Упорядочить по убыванию элементы каждой строки двумерного массива.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = m.GetTwoDimensionArray(m.ReadInt("первую длину"), m.ReadInt("вторую длину"));
    int minValue = m.ReadInt("минимальное значение наполнения");
    int maxValue = m.ReadInt("максимальное значение наполнения");

    m.FillRandomlyTwoDimensionArray(array, minValue, maxValue);
    m.PrintTwoDimensionArray(array);
    m.SortRowsInArray(array);
    m.PrintTwoDimensionArray(array);
  }

  public void Task56_FindRowWithMinimalSum()
  {
    string text = $"Вы выбрали задачу номер 2{Environment.NewLine}Найти строку с наименьшей суммой элементов.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = m.GetTwoDimensionArray(m.ReadInt("первую длину"), m.ReadInt("вторую длину"));
    int minValue = m.ReadInt("минимальное значение наполнения");
    int maxValue = m.ReadInt("максимальное значение наполнения");
    Console.WriteLine();

    m.FillRandomlyTwoDimensionArray(array, minValue, maxValue);
    m.PrintTwoDimensionArray(array);
    int indexOfRow = m.FindRowWithMinimalSum(array);
    string row = m.CopyRowFromArray(array, indexOfRow);

    Console.WriteLine($"Индекс ряда [{row}] с минимальной суммой: {indexOfRow}{Environment.NewLine}");
  }

  public void Task58_MultiplyMatrix()
  {
    string text = $"Вы выбрали задачу номер 3{Environment.NewLine}"
                + $"Найти произведение двух матриц.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = new int[m.ReadInt("первую длину первой матрицы"), m.ReadInt("вторую длину первой матрицы")];
    int[,] arr = new int[m.ReadInt("первую длину второй матрицы"), m.ReadInt("вторую длину второй матрицы")];
    bool checkArrays = m.CheckMyMatrixBeforeMultiply(array, arr);

    if (checkArrays)
    {
      Console.WriteLine($"{Environment.NewLine}Такие матрицы можно перемножать.{Environment.NewLine}");

      var firstMethod = m.ChooseFillingMethod("первый");
      array = m.FillArrayLikeDecided(firstMethod.first, firstMethod.second, array);

      var secondMethod = m.ChooseFillingMethod("второй");
      arr = m.FillArrayLikeDecided(secondMethod.first, secondMethod.second, arr);

      int[,] result = new int[array.GetLength(0), arr.GetLength(1)];

      m.MultiplyTwoMatrix(array, arr, result);
      m.PrintTwoDimensionArray(result);
    }
    else
    {
      Console.WriteLine($"{Environment.NewLine}Такие матрицы нельзя перемножить, так как количество столбцов первой матрицы не равно количеству строк второй матрицы.");
    }
  }

  public void Task60_FillThreeDimensionArrayWIthTwoUnicDigits()
  {
    string text = $"Вы выбрали задачу номер 4{Environment.NewLine}"
                + $"Сформировать трёхмерный массив из неповторяющихся двузначных чисел.{Environment.NewLine}";
    Console.WriteLine(text);

    int[] randomNumbers = new int[90];
    m.FillArrayWithTwoUnicDigits(randomNumbers);

    int[,,] result;
    int firstLength = 0;
    int secondLength = 0;
    int thirdLength = 0;
    bool isLegit = false;

    while (!isLegit)
    {
      firstLength = m.ReadInt("первую длину");
      secondLength = m.ReadInt("вторую длину");
      thirdLength = m.ReadInt("третью длину");
      Console.WriteLine();

      if (firstLength * secondLength * thirdLength <= 90)
      {
        isLegit = true;
      }
      else
      {
        Console.WriteLine($"Размер вашего массива больше 90 элементов, не хватит уникальных чисел.{Environment.NewLine}"
                        + $"Попробуйте ещё раз.{Environment.NewLine}");
      }
    }

    result = new int[firstLength, secondLength, thirdLength];
    m.FillThreeDimensionArray(result, randomNumbers);
    m.PrintThreeDimensionArray(result);
  }

  public void Task62_FillArraySpirally()
  {
    string text = $"Вы выбрали задачу номер 5{Environment.NewLine}"
                + $"Заполнить массив спирально.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = new int[m.ReadInt("первую длину"), m.ReadInt("вторую длину")];
    m.PrintTwoDimensionArray(array);

    bool isPlus = true;
    bool isHorizontal = true;
    int quantity = array.GetLength(0) * array.GetLength(1);
    int n = 1;
    int i = 0;
    int j = 0;
    int xOffset = 0;
    int yOffset = 0;


    while (n <= quantity)
    {
      if (isHorizontal)
      {
        if (isPlus)
        {
          if (j < array.GetLength(1) - xOffset)
          {
            array[i, j++] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            i++;
            j--;
            isHorizontal = false;
          }
        }
        else
        {
          if (j > xOffset)
          {
            array[i, --j] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            isHorizontal = false;
            xOffset++;
          }
        }
      }
      else //vertical
      {
        if (isPlus)
        {
          if (i < array.GetLength(0) - yOffset)
          {
            array[i++, j] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            i--;
            isHorizontal = true;
            isPlus = false;
            yOffset++;
          }
        }
        else
        {
          if (i > yOffset)
          {
            array[--i, j] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            j++;
            isHorizontal = true;
            isPlus = true;
          }
        }
      }
    }
  }
}