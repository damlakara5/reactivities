
namespace Domain
{
    public class Activity //class name relate to table in a database and each porperties relates to column inside the table
    {
        public Guid Id { get; set; } //getters setters available to get the value and set the value
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}