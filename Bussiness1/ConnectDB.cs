using System.Data.SqlClient;
using static Model.Class1;

namespace Bussiness1
{
    public class ConnectDB
    {
        private static ConnectDB instance;
        public static ConnectDB Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectDB();
                return instance;
            }
        }

        private ConnectDB()
        {

        }

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3RJALEQ\SQLEXPRESS;Initial Catalog=VNR_InternShip;Integrated Security=True");

        public List<MonHoc> GetlistMonHoc()
        {
            connect.Open();
            var ressql = new SqlCommand("SELECT * FROM MonHoc", connect);
            SqlDataReader reader = ressql.ExecuteReader();
            var data = new List<MonHoc>();
            while (reader.Read())
            {
                var item = new MonHoc();
                if (!Convert.IsDBNull(reader["ID"]))
                    item.ID = Convert.ToInt32(reader["ID"]);
                if (!Convert.IsDBNull(reader["TenMonHoc"]))
                    item.TenMonHoc = Convert.ToString(reader["TenMonHoc"]);
                if (!Convert.IsDBNull(reader["MoTa"]))
                    item.MoTa = Convert.ToString(reader["MoTa"]);
                if (!Convert.IsDBNull(reader["KhoaHocID"]))
                    item.KhoaHocID = Convert.ToInt32(reader["KhoaHocID"]);
                data.Add(item);
            }
            connect.Close();

            return data;
        }
        public List<KhoaHoc> GetlistKhoaHoc()
        {
            
            connect.Open();
            var ressql = new SqlCommand("SELECT * FROM KhoaHoc", connect);
            SqlDataReader reader = ressql.ExecuteReader();
            var data = new List<KhoaHoc>();
            while (reader.Read())
            {
                var item = new KhoaHoc();
                if (!Convert.IsDBNull(reader["ID"]))
                    item.ID = Convert.ToInt32(reader["ID"]);
                if (!Convert.IsDBNull(reader["TenKhoaHoc"]))
                    item.TenKhoaHoc = Convert.ToString(reader["TenKhoaHoc"]);
                
                data.Add(item);
            }
            connect.Close();

            return data;
        }

    }
}