namespace Lab2_NguyenTruongGiang_CSE422.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        public string DeviceCategory { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }

}
