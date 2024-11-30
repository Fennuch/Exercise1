namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dirName = new DirectoryInfo(@"/Users/Feona/source/repos/BasicConceptsAndDataTypes");
            
                if (dirName.Exists)
                {
                    DateTime dateTime = DateTime.Now;
                    TimeSpan interval = TimeSpan.FromMinutes(30);
                    DateTime lastTime = dateTime - interval;
            
                    Console.WriteLine("Папки:");
                    foreach (DirectoryInfo directory in dirName.GetDirectories())
                    {
                        Console.WriteLine("\nИмя папки: "+directory.Name);
                        var directoryCreatedDate = Directory.GetCreationTime(directory.FullName);
                        Console.WriteLine("Папка создана: " + directoryCreatedDate);
            
                        if (directoryCreatedDate < lastTime)
                        {
                            directory.Delete(true);
                            Console.WriteLine("Папка удалена: " + directory + "\n");
                        }
                    }
            
                    Console.WriteLine("\nФайлы:");
                    foreach (FileInfo file in dirName.GetFiles())
                    {
                        Console.WriteLine("\nИмя Файла: " + file.Name);
                        var fileCreatedDate = File.GetCreationTime(file.FullName);
                        Console.WriteLine("Фаил создан: " + fileCreatedDate);
            
                        if (fileCreatedDate < lastTime)
                        {
                            file.Delete();
                            Console.WriteLine("Файл удален: " + file + "\n");
                        }
                    }
            
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}