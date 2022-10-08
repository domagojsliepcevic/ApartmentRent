using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace ApartmentRent.Models
{
    public class SearchData

    {
        private const string SearchKey = "search";
        private const string TypeKey = "searchtype";

        private ITempDataDictionary tempData { get; set; }
        public SearchData(ITempDataDictionary temp) =>
            tempData = temp;

        public string SearchTerm
        {
            get => tempData.Peek(SearchKey)?.ToString();
            set => tempData[SearchKey] = value;
        }
        public string Type
        {
            get => tempData.Peek(TypeKey)?.ToString();
            set => tempData[TypeKey] = value;
        }

        public bool HasSearchTerm => !string.IsNullOrEmpty(SearchTerm);
        public bool IsApartment => Type.EqualsNoCase("apartment");
        public bool IsTag => Type.EqualsNoCase("tag");
        public bool IsCity => Type.EqualsNoCase("city");
        public bool IsOwner => Type.EqualsNoCase("owner");

        public bool IsStatus => Type.EqualsNoCase("status");

        public void Clear()
        {
            tempData.Remove(SearchKey);
            tempData.Remove(TypeKey);
        }
    }
}
