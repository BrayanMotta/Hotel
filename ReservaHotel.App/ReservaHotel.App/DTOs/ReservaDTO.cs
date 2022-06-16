using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaHotel.App.DTOs
{
    public class ReservaDTO
    {
        [JsonProperty("reservaID")]
        public int reservaID { get; set; }

        [JsonProperty("clienteID")]
        public int clienteID { get; set; }

        [JsonProperty("habitacionID")]
        public int habitacionID { get; set; }

        [JsonProperty("Ingreso")]
        public string Ingreso { get; set; }

        [JsonProperty("Salida")]
        public string Salida { get; set; }

        [JsonProperty("costoTotal")]
        public string costoTotal { get; set; }
    }
}
