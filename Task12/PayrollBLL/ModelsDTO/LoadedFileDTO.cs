namespace PayrollBLL.ModelsDTO
{
    public class LoadedFileDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] LoadFile { get; set; }
        public int PayrollId { get; set; }
    }
}
