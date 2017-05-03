using System;
namespace XFDevGPS1
{
	public class EtrackJson
	{
		string template = "[{\"user_id\":26,\"car_id\":\"\",\"dt\":1493802848889," +
			"\"time_interval\":0,\"engine_load\":-1000,\"engine_rpm\":-1000," +
			"\"vehicle_speed\":0,\"engine_start_time\":-1000,\"temperature_engine_coolant\":-1000," +
			"\"temperature_engine_oil\":-1000,\"temperature_intake_air\":-1000,\"fuel_pressure\":-1000," +
			"\"battery_life\":-1000,\"mileage\":0,\"steering_angle\":-1000,\"gps_longitude\":\"120.30885380249671\"," +
			"\"gps_latitude\":\"22.657162623690088\",\"orientation\":\"0.0\",\"accelerator_pressure\":\"-1000.0\"," +
			"\"tire_pressure\":\"-1000.0\",\"tire_temperature\":\"-1000.0\",\"brakes\":\"-1000.0\",\"hand_brakes\":\"-1000\"," +
			"\"light_direction\":\"-1000\",\"wiper\":\"-1000\",\"gear_position\":\"-1000\",\"esp_status\":-1000," +
			"\"adas_event_log\":{\"laneDepatureWarning\":0,\"forwardCollisionWarning\":0,\"backwardCollisionWarning\":0," +
			"\"blindSpotDetectionWarning\":0,\"overTheSpeedLimitWarning\":0,\"sleepDetectionWarning\":0,\"carCollisionWarning\":0,\"emergencyBrakeWarning\":0}," +
			"\"event_video_file\":\"\",\"engine_start_count\":0,\"faultCode\":\"\",\"batteryVoltage\":\"-1000\",\"residualFuel\":\"-1000\"}]";

		public EtrackJson(ETrackItem item)
		{
			this.user_id = item.user_id;
			this.car_id = item.car_id;
			this.dt = item.dt;
			this.gps_latitude = item.gps_latitude;
			this.gps_longitude = item.gps_longitude;
			this.vehicle_speed = item.vehicle_speed;
			this.mileage = item.mileage;

			jsonString = "[{\"user_id\":"+user_id+",\"car_id\":\""+car_id+"\",\"dt\":"+dt+"," +
			"\"time_interval\":0,\"engine_load\":-1000,\"engine_rpm\":-1000," +
			"\"vehicle_speed\":"+vehicle_speed+",\"engine_start_time\":-1000,\"temperature_engine_coolant\":-1000," +
			"\"temperature_engine_oil\":-1000,\"temperature_intake_air\":-1000,\"fuel_pressure\":-1000," +
				"\"battery_life\":-1000,\"mileage\":"+mileage+",\"steering_angle\":-1000,\"gps_longitude\":\""+gps_longitude+"\"," +
				"\"gps_latitude\":\""+gps_latitude+"\",\"orientation\":\"0.0\",\"accelerator_pressure\":\"-1000.0\"," +
			"\"tire_pressure\":\"-1000.0\",\"tire_temperature\":\"-1000.0\",\"brakes\":\"-1000.0\",\"hand_brakes\":\"-1000\"," +
			"\"light_direction\":\"-1000\",\"wiper\":\"-1000\",\"gear_position\":\"-1000\",\"esp_status\":-1000," +
			"\"adas_event_log\":{\"laneDepatureWarning\":0,\"forwardCollisionWarning\":0,\"backwardCollisionWarning\":0," +
			"\"blindSpotDetectionWarning\":0,\"overTheSpeedLimitWarning\":0,\"sleepDetectionWarning\":0,\"carCollisionWarning\":0,\"emergencyBrakeWarning\":0}," +
			"\"event_video_file\":\"\",\"engine_start_count\":0,\"faultCode\":\"\",\"batteryVoltage\":\"-1000\",\"residualFuel\":\"-1000\"}]";
		}

		public string jsonString { set; get; } = "";


		public static int DEFAULT_INT = -1000;
		public static double DEFAULT_DOUBLE = -1000f;
		public static float DEFAULT_FLOAT = -1000f;
		public static long DEFAULT_LONG = -1;
		public static string DEFAULT_STRING = string.Empty;


		public long user_id { get; set; } = DEFAULT_LONG;
		public string car_id { get; set; } = DEFAULT_STRING;
		public long dt { get; set; } = DEFAULT_LONG; //date and time
		public int time_interval { get; set; } = 0;
		public int engine_load { get; set; } = 0;
		public int engine_rpm { get; set; } = 0;
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
		public string event_video_file { get; set; } = string.Empty;

		public int engine_start_count { get; set; } = 0;
		public string faultCode { get; set; } = string.Empty;
		public int batteryVoltage { get; set; } = -1000;
		public int residualFuel { get; set; } = -1000;
	}
}

