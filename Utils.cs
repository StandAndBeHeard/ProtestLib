using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ProtestLib
{
    public class Utils
    {
        internal static Regex stopWords = null;

        #region AutoGen Methods
        public static object GetPropertyValue<t>(t obj, string propertyName)
        {
            var type = typeof(t);
            var prop = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return prop.GetValue(obj, null);
        }

        public static DataTable FillDt(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Global.Connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable ExecuteQuery(string sql, System.Data.CommandType commandType, SqlParameter[] parameters)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Global.Connection);
            adapter.SelectCommand.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters) adapter.SelectCommand.Parameters.Add(parameter);
            }
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static Object ExecuteScalar(string sql, System.Data.CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            SqlCommand cmd = new SqlCommand(sql, Global.Connection);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters) cmd.Parameters.Add(parameter);
            }
            try
            {
                cmd.Connection.Open();
                result = cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
            return result;
        }

        public static void SetContextInfo(SqlConnection con)
        {
        }
        #endregion

        public static void SendEmail(System.Net.Mail.MailMessage msg)
        {
            string awsKey = System.Configuration.ConfigurationManager.AppSettings["AwsKey"];
            string awsSecret = System.Configuration.ConfigurationManager.AppSettings["AwsSecret"];

            System.Threading.Thread.Sleep(200); //Throttle to 5 emails per second
            Amazon.SimpleEmail.AmazonSimpleEmailServiceClient client = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(awsKey, awsSecret);

            List<string> toAddresses = new List<string>();
            foreach (System.Net.Mail.MailAddress oneToAddr in msg.To) toAddresses.Add(oneToAddr.Address);

            Amazon.SimpleEmail.Model.SendEmailRequest req = new Amazon.SimpleEmail.Model.SendEmailRequest()
                .WithDestination(new Amazon.SimpleEmail.Model.Destination() { ToAddresses = toAddresses })
                .WithSource(msg.From.DisplayName + " <" + msg.From.Address + ">")
                .WithReturnPath(msg.From.DisplayName + " <" + msg.From.Address + ">")
                .WithMessage(
                    new Amazon.SimpleEmail.Model.Message(
                        new Amazon.SimpleEmail.Model.Content(msg.Subject),
                        new Amazon.SimpleEmail.Model.Body().WithHtml(new Amazon.SimpleEmail.Model.Content(msg.Body))
                    )
                );
            Amazon.SimpleEmail.Model.SendEmailResponse resp = client.SendEmail(req);
        }
        

        public static string RemoveHtml(string html)
        {
            return Regex.Replace(html, "<.*?>", string.Empty);
        }

        public static string HashAndSalt(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("An empty string value cannot be hashed.");
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(s + System.Configuration.ConfigurationManager.AppSettings["Salt"]);
            Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

        public static string GetUrlContents(string url)
        {
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            req.CookieContainer = new System.Net.CookieContainer();
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string result = sr.ReadToEnd();
            return result;
        }

        public static string GenerateUrl(string name, bool removeStopWords = true)
        {
            string result = "";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[0-9a-z ]");
            foreach (char c in name.ToLower().ToCharArray())
            {
                if (regex.Match(c.ToString()).Success) result += c.ToString();
            }

            if (removeStopWords)
            {
                string newResult = RemoveStopWords(result);
                if (newResult.Length > 5) result = newResult;
            }

            result = result.Replace(" ", "-");
            while (result.Contains("--")) result = result.Replace("--", "-");
            if (result.StartsWith("-")) result = result.Substring(1, result.Length - 1);
            if (result.EndsWith("-")) result = result.Substring(0, result.Length - 1);
            return result + ".html";
        }

        public static string RemoveStopWords(string text)
        {
            if (stopWords == null) stopWords = new Regex(@"\b(a|able|about|above|abst|accordance|according|accordingly|across|act|actually|added|adj|affected|affecting|affects|after|afterwards|again|against|ah|all|almost|alone|along|already|also|although|always|am|among|amongst|an|and|announce|another|any|anybody|anyhow|anymore|anyone|anything|anyway|anyways|anywhere|apparently|approximately|are|aren|arent|arise|around|as|aside|ask|asking|at|auth|available|away|awfully|b|back|be|became|because|become|becomes|becoming|been|before|beforehand|begin|beginning|beginnings|begins|behind|being|believe|below|beside|besides|between|beyond|biol|both|brief|briefly|but|by|c|ca|came|can|cannot|cant|cause|causes|certain|certainly|co|com|come|comes|contain|containing|contains|could|couldnt|d|date|did|didnt|different|do|does|doesnt|doing|done|dont|down|downwards|due|during|e|each|ed|edu|effect|eg|eight|eighty|either|else|elsewhere|end|ending|enough|especially|et|et-al|etc|even|ever|every|everybody|everyone|everything|everywhere|ex|except|f|far|few|ff|fifth|first|five|fix|followed|following|follows|for|former|formerly|forth|found|four|from|further|furthermore|g|gave|get|gets|getting|give|given|gives|giving|go|goes|gone|got|gotten|h|had|happens|hardly|has|hasnt|have|havent|having|he|hed|hence|her|here|hereafter|hereby|herein|heres|hereupon|hers|herself|hes|hi|hid|him|himself|his|hither|home|how|howbeit|however|hundred|i|id|ie|if|ill|im|immediate|immediately|importance|important|in|inc|indeed|index|information|instead|into|invention|inward|is|isnt|it|itd|itll|its|itself|ive|j|just|k|keep|kept|kg|km|know|known|knows|l|largely|last|lately|later|latter|latterly|least|less|lest|let|lets|like|liked|likely|line|little|ll|look|looking|looks|ltd|m|made|mainly|make|makes|many|maybe|me|mean|means|meantime|meanwhile|merely|mg|might|million|miss|ml|more|moreover|most|mostly|mr|mrs|much|mug|must|my|myself|n|na|name|namely|nay|nd|near|nearly|necessarily|necessary|need|needs|neither|never|nevertheless|new|next|nine|ninety|no|nobody|non|none|nonetheless|noone|nor|normally|nos|not|noted|nothing|now|nowhere|o|obtain|obtained|obviously|of|off|often|oh|ok|okay|old|omitted|on|once|one|ones|only|onto|or|ord|other|others|otherwise|ought|our|ours|ourselves|out|outside|over|overall|owing|own|p|page|pages|part|particular|particularly|past|per|perhaps|placed|please|plus|poorly|possible|possibly|potentially|pp|predominantly|present|previously|primarily|probably|promptly|proud|provides|put|q|que|quickly|quite|qv|r|ran|rather|rd|re|readily|really|recent|recently|ref|refs|regarding|regardless|regards|related|relatively|research|respectively|resulted|resulting|results|right|run|s|said|same|saw|say|saying|says|sec|section|see|seeing|seem|seemed|seeming|seems|seen|self|selves|sent|seven|several|shall|she|shed|shell|shes|should|shouldnt|show|showed|shown|showns|shows|significant|significantly|similar|similarly|since|six|slightly|so|some|somebody|somehow|someone|somethan|something|sometime|sometimes|somewhat|somewhere|soon|sorry|specifically|specified|specify|specifying|still|stop|strongly|sub|substantially|successfully|such|sufficiently|suggest|sup|sure|t|take|taken|tell|tends|th|than|thank|thanks|thanx|that|that|thats|the|their|theirs|them|themselves|then|thence|there|there|thereafter|thereby|therefore|therein|theres|thereupon|these|they|they'd|they'll|they're|they've|think|third|this|thorough|thoroughly|those|though|three|through|throughout|thru|thus|to|together|too|took|toward|towards|tried|tries|truly|try|trying|twice|two|un|under|unfortunately|unless|unlikely|until|unto|up|upon|us|use|used|useful|uses|using|usually|value|various|very|via|viz|vs|want|wants|was|wasn't|way|we|we'd|we'll|we're|we've|welcome|well|went|were|weren't|what|what|whatever|when|whence|whenever|where|where|whereafter|whereas|whereby|wherein|whereupon|wherever|whether|which|while|whither|who|who|whoever|whole|whom|whose|why|will|willing|wish|with|within|without|won't|wonder|would|wouldn't|yes|yet|you|you'd|you'll|you're|you've|your|yours|yourself|yourselves|zero)\b", RegexOptions.IgnoreCase);
            return stopWords.Replace(text, "");
        }

        public static TimeZoneInfo GetTimezone(string id)
        {
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.Id == id) return timeZone;
            }
            return null;
        }

        public static DateTime GetLocalTime(DateTime utcTime, string timezone)
        {
            TimeZoneInfo tz = ProtestLib.Utils.GetTimezone(timezone);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, tz);
        }

        public static string GetOrdinalName(int num)
        {
            string suffix = "";
            if (num >= 11 && num <= 13) suffix = "th";
            else if (num % 10 == 1) suffix = "st";
            else if (num % 10 == 2) suffix = "nd";
            else if (num % 10 == 3) suffix = "rd";
            else suffix = "th";
            return num.ToString() + suffix;
        }


    }
}
