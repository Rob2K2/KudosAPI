using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudosAPI.Models
{
    public class Kudos
    {
        [BsonId]
        public ObjectId KudosID { get; set; }

        public string Fuente { get; set; }

        public string Destino { get; set; }

        public string Tema { get; set; }

        public string Fecha { get; set; }

        public string Lugar { get; set; }

        public string Texto { get; set; }
    }
}
