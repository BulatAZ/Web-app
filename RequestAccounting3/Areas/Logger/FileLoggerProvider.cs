namespace RequestAccounting3.Areas.Loger
{
    using Microsoft.Extensions.Logging;

    public class FileLoggerProvider : ILoggerProvider
    {
        private string path;

        public FileLoggerProvider(string path)
        {
            this.path = path;
        }

        /*создает и возвращает объект логгера. Для создания логгера используется путь к файлу, который передается через конструктор*/
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(this.path);
        }

        /*управляет освобождение ресурсов.В данном случае пустая реализация*/
        public void Dispose()
        {

        }
    }
}
