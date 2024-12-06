namespace Les_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("______________________________________1______________________________________");
            string filePath = GetFilePath("Введіть шлях до файлу: ");
            DisplayFileIfExists(filePath);
            DisplayFileContent(filePath);

            Console.WriteLine("______________________________________2______________________________________");
            int[] array = GetArrayFromUser();
            string savePath = GetFilePath("Шлях до файлу, для збереження: ");
            SaveArrayToFile(array, savePath);

            Console.WriteLine("______________________________________3______________________________________");
            DisplayArrayFromFileIfExist();

            Console.WriteLine("______________________________________4______________________________________");
            string evenFilePath = @"C:\Users\Admin\OneDrive\Рабочий стол\even_numbers.txt";
            string oddFilePath = @"C:\Users\Admin\OneDrive\Рабочий стол\odd_numbers.txt";
            GenerateRandomNumbersAndSaveToFile(evenFilePath, oddFilePath);

            Console.WriteLine("______________________________________5______________________________________");
            filePath = @"C:\Users\Admin\OneDrive\Рабочий стол\example.txt";
            DisplayFileIfExists(filePath);

            string word = GetUserInput("Введіть слово для пошуку: ");
            string fileContentText1 = File.ReadAllText(filePath).ToLower();
            ProcessWordOccurrences(fileContentText1, word);

            Console.WriteLine("______________________________________6______________________________________");
            filePath = GetFilePath("Введіть шлях до файлу: ");
            DisplayFileIfExists(filePath);

            string fileContentText2 = File.ReadAllText(filePath);
            ProcessTextStatistics(fileContentText2);

        }

        static void DisplayFileIfExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не існує");
            }
        }

        static void DisplayArrayFromFileIfExist()
        {
            string filePath = GetFilePath("Введіть шлях до файлу: ");
            if (File.Exists(filePath))
            {
                DisplayArrayFromFile(filePath);
            }
            else
            {
                Console.WriteLine("Файл не існує");
            }
        }

        static string GetFilePath(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void DisplayArrayFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int[] fileArray = Array.ConvertAll(lines, int.Parse);
            Console.WriteLine("Масив:");
            foreach (int element in fileArray)
            {
                Console.WriteLine(element);
            }
        }


        static void DisplayFileContent(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Вміст Файлу:");
            Console.WriteLine(fileContent);
        }

        static int[] GetArrayFromUser()
        {
            Console.Write("Введіть кількість елементів масиву: ");
            int capacity = int.Parse(Console.ReadLine());
            int[] array = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                Console.Write($"Введіть елемент {i + 1} масиву: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        static void SaveArrayToFile(int[] array, string filePath)
        {
            File.WriteAllLines(filePath, Array.ConvertAll(array, x => x.ToString()));
        }

        static void GenerateRandomNumbersAndSaveToFile(string evenFilePath, string oddFilePath)
        {
            Random random = new Random();
            int[] num = Enumerable.Range(1, 10000).Select(_ => random.Next()).ToArray();
            var evenNum = num.Where(n => n % 2 == 0).ToArray();
            var oddNum = num.Where(n => n % 2 != 0).ToArray();
            File.WriteAllLines(evenFilePath, Array.ConvertAll(evenNum, x => x.ToString()));
            File.WriteAllLines(oddFilePath, Array.ConvertAll(oddNum, x => x.ToString()));
            Console.WriteLine($"Загальна кількість чисел: {num.Length}");
            Console.WriteLine($"Кількість парних чисел: {evenNum.Length}");
            Console.WriteLine($"Кількість непарних чисел: {oddNum.Length}");
        }

        static string GetUserInput(string word)
        {
            Console.Write(word);
            return Console.ReadLine();
        }

        static void ProcessWordOccurrences(string fileContentText, string word)
        {
            int wordCount = CountWord(fileContentText, word);
            Console.WriteLine($"Кількість входжень слова '{word}': {wordCount}");
            Console.WriteLine("Входження слова:");
            FindWordPositions(fileContentText, word);

            string reversedWord = ReverseString(word);
            int reversedWordCount = CountWord(fileContentText, reversedWord);
            Console.WriteLine($"Кількість входжень слова '{reversedWord}': {reversedWordCount}");
            Console.WriteLine("Позиції входжень слова:");
            FindWordPositions(fileContentText, reversedWord);
        }

        static void ProcessTextStatistics(string fileContentText)
        {
            int sentenceCount = 0;
            int upperCaseCount = 0;
            int lowerCaseCount = 0;
            int vowelCount = 0;
            int consonantCount = 0;
            int digitCount = 0;

            foreach (char c in fileContentText)
            {
                if (char.IsUpper(c)) upperCaseCount++;
                else if (char.IsLower(c)) lowerCaseCount++;
                else if (char.IsDigit(c)) digitCount++;

                if ("aeiouAEIOU".Contains(c)) vowelCount++;
                else if (char.IsLetter(c)) consonantCount++;

                if (c == '.' || c == '!' || c == '?') sentenceCount++;
            }

            Console.WriteLine($"Кількість речень: {sentenceCount}");
            Console.WriteLine($"Кількість великих літер: {upperCaseCount}");
            Console.WriteLine($"Кількість маленьких літер: {lowerCaseCount}");
            Console.WriteLine($"Кількість голосних літер: {vowelCount}");
            Console.WriteLine($"Кількість приголосних літер: {consonantCount}");
            Console.WriteLine($"Кількість цифр: {digitCount}");
        }

        static int CountWord(string text, string word)
        {
            int count = 0;
            int index = 0;
            while (index < text.Length)
            {
                index = text.IndexOf(word, index);
                if (index == -1) break;
                count++;
                index += word.Length;
            }
            return count;
        }

        static void FindWordPositions(string text, string word)
        {
            int index = 0;
            while (index < text.Length)
            {
                index = text.IndexOf(word, index);
                if (index == -1) break;
                Console.WriteLine($"Індекс: {index}");
                index += word.Length;
            }
        }

        static string ReverseString(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
