
namespace WhiskyClub.Core.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int WhiskyId { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public string Comment { get; set; }
        public string ImageUri { get; set; }

        public Whisky Whisky { get; set; }
        public Event Event { get; set; }
        public Member Member { get; set; }
    }
}