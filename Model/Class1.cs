namespace Model
{
    public static class Class1
    {
        [Serializable]
        public class MonHoc
        {
            public int ID { get; set; }
            public string TenMonHoc { get; set; }

            public string MoTa { get; set; }

            public int KhoaHocID { get; set; }
        }

        [Serializable]
        public class KhoaHoc
        {
            public int ID { get; set; }

            public string TenKhoaHoc { get; set; }
            public List<MonHoc> lstMonHoc { get; set; }
        }
    }
}