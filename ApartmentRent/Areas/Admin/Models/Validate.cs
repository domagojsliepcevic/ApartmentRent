using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ApartmentRent.Models
{
    public class Validate
    {
        private const string OwnerKey = "validOwner";
        private const string CityKey = "validCity";
        private const string TagKey = "validTag";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckOwner(string owner, Repository<ApartmentOwner> data)
        {
            ApartmentOwner entity = data.Get(owner);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Owner {owner} is already in the database.";
        }
        public void MarkOwnerChecked() => tempData[OwnerKey] = true;
        public void ClearOwner() => tempData.Remove(OwnerKey);
        public bool IsOwnerChecked => tempData.Keys.Contains(OwnerKey); 
        public void CheckCity(string city, Repository<City> data)
        {
            City entity = data.Get(city);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"City {city} is already in the database.";
        }
        public void MarkCityChecked() => tempData[CityKey] = true;
        public void ClearCity() => tempData.Remove(CityKey);
        public bool IsCityChecked => tempData.Keys.Contains(CityKey);
        public void CheckTag(string name, Repository<Tag> data)
        {
            Tag entity = data.Get(name);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Tag {name} is already in the database.";
        }
        public void MarkTagChecked() => tempData[TagKey] = true;
        public void ClearTag() => tempData.Remove(TagKey);
        public bool IsTagChecked => tempData.Keys.Contains(TagKey);

    }
}
