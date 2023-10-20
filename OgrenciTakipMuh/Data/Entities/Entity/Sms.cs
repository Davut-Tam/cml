using System.Collections.Generic;

namespace OgrenciTakipMuh.Data.Entities.Entity
{
    public class Sms
    {
        public List<long> Id { get; set; }
        public string[] Telefon { get; set; }
        public string Mesaj { get; set; }

    }
}