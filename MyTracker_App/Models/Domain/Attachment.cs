namespace MyTracker_App.Models.Domain
{
    /// <summary>
    /// Отдельное вложение в каждом сообщении; содержит путь к файлу
    /// и имя файла (сами файлы могут храниться в другом месте,
    /// например, в файловой системе сервера)
    /// </summary>
    public class Attachment : Entry
    {
        public required string Filename { get; set; }
        public required string Url { get; set; }
        public Message Message { get; set; }
    }
}
