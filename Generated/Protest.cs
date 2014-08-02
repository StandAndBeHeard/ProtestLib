

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ProtestLib
{
	[Serializable]
	public partial class Protest
	{
		#region Declarations
		System.Int32 _id;
		System.Int32 _organizerId;
		System.String _title;
		System.String _url;
		System.DateTime _protestDate;
		System.String _description;
		System.String _body;
		System.String _location;
		System.String _address;
		System.String _city;
		System.String _state;
		System.String _country;
		System.String _zip;
		System.Double _latitude;
		System.Double _longitude;
		System.Int32 _minParticipants;
		System.Int32 _currentParticipants;
		System.String _timezone;
		System.String _website1;
		System.String _website2;
		System.String _website3;
		System.DateTime _cutoffDate;
		System.String _status;
		System.DateTime _creationDate;

		bool _isIdNull = true;
		bool _isOrganizerIdNull = true;
		bool _isTitleNull = true;
		bool _isUrlNull = true;
		bool _isProtestDateNull = true;
		bool _isDescriptionNull = true;
		bool _isBodyNull = true;
		bool _isLocationNull = true;
		bool _isAddressNull = true;
		bool _isCityNull = true;
		bool _isStateNull = true;
		bool _isCountryNull = true;
		bool _isZipNull = true;
		bool _isLatitudeNull = true;
		bool _isLongitudeNull = true;
		bool _isMinParticipantsNull = true;
		bool _isCurrentParticipantsNull = true;
		bool _isTimezoneNull = true;
		bool _isWebsite1Null = true;
		bool _isWebsite2Null = true;
		bool _isWebsite3Null = true;
		bool _isCutoffDateNull = true;
		bool _isStatusNull = true;
		bool _isCreationDateNull = true;
		#endregion

		#region Properties
		public System.Int32 Id
		{
			get { return _id; }
			set { _id = value; _isIdNull = false; }
		}
		public System.Int32 OrganizerId
		{
			get { return _organizerId; }
			set { _organizerId = value; _isOrganizerIdNull = false; }
		}
		public System.String Title
		{
			get { return _title; }
			set { _title = value; _isTitleNull = false; }
		}
		public System.String Url
		{
			get { return _url; }
			set { _url = value; _isUrlNull = false; }
		}
		public System.DateTime ProtestDate
		{
			get { return _protestDate; }
			set { _protestDate = value; _isProtestDateNull = false; }
		}
		public System.String Description
		{
			get { return _description; }
			set { _description = value; _isDescriptionNull = false; }
		}
		public System.String Body
		{
			get { return _body; }
			set { _body = value; _isBodyNull = false; }
		}
		public System.String Location
		{
			get { return _location; }
			set { _location = value; _isLocationNull = false; }
		}
		public System.String Address
		{
			get { return _address; }
			set { _address = value; _isAddressNull = false; }
		}
		public System.String City
		{
			get { return _city; }
			set { _city = value; _isCityNull = false; }
		}
		public System.String State
		{
			get { return _state; }
			set { _state = value; _isStateNull = false; }
		}
		public System.String Country
		{
			get { return _country; }
			set { _country = value; _isCountryNull = false; }
		}
		public System.String Zip
		{
			get { return _zip; }
			set { _zip = value; _isZipNull = false; }
		}
		public System.Double Latitude
		{
			get { return _latitude; }
			set { _latitude = value; _isLatitudeNull = false; }
		}
		public System.Double Longitude
		{
			get { return _longitude; }
			set { _longitude = value; _isLongitudeNull = false; }
		}
		public System.Int32 MinParticipants
		{
			get { return _minParticipants; }
			set { _minParticipants = value; _isMinParticipantsNull = false; }
		}
		public System.Int32 CurrentParticipants
		{
			get { return _currentParticipants; }
			set { _currentParticipants = value; _isCurrentParticipantsNull = false; }
		}
		public System.String Timezone
		{
			get { return _timezone; }
			set { _timezone = value; _isTimezoneNull = false; }
		}
		public System.String Website1
		{
			get { return _website1; }
			set { _website1 = value; _isWebsite1Null = false; }
		}
		public System.String Website2
		{
			get { return _website2; }
			set { _website2 = value; _isWebsite2Null = false; }
		}
		public System.String Website3
		{
			get { return _website3; }
			set { _website3 = value; _isWebsite3Null = false; }
		}
		public System.DateTime CutoffDate
		{
			get { return _cutoffDate; }
			set { _cutoffDate = value; _isCutoffDateNull = false; }
		}
		public System.String Status
		{
			get { return _status; }
			set { _status = value; _isStatusNull = false; }
		}
		public System.DateTime CreationDate
		{
			get { return _creationDate; }
			set { _creationDate = value; _isCreationDateNull = false; }
		}
		public bool IsIdNull
		{
			get { return _isIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isIdNull = value;
				_id = -1;
			}
		}
		public bool IsOrganizerIdNull
		{
			get { return _isOrganizerIdNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isOrganizerIdNull = value;
				_organizerId = -1;
			}
		}
		public bool IsTitleNull
		{
			get { return _isTitleNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isTitleNull = value;
				_title = System.String.Empty;
			}
		}
		public bool IsUrlNull
		{
			get { return _isUrlNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isUrlNull = value;
				_url = System.String.Empty;
			}
		}
		public bool IsProtestDateNull
		{
			get { return _isProtestDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isProtestDateNull = value;
				_protestDate = DateTime.MinValue;
			}
		}
		public bool IsDescriptionNull
		{
			get { return _isDescriptionNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isDescriptionNull = value;
				_description = System.String.Empty;
			}
		}
		public bool IsBodyNull
		{
			get { return _isBodyNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isBodyNull = value;
				_body = System.String.Empty;
			}
		}
		public bool IsLocationNull
		{
			get { return _isLocationNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isLocationNull = value;
				_location = System.String.Empty;
			}
		}
		public bool IsAddressNull
		{
			get { return _isAddressNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isAddressNull = value;
				_address = System.String.Empty;
			}
		}
		public bool IsCityNull
		{
			get { return _isCityNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isCityNull = value;
				_city = System.String.Empty;
			}
		}
		public bool IsStateNull
		{
			get { return _isStateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isStateNull = value;
				_state = System.String.Empty;
			}
		}
		public bool IsCountryNull
		{
			get { return _isCountryNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isCountryNull = value;
				_country = System.String.Empty;
			}
		}
		public bool IsZipNull
		{
			get { return _isZipNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isZipNull = value;
				_zip = System.String.Empty;
			}
		}
		public bool IsLatitudeNull
		{
			get { return _isLatitudeNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isLatitudeNull = value;
				_latitude = -1;
			}
		}
		public bool IsLongitudeNull
		{
			get { return _isLongitudeNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isLongitudeNull = value;
				_longitude = -1;
			}
		}
		public bool IsMinParticipantsNull
		{
			get { return _isMinParticipantsNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isMinParticipantsNull = value;
				_minParticipants = -1;
			}
		}
		public bool IsCurrentParticipantsNull
		{
			get { return _isCurrentParticipantsNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isCurrentParticipantsNull = value;
				_currentParticipants = -1;
			}
		}
		public bool IsTimezoneNull
		{
			get { return _isTimezoneNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isTimezoneNull = value;
				_timezone = System.String.Empty;
			}
		}
		public bool IsWebsite1Null
		{
			get { return _isWebsite1Null; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isWebsite1Null = value;
				_website1 = System.String.Empty;
			}
		}
		public bool IsWebsite2Null
		{
			get { return _isWebsite2Null; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isWebsite2Null = value;
				_website2 = System.String.Empty;
			}
		}
		public bool IsWebsite3Null
		{
			get { return _isWebsite3Null; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isWebsite3Null = value;
				_website3 = System.String.Empty;
			}
		}
		public bool IsCutoffDateNull
		{
			get { return _isCutoffDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isCutoffDateNull = value;
				_cutoffDate = DateTime.MinValue;
			}
		}
		public bool IsStatusNull
		{
			get { return _isStatusNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isStatusNull = value;
				_status = System.String.Empty;
			}
		}
		public bool IsCreationDateNull
		{
			get { return _isCreationDateNull; }
			set
			{
				if (!value) throw new Exception("Can not set this property to false");
				_isCreationDateNull = value;
				_creationDate = DateTime.MinValue;
			}
		}
		#endregion

		#region Constructors
		public Protest()
		{
		}

		public Protest(DataRow row)
		{
			if (row.Table.Columns.Contains("Id"))
			{
				if (Convert.IsDBNull(row["Id"])) this.IsIdNull = true;
				else this.Id = Convert.ToInt32(row["Id"]);
			}
			if (row.Table.Columns.Contains("OrganizerId"))
			{
				if (Convert.IsDBNull(row["OrganizerId"])) this.IsOrganizerIdNull = true;
				else this.OrganizerId = Convert.ToInt32(row["OrganizerId"]);
			}
			if (row.Table.Columns.Contains("Title"))
			{
				if (Convert.IsDBNull(row["Title"])) this.IsTitleNull = true;
				else this.Title = Convert.ToString(row["Title"]);
			}
			if (row.Table.Columns.Contains("Url"))
			{
				if (Convert.IsDBNull(row["Url"])) this.IsUrlNull = true;
				else this.Url = Convert.ToString(row["Url"]);
			}
			if (row.Table.Columns.Contains("ProtestDate"))
			{
				if (Convert.IsDBNull(row["ProtestDate"])) this.IsProtestDateNull = true;
				else this.ProtestDate = Convert.ToDateTime(row["ProtestDate"]);
			}
			if (row.Table.Columns.Contains("Description"))
			{
				if (Convert.IsDBNull(row["Description"])) this.IsDescriptionNull = true;
				else this.Description = Convert.ToString(row["Description"]);
			}
			if (row.Table.Columns.Contains("Body"))
			{
				if (Convert.IsDBNull(row["Body"])) this.IsBodyNull = true;
				else this.Body = Convert.ToString(row["Body"]);
			}
			if (row.Table.Columns.Contains("Location"))
			{
				if (Convert.IsDBNull(row["Location"])) this.IsLocationNull = true;
				else this.Location = Convert.ToString(row["Location"]);
			}
			if (row.Table.Columns.Contains("Address"))
			{
				if (Convert.IsDBNull(row["Address"])) this.IsAddressNull = true;
				else this.Address = Convert.ToString(row["Address"]);
			}
			if (row.Table.Columns.Contains("City"))
			{
				if (Convert.IsDBNull(row["City"])) this.IsCityNull = true;
				else this.City = Convert.ToString(row["City"]);
			}
			if (row.Table.Columns.Contains("State"))
			{
				if (Convert.IsDBNull(row["State"])) this.IsStateNull = true;
				else this.State = Convert.ToString(row["State"]);
			}
			if (row.Table.Columns.Contains("Country"))
			{
				if (Convert.IsDBNull(row["Country"])) this.IsCountryNull = true;
				else this.Country = Convert.ToString(row["Country"]);
			}
			if (row.Table.Columns.Contains("Zip"))
			{
				if (Convert.IsDBNull(row["Zip"])) this.IsZipNull = true;
				else this.Zip = Convert.ToString(row["Zip"]);
			}
			if (row.Table.Columns.Contains("Latitude"))
			{
				if (Convert.IsDBNull(row["Latitude"])) this.IsLatitudeNull = true;
				else this.Latitude = Convert.ToDouble(row["Latitude"]);
			}
			if (row.Table.Columns.Contains("Longitude"))
			{
				if (Convert.IsDBNull(row["Longitude"])) this.IsLongitudeNull = true;
				else this.Longitude = Convert.ToDouble(row["Longitude"]);
			}
			if (row.Table.Columns.Contains("MinParticipants"))
			{
				if (Convert.IsDBNull(row["MinParticipants"])) this.IsMinParticipantsNull = true;
				else this.MinParticipants = Convert.ToInt32(row["MinParticipants"]);
			}
			if (row.Table.Columns.Contains("CurrentParticipants"))
			{
				if (Convert.IsDBNull(row["CurrentParticipants"])) this.IsCurrentParticipantsNull = true;
				else this.CurrentParticipants = Convert.ToInt32(row["CurrentParticipants"]);
			}
			if (row.Table.Columns.Contains("Timezone"))
			{
				if (Convert.IsDBNull(row["Timezone"])) this.IsTimezoneNull = true;
				else this.Timezone = Convert.ToString(row["Timezone"]);
			}
			if (row.Table.Columns.Contains("Website1"))
			{
				if (Convert.IsDBNull(row["Website1"])) this.IsWebsite1Null = true;
				else this.Website1 = Convert.ToString(row["Website1"]);
			}
			if (row.Table.Columns.Contains("Website2"))
			{
				if (Convert.IsDBNull(row["Website2"])) this.IsWebsite2Null = true;
				else this.Website2 = Convert.ToString(row["Website2"]);
			}
			if (row.Table.Columns.Contains("Website3"))
			{
				if (Convert.IsDBNull(row["Website3"])) this.IsWebsite3Null = true;
				else this.Website3 = Convert.ToString(row["Website3"]);
			}
			if (row.Table.Columns.Contains("CutoffDate"))
			{
				if (Convert.IsDBNull(row["CutoffDate"])) this.IsCutoffDateNull = true;
				else this.CutoffDate = Convert.ToDateTime(row["CutoffDate"]);
			}
			if (row.Table.Columns.Contains("Status"))
			{
				if (Convert.IsDBNull(row["Status"])) this.IsStatusNull = true;
				else this.Status = Convert.ToString(row["Status"]);
			}
			if (row.Table.Columns.Contains("CreationDate"))
			{
				if (Convert.IsDBNull(row["CreationDate"])) this.IsCreationDateNull = true;
				else this.CreationDate = Convert.ToDateTime(row["CreationDate"]);
			}
		}
		#endregion

		#region Methods
		public static Protest Load(string sql, CommandType commandType = CommandType.Text, SqlParameter[] parameters = null)
		{
			Protests protests = Protests.Load(sql, commandType, parameters);
			return (protests.Count == 0) ? null : protests[0];
		}

		public static Protest Load(int id)
		{
			return Load("LoadProtest", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		internal SqlCommand GetSaveCommand(SqlConnection conn)
		{
			SqlCommand cmd = new SqlCommand("SaveProtest", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@Id", (_isIdNull) ? System.DBNull.Value : (object)_id);
			cmd.Parameters.AddWithValue("@OrganizerId", (_isOrganizerIdNull) ? System.DBNull.Value : (object)_organizerId);
			cmd.Parameters.AddWithValue("@Title", (_isTitleNull) ? System.DBNull.Value : (object)_title);
			cmd.Parameters.AddWithValue("@Url", (_isUrlNull) ? System.DBNull.Value : (object)_url);
			cmd.Parameters.AddWithValue("@ProtestDate", (_isProtestDateNull) ? System.DBNull.Value : (object)_protestDate);
			cmd.Parameters.AddWithValue("@Description", (_isDescriptionNull) ? System.DBNull.Value : (object)_description);
			cmd.Parameters.AddWithValue("@Body", (_isBodyNull) ? System.DBNull.Value : (object)_body);
			cmd.Parameters.AddWithValue("@Location", (_isLocationNull) ? System.DBNull.Value : (object)_location);
			cmd.Parameters.AddWithValue("@Address", (_isAddressNull) ? System.DBNull.Value : (object)_address);
			cmd.Parameters.AddWithValue("@City", (_isCityNull) ? System.DBNull.Value : (object)_city);
			cmd.Parameters.AddWithValue("@State", (_isStateNull) ? System.DBNull.Value : (object)_state);
			cmd.Parameters.AddWithValue("@Country", (_isCountryNull) ? System.DBNull.Value : (object)_country);
			cmd.Parameters.AddWithValue("@Zip", (_isZipNull) ? System.DBNull.Value : (object)_zip);
			cmd.Parameters.AddWithValue("@Latitude", (_isLatitudeNull) ? System.DBNull.Value : (object)_latitude);
			cmd.Parameters.AddWithValue("@Longitude", (_isLongitudeNull) ? System.DBNull.Value : (object)_longitude);
			cmd.Parameters.AddWithValue("@MinParticipants", (_isMinParticipantsNull) ? System.DBNull.Value : (object)_minParticipants);
			cmd.Parameters.AddWithValue("@CurrentParticipants", (_isCurrentParticipantsNull) ? System.DBNull.Value : (object)_currentParticipants);
			cmd.Parameters.AddWithValue("@Timezone", (_isTimezoneNull) ? System.DBNull.Value : (object)_timezone);
			cmd.Parameters.AddWithValue("@Website1", (_isWebsite1Null) ? System.DBNull.Value : (object)_website1);
			cmd.Parameters.AddWithValue("@Website2", (_isWebsite2Null) ? System.DBNull.Value : (object)_website2);
			cmd.Parameters.AddWithValue("@Website3", (_isWebsite3Null) ? System.DBNull.Value : (object)_website3);
			cmd.Parameters.AddWithValue("@CutoffDate", (_isCutoffDateNull) ? System.DBNull.Value : (object)_cutoffDate);
			cmd.Parameters.AddWithValue("@Status", (_isStatusNull) ? System.DBNull.Value : (object)_status);
			cmd.Parameters.AddWithValue("@CreationDate", (_isCreationDateNull) ? System.DBNull.Value : (object)_creationDate);
			return cmd;
		}

		public int Save()
		{
			SqlCommand cmd = GetSaveCommand(DBHelper.Connection);
			cmd.Connection.Open();
			try
			{
				DBHelper.SetContextInfo(cmd.Connection);
				Id = Convert.ToInt32(cmd.ExecuteScalar());
			}
			catch (Exception ex) { throw ex; }
			finally { cmd.Connection.Close(); }
			return Id;
		}

		public static void Delete(int id)
		{
			DBHelper.ExecuteNonQuery("DeleteProtest", CommandType.StoredProcedure, new SqlParameter[] { new SqlParameter("@Id", id) });
		}

		public object GetPropertyValue(string propertyName)
		{
			return typeof(Protest).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this, null);
		}
		#endregion
	}
}
