using System;
using System.IO;

namespace prak2
{
    public class PRAK2
    {
        static void Main(string[] args)
        {
            Console.Write("Введите пути к файлам через запятую: ");
            string path = Console.ReadLine()!;
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Путь не может быть пустым");
                return;
            }

            string[] paths = path.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Console.Write("Введите слово, которое надо найти: ");
            string word = Console.ReadLine()!;
            if (string.IsNullOrEmpty(word))
            {
                Console.WriteLine("Это поле не может быть пустым");
                return;
            }

            word = word.ToLower();

            foreach (string filespath in paths)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filespath.Trim()))
                    {
                        string line;
                        int count = 0;

                        while ((line = sr.ReadLine()!) != null)
                        {
                            string lowerline = line.ToLower();
                            string[] words = lowerline.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var w in words)
                            {
                                if (w == word)
                                {
                                    count++;
                                }
                            }

                        }

                        Console.WriteLine($"В файле '{filespath.Trim()}' слово '{word}' найдено {count} раз");
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Файл '{filespath.Trim()}' не найден");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка при обработке файла '{path.Trim()}': {e.Message}");
                }
            }
        }
    }
}
