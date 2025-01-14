using System.ComponentModel.DataAnnotations;

namespace Lab2_NguyenTruongGiang_CSE422.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Device Name is required")]
        [StringLength(100, ErrorMessage = "Device Name cannot be longer than 100 characters")]
        public string DeviceName { get; set; }

        [Required(ErrorMessage = "Device Code is required")]
        [StringLength(50, ErrorMessage = "Device Code cannot be longer than 50 characters")]
        public string DeviceCode { get; set; }

        [Required(ErrorMessage = "Device Category is required")]
        [StringLength(50, ErrorMessage = "Device Category cannot be longer than 50 characters")]
        public string DeviceCategory { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(50, ErrorMessage = "Status cannot be longer than 50 characters")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Date of Entry is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfEntry { get; set; }
    }
}
