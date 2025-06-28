namespace MyTracker_App.Models.Domain
{
    /// <summary>
    /// Абстрактный класс для всех классов моделей в БД; содержит основные
    /// поля (уникальный идентификатор, дата и время создания, обновления,
    /// удаления)
    /// </summary>
    public abstract class Entry
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
