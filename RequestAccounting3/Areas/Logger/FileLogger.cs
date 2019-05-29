namespace RequestAccounting3.Areas.Loger
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Logging;

    public class FileLogger : ILogger
    {
        private string filePath;
        private object _lock = new object();

        public FileLogger(string path)
        {
            this.filePath = path;
        }

        /*этот метод возвращает объект IDisposable, который представляет некоторую область видимости для логгера. */
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /*возвращает значения которые указыват, доступен ли логгер для использования.
         Здесь можно здать различную логику. В частности, в этот метод передается объект LogLevel, 
         и мы можем, к примеру, задействовать логгер в зависимости от значения этого объекта. 
         Но в данном логгер доступен всегда.*/
        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        /*Log: этот метод предназначен для выполнения логгирования. Он принимает пять параметров:
        LogLevel: уровень детализации текущего сообщения
        EventId: идентификатор события
        TState: некоторый объект состояния, который хранит сообщение
        Exception: информация об исключении
        formatter: функция форматирвания, которая с помощью двух предыдущих параметов позволяет получить 
        собственно сообщение для логгирования*/
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (this._lock)
                {
                    File.AppendAllText(this.filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
