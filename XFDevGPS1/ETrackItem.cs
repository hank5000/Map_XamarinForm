using System;
using SQLite;

namespace XFDevGPS1
{
    public class ETrackItem
    {
		public static int DEFAULT_INT = -1000;
		public static double DEFAULT_DOUBLE = -1000f;
		public static float DEFAULT_FLOAT = -1000f;
		public static long DEFAULT_LONG = -1;
		public static string DEFAULT_STRING = string.Empty;
        public ETrackItem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID {get;set;}
		public long user_id { get; set; } = DEFAULT_LONG;
		public string car_id { get; set; } = DEFAULT_STRING;
		public long dt { get; set; } = DEFAULT_LONG;
		public int time_interval { get; set; } = 0;
		public int engine_load { get; set; } = DEFAULT_INT;
        public int engine_rpm { get; set; } = DEFAULT_INT;
        public int vehicle_speed { get; set; } = DEFAULT_INT;
        public int engine_start_time { get; set; } = DEFAULT_INT;
        public int temperature_engine_coolant { get; set; } = DEFAULT_INT;
        public int temperature_engine_oil { get; set; } = DEFAULT_INT;
        public int temperature_intake_air { get; set; } = DEFAULT_INT;
        public int fuel_pressure { get; set; } = DEFAULT_INT;
        public int battery_life { get; set; } = DEFAULT_INT;
		public double mileage { get; set; } = DEFAULT_DOUBLE;
        public double steering_angle { get; set; } = DEFAULT_DOUBLE;
        public double gps_longitude { get; set; } = DEFAULT_DOUBLE;
        public double gps_latitude { get; set; } = DEFAULT_DOUBLE;
        public double orientation { get; set; } = DEFAULT_DOUBLE;
        public float accelerator_pressure { get; set; } = DEFAULT_FLOAT;
        public float tire_pressure { get; set; } = DEFAULT_FLOAT;
        public float tire_temperature { get; set; } = DEFAULT_FLOAT;
        public float brakes { get; set; } = DEFAULT_FLOAT;
        public int hand_brakes { get; set; } = DEFAULT_INT;
        public int light_direction { get; set; } = DEFAULT_INT;
        public int wiper { get; set; } = DEFAULT_INT;
        public int gear_position { get; set; } = DEFAULT_INT;
        public int esp_status { get; set; } = DEFAULT_INT;
    }
}
