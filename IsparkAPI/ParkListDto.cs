namespace IsparkAPI
{
    /*
     * "parkID": 3068,
"parkName": "15 Temmuz Şehitler Meydanı Zeminaltı Otoparkı",
"lat": "41.0246",
"lng": "29.0915",
"capacity": 1029,
"emptyCapacity": 294,
"workHours": "24 Saat",
"parkType": "KAPALI OTOPARK",
"freeTime": 15,
"district": "ÜMRANİYE",
"isOpen": 1
     */
    public record ParkListDto(int ParkID, string ParkName, int Capacity, int EmptyCapacity, int IsOpen, string District);
}
