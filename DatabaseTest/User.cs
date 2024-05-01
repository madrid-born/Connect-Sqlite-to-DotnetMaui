using SQLite;

namespace DatabaseTest ;

    [Table("USER")]
    public class User
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int id { get; set; }
        
        [Column("name")]
        public string name { get; set; }
        
        [Column("eamil")]
        public string email { get; set; }
    }