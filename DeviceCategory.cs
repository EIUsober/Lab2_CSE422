using System.ComponentModel.DataAnnotations;

namespace Lab2_NguyenTruongGiang_CSE422.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
