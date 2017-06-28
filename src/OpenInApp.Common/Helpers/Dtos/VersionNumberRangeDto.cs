namespace OpenInApp.Common.Helpers.Dtos
{
    public class VersionNumberRangeDto
    {
        public int StartVersionNumber;
        public int EndVersionNumber;
        public int DecrementValue;//e.g. 110,120,140 for SSMS & 2016,2015,2014 for XML spy
    }
}
