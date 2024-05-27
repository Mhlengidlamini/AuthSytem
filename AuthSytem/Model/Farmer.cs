using System.ComponentModel.DataAnnotations;

namespace AuthSytem.Model
{
    public class Farmer
    {
        [Key]
        public int farmer_id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string contact_number { get; set; }
    }
}
