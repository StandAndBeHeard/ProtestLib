using System;
using System.Data;
using System.Data.SqlClient;

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
            set
            {
                _id = value;
                _isIdNull = false;
            }
        }

        public System.Int32 OrganizerId
        {
            get { return _organizerId; }
            set
            {
                _organizerId = value;
                _isOrganizerIdNull = false;
            }
        }

        public System.String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                _isTitleNull = false;
            }
        }

        public System.String Url
        {
            get { return _url; }
            set
            {
                _url = value;
                _isUrlNull = false;
            }
        }

        public System.DateTime ProtestDate
        {
            get { return _protestDate; }
            set
            {
                _protestDate = value;
                _isProtestDateNull = false;
            }
        }

        public System.String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                _isDescriptionNull = false;
            }
        }

        public System.String Body
        {
            get { return _body; }
            set
            {
                _body = value;
                _isBodyNull = false;
            }
        }

        public System.String Location
        {
            get { return _location; }
            set
            {
                _location = value;
                _isLocationNull = false;
            }
        }

        public System.String Address
        {
            get { return _address; }
            set
            {
                _address = value;
                _isAddressNull = false;
            }
        }

        public System.String City
        {
            get { return _city; }
            set
            {
                _city = value;
                _isCityNull = false;
            }
        }

        public System.String State
        {
            get { return _state; }
            set
            {
                _state = value;
                _isStateNull = false;
            }
        }

        public System.String Country
        {
            get { return _country; }
            set
            {
                _country = value;
                _isCountryNull = false;
            }
        }

        public System.String Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                _isZipNull = false;
            }
        }

        public System.Double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                _isLatitudeNull = false;
            }
        }

        public System.Double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                _isLongitudeNull = false;
            }
        }

        public System.Int32 MinParticipants
        {
            get { return _minParticipants; }
            set
            {
                _minParticipants = value;
                _isMinParticipantsNull = false;
            }
        }

        public System.Int32 CurrentParticipants
        {
            get { return _currentParticipants; }
            set
            {
                _currentParticipants = value;
                _isCurrentParticipantsNull = false;
            }
        }

        public System.String Timezone
        {
            get { return _timezone; }
            set
            {
                _timezone = value;
                _isTimezoneNull = false;
            }
        }

        public System.String Website1
        {
            get { return _website1; }
            set
            {
                _website1 = value;
                _isWebsite1Null = false;
            }
        }

        public System.String Website2
        {
            get { return _website2; }
            set
            {
                _website2 = value;
                _isWebsite2Null = false;
            }
        }

        public System.String Website3
        {
            get { return _website3; }
            set
            {
                _website3 = value;
                _isWebsite3Null = false;
            }
        }

        public System.DateTime CutoffDate
        {
            get { return _cutoffDate; }
            set
            {
                _cutoffDate = value;
                _isCutoffDateNull = false;
            }
        }

        public System.String Status
        {
            get { return _status; }
            set
            {
                _status = value;
                _isStatusNull = false;
            }
        }

        public System.DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                _isCreationDateNull = false;
            }
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

        #region Constructor
        public Protest()
        {
        }
        #endregion

        #region Methods
        public static Protest LoadProtest(int protestId)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("LoadProtest", ProtestLib.Global.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Id", protestId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            return GetProtest(row);
        }

        internal static Protest GetProtest(DataRow row)
        {
            Protest result = new Protest();
            if (row.Table.Columns.Contains("Id"))
            {
                if (Convert.IsDBNull(row["Id"]))
                {
                    result._isIdNull = true;
                }
                else
                {
                    result._id = Convert.ToInt32(row["Id"]);
                    result._isIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("OrganizerId"))
            {
                if (Convert.IsDBNull(row["OrganizerId"]))
                {
                    result._isOrganizerIdNull = true;
                }
                else
                {
                    result._organizerId = Convert.ToInt32(row["OrganizerId"]);
                    result._isOrganizerIdNull = false;
                }
            }

            if (row.Table.Columns.Contains("Title"))
            {
                if (Convert.IsDBNull(row["Title"]))
                {
                    result._isTitleNull = true;
                }
                else
                {
                    result._title = Convert.ToString(row["Title"]);
                    result._isTitleNull = false;
                }
            }

            if (row.Table.Columns.Contains("Url"))
            {
                if (Convert.IsDBNull(row["Url"]))
                {
                    result._isUrlNull = true;
                }
                else
                {
                    result._url = Convert.ToString(row["Url"]);
                    result._isUrlNull = false;
                }
            }

            if (row.Table.Columns.Contains("ProtestDate"))
            {
                if (Convert.IsDBNull(row["ProtestDate"]))
                {
                    result._isProtestDateNull = true;
                }
                else
                {
                    result._protestDate = Convert.ToDateTime(row["ProtestDate"]);
                    result._isProtestDateNull = false;
                }
            }

            if (row.Table.Columns.Contains("Description"))
            {
                if (Convert.IsDBNull(row["Description"]))
                {
                    result._isDescriptionNull = true;
                }
                else
                {
                    result._description = Convert.ToString(row["Description"]);
                    result._isDescriptionNull = false;
                }
            }

            if (row.Table.Columns.Contains("Body"))
            {
                if (Convert.IsDBNull(row["Body"]))
                {
                    result._isBodyNull = true;
                }
                else
                {
                    result._body = Convert.ToString(row["Body"]);
                    result._isBodyNull = false;
                }
            }

            if (row.Table.Columns.Contains("Location"))
            {
                if (Convert.IsDBNull(row["Location"]))
                {
                    result._isLocationNull = true;
                }
                else
                {
                    result._location = Convert.ToString(row["Location"]);
                    result._isLocationNull = false;
                }
            }

            if (row.Table.Columns.Contains("Address"))
            {
                if (Convert.IsDBNull(row["Address"]))
                {
                    result._isAddressNull = true;
                }
                else
                {
                    result._address = Convert.ToString(row["Address"]);
                    result._isAddressNull = false;
                }
            }

            if (row.Table.Columns.Contains("City"))
            {
                if (Convert.IsDBNull(row["City"]))
                {
                    result._isCityNull = true;
                }
                else
                {
                    result._city = Convert.ToString(row["City"]);
                    result._isCityNull = false;
                }
            }

            if (row.Table.Columns.Contains("State"))
            {
                if (Convert.IsDBNull(row["State"]))
                {
                    result._isStateNull = true;
                }
                else
                {
                    result._state = Convert.ToString(row["State"]);
                    result._isStateNull = false;
                }
            }

            if (row.Table.Columns.Contains("Country"))
            {
                if (Convert.IsDBNull(row["Country"]))
                {
                    result._isCountryNull = true;
                }
                else
                {
                    result._country = Convert.ToString(row["Country"]);
                    result._isCountryNull = false;
                }
            }

            if (row.Table.Columns.Contains("Zip"))
            {
                if (Convert.IsDBNull(row["Zip"]))
                {
                    result._isZipNull = true;
                }
                else
                {
                    result._zip = Convert.ToString(row["Zip"]);
                    result._isZipNull = false;
                }
            }

            if (row.Table.Columns.Contains("Latitude"))
            {
                if (Convert.IsDBNull(row["Latitude"]))
                {
                    result._isLatitudeNull = true;
                }
                else
                {
                    result._latitude = Convert.ToDouble(row["Latitude"]);
                    result._isLatitudeNull = false;
                }
            }

            if (row.Table.Columns.Contains("Longitude"))
            {
                if (Convert.IsDBNull(row["Longitude"]))
                {
                    result._isLongitudeNull = true;
                }
                else
                {
                    result._longitude = Convert.ToDouble(row["Longitude"]);
                    result._isLongitudeNull = false;
                }
            }

            if (row.Table.Columns.Contains("MinParticipants"))
            {
                if (Convert.IsDBNull(row["MinParticipants"]))
                {
                    result._isMinParticipantsNull = true;
                }
                else
                {
                    result._minParticipants = Convert.ToInt32(row["MinParticipants"]);
                    result._isMinParticipantsNull = false;
                }
            }

            if (row.Table.Columns.Contains("CurrentParticipants"))
            {
                if (Convert.IsDBNull(row["CurrentParticipants"]))
                {
                    result._isCurrentParticipantsNull = true;
                }
                else
                {
                    result._currentParticipants = Convert.ToInt32(row["CurrentParticipants"]);
                    result._isCurrentParticipantsNull = false;
                }
            }

            if (row.Table.Columns.Contains("Timezone"))
            {
                if (Convert.IsDBNull(row["Timezone"]))
                {
                    result._isTimezoneNull = true;
                }
                else
                {
                    result._timezone = Convert.ToString(row["Timezone"]);
                    result._isTimezoneNull = false;
                }
            }

            if (row.Table.Columns.Contains("Website1"))
            {
                if (Convert.IsDBNull(row["Website1"]))
                {
                    result._isWebsite1Null = true;
                }
                else
                {
                    result._website1 = Convert.ToString(row["Website1"]);
                    result._isWebsite1Null = false;
                }
            }

            if (row.Table.Columns.Contains("Website2"))
            {
                if (Convert.IsDBNull(row["Website2"]))
                {
                    result._isWebsite2Null = true;
                }
                else
                {
                    result._website2 = Convert.ToString(row["Website2"]);
                    result._isWebsite2Null = false;
                }
            }

            if (row.Table.Columns.Contains("Website3"))
            {
                if (Convert.IsDBNull(row["Website3"]))
                {
                    result._isWebsite3Null = true;
                }
                else
                {
                    result._website3 = Convert.ToString(row["Website3"]);
                    result._isWebsite3Null = false;
                }
            }

            if (row.Table.Columns.Contains("CutoffDate"))
            {
                if (Convert.IsDBNull(row["CutoffDate"]))
                {
                    result._isCutoffDateNull = true;
                }
                else
                {
                    result._cutoffDate = Convert.ToDateTime(row["CutoffDate"]);
                    result._isCutoffDateNull = false;
                }
            }

            if (row.Table.Columns.Contains("Status"))
            {
                if (Convert.IsDBNull(row["Status"]))
                {
                    result._isStatusNull = true;
                }
                else
                {
                    result._status = Convert.ToString(row["Status"]);
                    result._isStatusNull = false;
                }
            }

            if (row.Table.Columns.Contains("CreationDate"))
            {
                if (Convert.IsDBNull(row["CreationDate"]))
                {
                    result._isCreationDateNull = true;
                }
                else
                {
                    result._creationDate = Convert.ToDateTime(row["CreationDate"]);
                    result._isCreationDateNull = false;
                }
            }

            return result;
        }

        public static SqlCommand GetSaveCommand(Protest protest, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SaveProtest", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (protest._isIdNull)
            {
                cmd.Parameters.AddWithValue("@Id", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", protest._id);
            }

            if (protest._isOrganizerIdNull)
            {
                cmd.Parameters.AddWithValue("@OrganizerId", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@OrganizerId", protest._organizerId);
            }

            if (protest._isTitleNull)
            {
                cmd.Parameters.AddWithValue("@Title", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Title", protest._title);
            }

            if (protest._isUrlNull)
            {
                cmd.Parameters.AddWithValue("@Url", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Url", protest._url);
            }

            if (protest._isProtestDateNull)
            {
                cmd.Parameters.AddWithValue("@ProtestDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ProtestDate", protest._protestDate);
            }

            if (protest._isDescriptionNull)
            {
                cmd.Parameters.AddWithValue("@Description", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Description", protest._description);
            }

            if (protest._isBodyNull)
            {
                cmd.Parameters.AddWithValue("@Body", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Body", protest._body);
            }

            if (protest._isLocationNull)
            {
                cmd.Parameters.AddWithValue("@Location", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Location", protest._location);
            }

            if (protest._isAddressNull)
            {
                cmd.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Address", protest._address);
            }

            if (protest._isCityNull)
            {
                cmd.Parameters.AddWithValue("@City", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@City", protest._city);
            }

            if (protest._isStateNull)
            {
                cmd.Parameters.AddWithValue("@State", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@State", protest._state);
            }

            if (protest._isCountryNull)
            {
                cmd.Parameters.AddWithValue("@Country", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Country", protest._country);
            }

            if (protest._isZipNull)
            {
                cmd.Parameters.AddWithValue("@Zip", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Zip", protest._zip);
            }

            if (protest._isLatitudeNull)
            {
                cmd.Parameters.AddWithValue("@Latitude", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Latitude", protest._latitude);
            }

            if (protest._isLongitudeNull)
            {
                cmd.Parameters.AddWithValue("@Longitude", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Longitude", protest._longitude);
            }

            if (protest._isMinParticipantsNull)
            {
                cmd.Parameters.AddWithValue("@MinParticipants", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MinParticipants", protest._minParticipants);
            }

            if (protest._isCurrentParticipantsNull)
            {
                cmd.Parameters.AddWithValue("@CurrentParticipants", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CurrentParticipants", protest._currentParticipants);
            }

            if (protest._isTimezoneNull)
            {
                cmd.Parameters.AddWithValue("@Timezone", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Timezone", protest._timezone);
            }

            if (protest._isWebsite1Null)
            {
                cmd.Parameters.AddWithValue("@Website1", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Website1", protest._website1);
            }

            if (protest._isWebsite2Null)
            {
                cmd.Parameters.AddWithValue("@Website2", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Website2", protest._website2);
            }

            if (protest._isWebsite3Null)
            {
                cmd.Parameters.AddWithValue("@Website3", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Website3", protest._website3);
            }

            if (protest._isCutoffDateNull)
            {
                cmd.Parameters.AddWithValue("@CutoffDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CutoffDate", protest._cutoffDate);
            }

            if (protest._isStatusNull)
            {
                cmd.Parameters.AddWithValue("@Status", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", protest._status);
            }

            if (protest._isCreationDateNull)
            {
                cmd.Parameters.AddWithValue("@CreationDate", System.DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CreationDate", protest._creationDate);
            }

            return cmd;
        }

        public static int SaveProtest(Protest protest)
        {
            int result = 0;
            SqlCommand cmd = GetSaveCommand(protest, ProtestLib.Global.Connection);
            cmd.Connection.Open();
            try
            {
                Utils.SetContextInfo(cmd.Connection);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            protest.Id = result;
            return result;
        }
        public int Save()
        {
            return Protest.SaveProtest(this);
        }

        public static void DeleteProtest(int protestId)
        {
            SqlCommand cmd = new SqlCommand("DeleteProtest", ProtestLib.Global.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", protestId);
            cmd.Connection.Open();
            try
            {
                Utils.SetContextInfo(cmd.Connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public object GetPropertyValue(string propertyName)
        {
            return Utils.GetPropertyValue<Protest>(this, propertyName);
        }

        #endregion

    }
}




