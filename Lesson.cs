//using System.Globalization;
//using System.Security.Cryptography.X509Certificates;

//namespace Les_7
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //взвємодія з файловими системами
//            //// ? - налибл - пердбачаємо що можемо поставити null
//            //Test(5, 7);
//            //Test(5, null);
//            ////Test(null, 7); // помилка
//            //Test(8);
//            ////string є null навіть без уточнення
//            //Test(5, "7");
//            //Test(5, null); //warning не помилка
//            ////string це клас
//            ////1-4.7 - .net - неможливо string?
//            //------------------------------------------------------------------------

//            File.WriteAllText("example.txt", "Hello, World!");

//            if (File.Exists("example.txt"))
//            {
//                Console.WriteLine("Файл не існує");
//                return;
//            }

//            string content = File.ReadAllText("example.txt");
//            Console.WriteLine(content);

//            File.Delete("example.txt");

//            //string str = "World!";
//            //Console.WriteLine("Hello" + str);
//            //Console.WriteLine($"Hello + {str}");

//            //------------------------------------------------------------------------
//            //назва фалу - на робочий стіл зберегти 
//            //абсолютний шлях
//            // назву фалу вводить користучвач
//            //${}
//            //+

//            //------------------------------------------------------------------------
//            //string desktopPath = @"C:\Users\Admin\OneDrive\Рабочий стол";

//            //Console.Write("Введіть назву файлу: ");
//            //string fileName = Console.ReadLine();

//            //string fullPath = $"{desktopPath}\\{fileName}.txt";

//            //File.WriteAllText(fullPath, "Hello, World!");


//        }

//        //------------------------------------------------------------------------
//        //? або null або int
//        //public static void Test(int x, int? y = null)
//        //public static void Test(int x, string? y)
//        //public static void Test(int x, string y)
//        //{
//        //    if (y != null)
//        //    {
//        //        Console.WriteLine(x + y);
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine(x);
//        //    }
//        //}
//        //------------------------------------------------------------------------

//    }
//}
