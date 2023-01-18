using System.Linq;

namespace ApartmentRent.Models
{
    public class ApartmentUnitOfWork : IApartmentUnitOfWork
    {
        private DatabaseContext context { get; set; }

        public ApartmentUnitOfWork(DatabaseContext ctx) => context = ctx;

        private Repository<City> cityData;
        public Repository<City> Cities
        {
            get
            {
                if (cityData == null)
                    cityData = new Repository<City>(context);
                return cityData;
            }
        }

        private Repository<Apartment> apartmentData;

        public Repository<Apartment> Apartments
        {
            get
            {
                if (apartmentData == null)
                    apartmentData = new Repository<Apartment>(context);
                return apartmentData;
            }
        }

        private Repository<ApartmentOwner> apartmentOwnerData;
        public Repository<ApartmentOwner> ApartmentsOwner
        {
            get
            {
                if (apartmentOwnerData == null)
                    apartmentOwnerData = new Repository<ApartmentOwner>(context);
                return apartmentOwnerData;
            }
        }

        private Repository<ApartmentStatus> apartmentStatusData;
        public Repository<ApartmentStatus> ApartmentStatuses
        {
            get
            {
                if (apartmentStatusData == null)
                    apartmentStatusData = new Repository<ApartmentStatus>(context);
                return apartmentStatusData;
            }
        }

        private Repository<Tag> tagData;
        public Repository<Tag> Tags
        {
            get
            {
                if(tagData == null)
                    tagData = new Repository<Tag>(context);
                return tagData;
            }
        }

        private Repository<TagType> tagTypeData;
        public Repository<TagType> TagTypes
        {
            get
            {
                if( tagTypeData == null)
                    tagTypeData= new Repository<TagType>(context);
                return tagTypeData;
            }
        }

        private Repository<TaggedApartment> taggedApartmenData;
        public Repository<TaggedApartment> TaggedApartments
        {
            get
            {
                if(taggedApartmenData == null)
                    taggedApartmenData= new Repository<TaggedApartment>(context);
                return taggedApartmenData;
            }
        }

        private Repository<ApartmentPicture> pictureData;
        public Repository<ApartmentPicture> ApartmentPictures
        {
            get
            {
                if(pictureData == null)
                    pictureData= new Repository<ApartmentPicture>(context);
                return pictureData;
            }
        }

        private Repository<ApartmentProfilePicture> pictureProfilePictureData;
        public Repository<ApartmentProfilePicture> ApartmentProfilePicture
        {
            get
            {
                if( pictureProfilePictureData == null)
                    pictureProfilePictureData= new Repository<ApartmentProfilePicture>(context);
                return pictureProfilePictureData;
            }
        }

        private Repository<ApartmentAlbum> apartmentAlbumData;
        public Repository<ApartmentAlbum> ApartmentAlbums
        {
            get
            {
                if( apartmentAlbumData == null)
                    apartmentAlbumData= new Repository<ApartmentAlbum>(context);
                return apartmentAlbumData;
            }
        }

        private Repository<ApartmentReview> reviewData;
        public Repository<ApartmentReview> ApartmentReviews
        {
            get
            {
                if (reviewData == null)
                    reviewData = new Repository<ApartmentReview>(context);
                return reviewData;
            }
        }

        public void DeleteCurrentTaggedApartments(Apartment apartment)
        {
            var currentTags = TaggedApartments.List(new QueryOptions<TaggedApartment>
            {
                Where = ta => ta.ApartmentId == apartment.ApartmentId
            });
            foreach (TaggedApartment ta in currentTags)
            {
                TaggedApartments.Delete(ta);
            }
        }

        public void LoadNewTaggedApartments(Apartment apartment, int[] tagids)
        {
            apartment.TaggedApartment = tagids.Select(i => new TaggedApartment { Apartment = apartment, TagId = i }).ToList();
        }

        public void Save()=>context.SaveChanges();

        public void DeleteCurrentApartmentAlbum(Apartment apartment)
        {
            var currentPics = ApartmentAlbums.List(new QueryOptions<ApartmentAlbum>
            {
                Where = ap => ap.ApartmentId == apartment.ApartmentId
            });
            foreach (ApartmentAlbum ap in currentPics)
            {
                ApartmentAlbums.Delete(ap);
            }
        }

        public void LoadNewApartmentAlbum(Apartment apartment, int[] pictureids)
        {
             apartment.ApartmentAlbum = pictureids.Select(i => new ApartmentAlbum { Apartment = apartment, ImageId = i }).ToList();
        }
        
    }
}
