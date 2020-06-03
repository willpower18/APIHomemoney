using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHomeMoney.Models
{
    public class Receitas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NomeReceita { get; set; }
        public DateTime DtLancamento { get; set; }
        public decimal Valor { get; set; }
    }
}
