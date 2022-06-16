using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaHotel.App.DTOs
{
    public class ClienteDTO
    {
        [JsonProperty("clienteID")]
        public int clienteID { get; set; }

        [JsonProperty("nombreCompleto")]
        public string nombreCompleto { get; set; }

        [JsonProperty("Direccion")]
        public string Direccion { get; set; }

        [JsonProperty("Telefono")]
        public string Telefono { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
