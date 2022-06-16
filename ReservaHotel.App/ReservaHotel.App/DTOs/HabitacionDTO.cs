using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservaHotel.App.DTOs
{
    public class HabitacionDTO
    {
        [JsonProperty("habitacionID")]
        public int habitacionID { get; set; }

        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("numeroHabitacion")]
        public string numeroHabitacion { get; set; }

        [JsonProperty("costoDia")]
        public string costoDia { get; set; }

        }
}
