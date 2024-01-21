using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace youtube_notes_api.Entities
{
    [Table("notes")]
    public class Note
    {
        [JsonPropertyName("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        [Column("description")]
        public string Description { get; set; }

        [JsonPropertyName("title")]
        [Column("title")]
        public string Title { get; set; }

        [JsonPropertyName("userId")]
        [Column("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("url")]
        [Column("url")]
        public string Url { get; set; }

        [JsonPropertyName("content")]
        [Column("content", TypeName = "TEXT")]
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Note{{id={Id}, description='{Description}', title='{Title}', userId='{UserId}', url='{Url}', content='{Content}'}}";
        }
    }
}
