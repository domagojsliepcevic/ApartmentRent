namespace ApartmentRent.Models
{
    public interface IApartmentUnitOfWork
    {
        Repository<City> Cities { get; }
        Repository<Apartment> Apartments { get; }
        Repository<ApartmentOwner> ApartmentsOwner { get; }
        Repository<ApartmentStatus> ApartmentStatuses { get; }
        Repository<Tag> Tags { get; }
        Repository<TagType> TagTypes { get; }
        Repository<TaggedApartment> TaggedApartments { get; }

        Repository<ApartmentAlbum> ApartmentAlbums { get; }

        Repository<ApartmentPicture> ApartmentPictures { get; }

        Repository<ApartmentReview> ApartmentReviews { get; }


        Repository<ApartmentProfilePicture> ApartmentProfilePicture { get; }


        void DeleteCurrentApartmentAlbum(Apartment apartment);
        void LoadNewApartmentAlbum(Apartment apartment, int[] pictureids);

        void DeleteCurrentTaggedApartments(Apartment apartment);

        void LoadNewTaggedApartments(Apartment apartment, int[] tagids);

        void Save();

    }
}
