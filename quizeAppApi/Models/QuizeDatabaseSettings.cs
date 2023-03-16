namespace quizeAppApi.Models
{
    public class QuizeDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string QuestionCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }

    }
}
